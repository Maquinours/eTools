using eTools_Ultimate.Exceptions;
using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace eTools_Ultimate.Services
{
    public class ModelsService(DefinesService definesService)
    {
        private readonly ObservableCollection<MainModelBrace> _models = [];
        public ObservableCollection<MainModelBrace> Models => _models;
        private void ClearBraceRecursively(ModelBrace brace)
        {
            foreach (IModelItem child in brace.Children)
            {
                if (child is ModelBrace childBrace)
                    ClearBraceRecursively(childBrace);
                else if (child is Model childModel)
                    childModel.Dispose();
                else
                    throw new InvalidOperationException("ModelsService::ClearBraceRecursively : child is neither ModelBrace nor Model");
            }
            brace.Children.Clear();
            brace.Dispose();
        }

        private void ClearModels()
        {
            foreach (MainModelBrace brace in this.Models) // Avoid memory leaks
                ClearBraceRecursively(brace);
            this.Models.Clear();
        }

        public void Load()
        {
            List<MainModelBrace> items = [];

            Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;

            this.ClearModels();

            // Maybe make it a settings property
            string filePath = $"{settings.ResourcesFolderPath}mdlDyna.inc";

            using Script script = new();

            script.Load(filePath);

            while (true)
            {
                string szName = script.GetToken();

                if (script.EndOfStream) break;

                uint iType = (uint)script.GetNumber();

                script.GetToken(); // "{"

                script.GetToken(); // Load the next token for the LoadChildren function to work correctly

                IModelItem[] children = LoadChildren(script, filePath, iType);

                MainModelBraceProp prop = new(szName, iType);
                MainModelBrace brace = new(prop, children);

                Models.Add(brace);
            }
        }

        private IModelItem[] LoadChildren(Script script, string filePath, uint dwType)
        {
            List<IModelItem> children = [];

            while (true)
            {
                if (script.Token == "}") // End of current brace
                    return [.. children];

                if (script.EndOfStream)
                    throw new IncorrectlyFormattedFileException(filePath);

                string szObject = script.Token;
                uint iObject = (uint)script.GetNumber();
                if (script.Token == "{") // Start of a new brace
                {
                    script.GetToken();
                    IModelItem[] childBraceChildren = LoadChildren(script, filePath, dwType);
                    script.GetToken();

                    ModelBraceProp childBraceProp = new(szObject);
                    ModelBrace childBrace = new(childBraceProp, childBraceChildren);
                    children.Add(childBrace);
                }
                else
                {
                    uint dwModelType = (uint)script.GetNumber();
                    string szPart = script.GetToken();
                    byte bFly = (byte)script.GetNumber();
                    byte dwDistant = (byte)script.GetNumber();
                    byte bPick = (byte)script.GetNumber();
                    float fScale = script.GetFloat();
                    byte bTrans = (byte)script.GetNumber();
                    byte bShadow = (byte)script.GetNumber();
                    int nTextureEx = script.GetNumber();
                    byte bRenderFlag = (byte)script.GetNumber();

                    script.GetToken();

                    List<ModelMotion> childModelMotions = [];
                    if (script.Token == "{")
                    {
                        while (true)
                        {
                            if (script.EndOfStream)
                                throw new IncorrectlyFormattedFileException(filePath);
                            string szMotion = script.GetToken(); // motion name or }
                            if (script.Token == "}")
                                break;
                            uint iMotion = (uint)script.GetNumber();

                            ModelMotionProp motionProp = new(iMotion, szMotion);
                            ModelMotion motion = new(motionProp);

                            childModelMotions.Add(motion);
                        }
                        script.GetToken();
                    }

                    ModelProp childModelProp = new(
                        dwType: dwType,
                        dwIndex: iObject,
                        szName: szObject,
                        dwModelType: dwModelType,
                        szPart: szPart,
                        bFly: bFly,
                        dwDistant: dwDistant,
                        bPick: bPick,
                        fScale: fScale,
                        bTrans: bTrans,
                        bShadow: bShadow,
                        nTextureEx: nTextureEx,
                        bRenderFlag: bRenderFlag
                        );
                    Model childModel = new(childModelProp, childModelMotions);

                    children.Add(childModel);
                }
            }
        }

        public void Save()
        {
            Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;

            // TODO: make it a settings property
            string filePath = $"{settings.ResourcesFolderPath}mdlDyna.inc";

            using StreamWriter writer = new(filePath, false, new UTF8Encoding(false));
            writer.WriteLine("// ========================================");
            writer.WriteLine("// Generated by eTools Ultimate");
            writer.WriteLine("// https://github.com/Maquinours/eTools");
            writer.WriteLine("// ========================================");
            writer.WriteLine();

            foreach (MainModelBrace mainBrace in Models)
            {
                writer.Write('"');
                writer.Write(mainBrace.Prop.SzName);
                writer.Write('"');
                writer.Write('\t');
                writer.Write(Script.NumberToString(mainBrace.Prop.IType));
                writer.WriteLine();
                writer.WriteLine('{');

                foreach (IModelItem item in mainBrace.Children)
                    SaveItem(writer, item, 1);

                writer.WriteLine('}');
            }
        }

        public void SaveItem(StreamWriter writer, IModelItem item, int indentLevel)
        {
            if (item is ModelBrace brace)
            {
                writer.Write(new string('\t', indentLevel));
                writer.Write('"');
                writer.Write(brace.Prop.SzName);
                writer.Write('"');
                writer.WriteLine();
                writer.Write(new string('\t', indentLevel));
                writer.Write('{');
                writer.WriteLine();

                foreach (IModelItem child in brace.Children)
                    SaveItem(writer, child, indentLevel + 1);

                writer.Write(new string('\t', indentLevel));
                writer.Write('}');
                writer.WriteLine();
            }
            else if (item is Model model)
            {
                writer.Write(new string('\t', indentLevel));
                writer.Write('"');
                writer.Write(model.Prop.SzName);
                writer.Write('"');
                writer.Write('\t');
                writer.Write(model.Identifier);
                writer.Write('\t');
                writer.Write(model.ModelTypeIdentifier);
                writer.Write('\t');
                writer.Write('"');
                writer.Write(model.Prop.SzPart);
                writer.Write('"');
                writer.Write('\t');
                writer.Write(Script.NumberToString(model.Prop.BFly));
                writer.Write('\t');
                writer.Write(model.DistantIdentifier);
                writer.Write('\t');
                writer.Write(Script.NumberToString(model.Prop.BPick));
                writer.Write('\t');
                writer.Write(Script.FloatToString(model.Prop.FScale));
                writer.Write('f');
                writer.Write('\t');
                writer.Write(Script.NumberToString(model.Prop.BTrans));
                writer.Write('\t');
                writer.Write(Script.NumberToString(model.Prop.BShadow));
                writer.Write('\t');
                writer.Write(model.TextureExIdentifier);
                writer.Write('\t');
                writer.Write(Script.NumberToString(model.Prop.BRenderFlag));
                writer.WriteLine();

                if (model.Motions.Count > 0)
                {
                    writer.Write(new string('\t', indentLevel));
                    writer.Write('{');
                    writer.WriteLine();

                    foreach (ModelMotion motion in model.Motions)
                    {
                        writer.Write(new string('\t', indentLevel + 1));
                        writer.Write('"');
                        writer.Write(motion.Prop.SzMotion);
                        writer.Write('"');
                        writer.Write('\t');
                        writer.Write(motion.MotionTypeIdentifier);
                        writer.WriteLine();
                    }

                    writer.Write(new string('\t', indentLevel));
                    writer.Write('}');
                    writer.WriteLine();
                }
            }
        }

        private void GetBracesRecursively(List<ModelBrace> braces, ModelBrace brace)
        {
            braces.Add(brace);
            foreach (IModelItem child in brace.Children)
            {
                if (child is ModelBrace childBrace)
                    GetBracesRecursively(braces, childBrace);
            }
        }

        private Model[] GetModelsRecursively(ModelBrace brace)
        {
            List<Model> models = [];
            foreach (IModelItem child in brace.Children)
            {
                if (child is Model childModel)
                    models.Add(childModel);
                else if (child is ModelBrace childBrace)
                    models.AddRange(GetModelsRecursively(childBrace));
            }
            return [.. models];
        }

        private ModelBrace[] GetBracesByType(uint type)
        {
            List<ModelBrace> braces = [];
            foreach (MainModelBrace mainBrace in Models)
            {
                if (mainBrace.Prop.IType != type) continue;
                GetBracesRecursively(braces, mainBrace);
            }

            return braces.ToArray();
        }

        public Model[] GetModelsByType(int type)
        {
            List<Model> models = [];
            foreach (MainModelBrace mainBrace in Models)
            {
                if (mainBrace.Prop.IType != type) continue;
                models.AddRange(GetModelsRecursively(mainBrace));
            }
            return [.. models];
        }

        public ModelBrace GetBraceByModel(Model model)
        {
            foreach (ModelBrace brace in GetBracesByType(model.Prop.DwType))
            {
                foreach (IModelItem tempModel in brace.Children)
                    if (tempModel == model)
                        return brace;
            }
            throw new InvalidOperationException("ModelsService::GetBraceByModel Exception : Model not found");
        }

        public Model? GetModelByTypeAndId(int type, uint id)
        {
            return GetModelsByType(type).FirstOrDefault(model => model.Prop.DwIndex == id);
        }

        public Model? GetModelByObject(object obj)
        {
            int? modelType;
            uint? objId;

            switch (obj)
            {
                case Mover mover:
                    modelType = definesService.Defines["OT_MOVER"];
                    objId = mover.Id;
                    break;
                case Item item:
                    modelType = definesService.Defines["OT_ITEM"];
                    objId = item.Id;
                    break;
                default:
                    throw new InvalidOperationException("ModelsService::GetModelByObject Exception : obj has an invalid type");
            }

            if (!modelType.HasValue)
                throw new InvalidOperationException("ModelsService::GetModelByObject Exception : modelType has no value");
            if (!objId.HasValue)
                throw new InvalidOperationException("ModelsService::GetModelByObject Exception : objId has no value");

            return GetModelByTypeAndId(modelType.Value, objId.Value);
        }

        public Model CreateModelByObject(object obj)
        {
            switch (obj)
            {
                case Mover mover:
                    uint dwType = (uint)definesService.Defines["OT_MOVER"];
                    uint dwIndex = mover.Id;
                    uint dwModelType = (uint)definesService.Defines["MODELTYPE_ANIMATED_MESH"];
                    byte dwDistant = (byte)definesService.Defines["MD_MID"];

                    ModelProp modelProp = new(
                        dwType: dwType,
                        dwIndex: dwIndex,
                        szName: "",
                        dwModelType: dwModelType,
                        szPart: "",
                        bFly: 0,
                        dwDistant: dwDistant,
                        bPick: 0,
                        fScale: 1f,
                        bTrans: 0,
                        bShadow: 1,
                        nTextureEx: 0,
                        bRenderFlag: 1
                        );
                    Model model = new(modelProp, []);

                    Models.First(x => x.Prop.IType == dwType).Children.Add(model);

                    return model;
                default:
                    throw new InvalidOperationException("ModelsService::CreateModelByObject Exception : obj has an invalid type");
            }
        }

        public void RemoveModel(Model model)
        {
            ModelBrace brace = GetBraceByModel(model);

            model.Dispose();
            brace.Children.Remove(model);
        }

        public void SetBraceToModel(Model model, ModelBrace brace)
        {
            ModelBrace oldBrace = GetBraceByModel(model);
            oldBrace?.Children.Remove(model); // Remove old
            brace.Children.Add(model); // Add to new
        }
    }
}
