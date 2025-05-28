using eTools_Ultimate.Models;
using Scan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTools_Ultimate.Exceptions;
using System.Collections.ObjectModel;
using eTools_Ultimate.Helpers;

namespace eTools_Ultimate.Services
{
    internal class ModelsService
    {
        private static readonly Lazy<ModelsService> _instance = new(() => new ModelsService());
        public static ModelsService Instance => _instance.Value;

        private readonly ObservableCollection<MainModelBrace> models = [];
        public ObservableCollection<MainModelBrace> Models => models;
        private void ClearBraceRecursively(ModelBrace brace)
        {
            foreach (ModelBrace child in brace.Braces)
                ClearBraceRecursively(child);
            foreach (ModelElem model in brace.Models)
                model.Dispose();

            brace.Braces.Clear();
            brace.Models.Clear();
        }

        private void ClearModels()
        {
            foreach (MainModelBrace brace in this.models) // Avoid memory leaks
                ClearBraceRecursively(brace);
            this.models.Clear();
        }

        public void Load()
        {
            this.ClearModels();

            ObservableDictionary<string, int> defines = DefinesService.Instance.Defines;
            MoversService moversService = MoversService.Instance;
            ItemsService itemsService = ItemsService.Instance;

            // Maybe make it a settings property
            string filePath = $"{Settings.Instance.ResourcesFolderPath}mdlDyna.inc";

            using (Script script = new()) 
            {
                script.Load(filePath);

                string szObject;
                while (true)
                {
                    MainModelBrace mainBrace = new()
                    {
                        SzName = script.GetToken() // Name of the main brace
                    };
                    if (script.EndOfStream) break; // If there is no more brace
                    mainBrace.IType = script.GetNumber(); // Type of the main brace
                    script.GetToken(); // {
                    script.GetToken(); // object name or }
                    this.models.Add(mainBrace);
                    List<ModelBrace> currBraces =
                // List containing current brace and its parents (last element is current brace)
                [
                    mainBrace
                ];
                    ModelBrace currBrace = mainBrace;
                    while (currBraces.Count > 0)
                    {
                        if (script.Token == "}") // End of current brace
                        {
                            currBraces.RemoveAt(currBraces.Count - 1);
                            if (currBraces.Count != 0)
                            {
                                currBrace = currBraces[currBraces.Count - 1];
                                script.GetToken();
                            }
                            continue;
                        }
                        if (script.EndOfStream)
                            throw new IncorrectlyFormattedFileException(filePath);
                        szObject = script.Token;
                        int iObject = script.GetNumber();
                        if (script.Token == "{") // Start of a new brace
                        {
                            ModelBrace tempBrace = new ModelBrace
                            {
                                SzName = szObject
                            };
                            currBrace.Braces.Add(tempBrace);
                            currBrace = tempBrace;
                            currBraces.Add(currBrace);
                            script.GetToken();
                            continue;
                        }
                        // Model element
                        ModelElem modelElem = new()
                        {
                            DwType = mainBrace.IType,
                            DwIndex = iObject,
                            SzName = szObject,
                            DwModelType = script.GetNumber(),
                            SzPart = script.GetToken(),
                            BFly = script.GetNumber(),
                            DwDistant = script.GetNumber(),
                            BPick = script.GetNumber(),
                            FScale = script.GetFloat(),
                            BTrans = script.GetNumber(),
                            BShadow = script.GetNumber(),
                            NTextureEx = script.GetNumber(),
                            BRenderFlag = script.GetNumber()
                        };

                        script.GetToken();
                        if (script.Token == "{")
                        {
                            while (true)
                            {
                                ModelMotion motion = new ModelMotion();
                                if (script.EndOfStream)
                                    throw new IncorrectlyFormattedFileException(filePath);
                                motion.SzMotion = script.GetToken(); // motion name or }
                                if (motion.SzMotion == "}")
                                    break;
                                motion.IMotion = script.GetNumber();
                                modelElem.Motions.Add(motion);
                            }
                            script.GetToken();
                        }
                        currBrace.Models.Add(modelElem); // We add the current model to the current brace
                        if (modelElem.DwType == defines["OT_MOVER"]) // If model corresponds to a mover
                        {
                            Mover? mover = moversService.GetMoverById(modelElem.DwIndex);
                            if (mover != null)
                                mover.Model = modelElem; // We get the mover that the model is for and we set its model to the current model
                        }
                        else if (modelElem.DwType == defines["OT_ITEM"]) // If model corresponds to an item
                        {
                            Item? item = itemsService.GetItemById(modelElem.DwIndex);
                            if (item != null)
                                item.Model = modelElem; // We get the item that the model is for and we set its model to the current model
                        }
                    }
                }
            }

            // TODO: maybe readd it
            //foreach(Mover mover in moversService.Movers.Where(x => x.Model == null)) // We add a default model for each mover who doesn't have any
            //{
            //    mover.Model = new ModelElem
            //    {
            //        DwType = defines["OT_MOVER"],
            //        SzName = "",
            //        DwIndex = mover.Prop.DwId,
            //        DwModelType = "MODELTYPE_ANIMATED_MESH",
            //        SzPart = "",
            //        BFly = 0,
            //        DwDistant = "MD_MID",
            //        BPick = 0,
            //        FScale = 1f,
            //        BTrans = 0,
            //        BShadow = 1,
            //        NTextureEx = "ATEX_NONE",
            //        BRenderFlag = 1
            //    };
            //}
        }

        private void GetBracesRecursively(List<ModelBrace> braces, ModelBrace brace)
        {
            braces.Add(brace);
            foreach (ModelBrace subBrace in brace.Braces)
            {
                GetBracesRecursively(braces, subBrace);
            }
        }

        private ModelBrace[] GetBracesByType(int type)
        {
            List<ModelBrace> braces = [];
            foreach (MainModelBrace mainBrace in models)
            {
                if (mainBrace.IType != type) continue;
                GetBracesRecursively(braces, mainBrace);
            }

            return braces.ToArray();
        }

        public ModelBrace GetBraceByModel(ModelElem model)
        {
            foreach (ModelBrace brace in GetBracesByType(model.DwType))
            {
                foreach (ModelElem tempModel in brace.Models)
                    if (tempModel == model)
                        return brace;
            }
            throw new Exception("ModelsService::GetBraceByModel Exception : Model not found");
        }

        public void SetBraceToModel(ModelElem model, ModelBrace brace)
        {
            ModelBrace oldBrace = GetBraceByModel(model);
            oldBrace?.Models.Remove(model); // Remove old
            brace.Models.Add(model); // Add to new
        }
    }
}
