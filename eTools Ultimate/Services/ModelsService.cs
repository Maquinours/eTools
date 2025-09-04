using eTools_Ultimate.Exceptions;
using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using Microsoft.Extensions.DependencyInjection;
using Scan;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Services
{
    public class ModelsService
    {
        private readonly ObservableCollection<MainModelBrace> _models = [];
        public ObservableCollection<MainModelBrace> Models => _models;
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
            foreach (MainModelBrace brace in this.Models) // Avoid memory leaks
                ClearBraceRecursively(brace);
            this.Models.Clear();
        }

        public void Load()
        {
            Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;

            this.ClearModels();

            // Maybe make it a settings property
            string filePath = $"{settings.ResourcesFolderPath}mdlDyna.inc";

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
                    script.GetToken(); // "{"
                    script.GetToken(); // object name or }
                    this.Models.Add(mainBrace);
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
                                if (script.EndOfStream)
                                    throw new IncorrectlyFormattedFileException(filePath);
                                string szMotion = script.GetToken(); // motion name or }
                                if (script.Token == "}")
                                    break;
                                int iMotion = script.GetNumber();

                                ModelMotion motion = new ModelMotion(iMotion, szMotion);
                                modelElem.Motions.Add(motion);
                            }
                            script.GetToken();
                        }
                        currBrace.Models.Add(modelElem); // We add the current model to the current brace
                    }
                }
            }
        }

        private void GetBracesRecursively(List<ModelBrace> braces, ModelBrace brace)
        {
            braces.Add(brace);
            foreach (ModelBrace subBrace in brace.Braces)
            {
                GetBracesRecursively(braces, subBrace);
            }
        }

        private ModelElem[] GetModelsRecursively(ModelBrace brace)
        {
            List<ModelElem> models = [];
            foreach(ModelElem model in brace.Models)
            {
                models.Add(model);
            }
            foreach (ModelBrace modelBrace in brace.Braces)
            {
                models.AddRange(GetModelsRecursively(modelBrace));
            }
            return [.. models];
        }

        private ModelBrace[] GetBracesByType(int type)
        {
            List<ModelBrace> braces = [];
            foreach (MainModelBrace mainBrace in Models)
            {
                if (mainBrace.IType != type) continue;
                GetBracesRecursively(braces, mainBrace);
            }

            return braces.ToArray();
        }

        public ModelElem[] GetModelsByType(int type)
        {
            List<ModelElem> models = [];
            foreach(MainModelBrace mainBrace in Models)
            {
                if (mainBrace.IType != type) continue;
                models.AddRange(GetModelsRecursively(mainBrace));
            }
            return [.. models];
        }

        public ModelBrace GetBraceByModel(ModelElem model)
        {
            foreach (ModelBrace brace in GetBracesByType(model.DwType))
            {
                foreach (ModelElem tempModel in brace.Models)
                    if (tempModel == model)
                        return brace;
            }
            throw new InvalidOperationException("ModelsService::GetBraceByModel Exception : Model not found");
        }

        public ModelElem? GetModelByTypeAndId(int type, int id)
        {
            return GetModelsByType(type).FirstOrDefault(model => model.DwIndex == id);
        }

        public void SetBraceToModel(ModelElem model, ModelBrace brace)
        {
            ModelBrace oldBrace = GetBraceByModel(model);
            oldBrace?.Models.Remove(model); // Remove old
            brace.Models.Add(model); // Add to new
        }
    }
}
