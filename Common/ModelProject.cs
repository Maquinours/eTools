using Scan;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Globalization;

namespace Common
{
    internal sealed partial class Project
    {
        /// <summary>
        /// List of models
        /// </summary>
        private readonly List<MainModelBrace> models;

        private void LoadModels(string filePath)
        {
#if __MOVERS
            if (!defines.ContainsKey("OT_MOVER")) throw new MissingDefineException("OT_MOVER");
#endif // __MOVERS
#if __ITEMS
            if (!defines.ContainsKey("OT_ITEM")) throw new MissingDefineException("OT_ITEM");
#endif // __ITEMS
            this.ClearMotions();
            Scanner scanner = new Scanner();
            scanner.Load(filePath);

            string szObject;
            while (true)
            {
                MainModelBrace mainBrace = new MainModelBrace
                {
                    SzName = scanner.GetToken() // Name of the main brace
                };
                if (scanner.EndOfStream) break; // If there is no more brace
                mainBrace.IType = scanner.GetNumber(); // Type of the main brace
                scanner.GetToken(); // {
                scanner.GetToken(); // object name or }
                this.models.Add(mainBrace);
                List<ModelBrace> currBraces = new List<ModelBrace> // List containing current brace and its parents (last element is current brace)
                {
                    mainBrace
                };
                ModelBrace currBrace = mainBrace;
                while (currBraces.Count > 0)
                {
                    if (scanner.Token == "}") // End of current brace
                    {
                        currBraces.RemoveAt(currBraces.Count - 1);
                        if (currBraces.Count != 0)
                        {
                            currBrace = currBraces[currBraces.Count - 1];
                            scanner.GetToken();
                        }
                        continue;
                    }
                    if (scanner.EndOfStream)
                        throw new IncorrectlyFormattedFileException(filePath);
                    szObject = scanner.Token;
                    scanner.GetToken();
                    if (scanner.Token == "{") // Start of a new brace
                    {
                        ModelBrace tempBrace = new ModelBrace
                        {
                            SzName = szObject
                        };
                        currBrace.Braces.Add(tempBrace);
                        currBrace = tempBrace;
                        currBraces.Add(currBrace);
                        scanner.GetToken();
                        continue;
                    }
                    // Model element
                    ModelElem modelElem = new ModelElem();
                    string iObject = scanner.Token;
                    modelElem.DwType = mainBrace.IType;
                    modelElem.DwIndex = iObject;
                    modelElem.SzName = szObject;
                    modelElem.DwModelType = scanner.GetToken();
                    modelElem.SzPart = scanner.GetToken();
                    modelElem.BFly = scanner.GetNumber();
                    modelElem.DwDistant = scanner.GetToken();
                    modelElem.BPick = scanner.GetNumber();
                    modelElem.FScale = scanner.GetFloat();
                    modelElem.BTrans = scanner.GetNumber();
                    modelElem.BShadow = scanner.GetNumber();
                    modelElem.NTextureEx = scanner.GetToken();
                    modelElem.BRenderFlag = scanner.GetNumber();

                    scanner.GetToken();
                    if (scanner.Token == "{")
                    {
                        while (true)
                        {
                            Motion motion = new Motion();
                            if (scanner.EndOfStream)
                                throw new IncorrectlyFormattedFileException(filePath);
                            motion.SzMotion = scanner.GetToken(); // motion name or }
                            if (motion.SzMotion == "}")
                                break;
                            motion.IMotion = scanner.GetToken();
                            modelElem.Motions.Add(motion);
                        }
                        scanner.GetToken();
                    }
                    currBrace.Models.Add(modelElem); // We add the current model to the current brace
#if __MOVERS
                    if (modelElem.DwType == this.defines["OT_MOVER"]) // If model corresponds to a mover
                    {
                        Mover mover = this.GetMoverById(modelElem.DwIndex);
                        if (mover != null)
                            mover.Model = modelElem; // We get the mover that the model is for and we set its model to the current model
                    }
#endif // __MOVERS
#if __ITEMS
                    if (modelElem.DwType == this.defines["OT_ITEM"]) // If model corresponds to an item
                    {
                        Item item = this.GetItemById(modelElem.DwIndex);
                        if (item != null)
                            item.Model = modelElem; // We get the item that the model is for and we set its model to the current model
                    }
#endif // __ITEMS
                }
            }
#if __MOVERS
            foreach(Mover mover in this.Movers.Where(x => x.Model == null)) // We add a default model for each mover who doesn't have any
            {
                mover.Model = new ModelElem
                {
                    DwType = defines["OT_MOVER"],
                    SzName = "",
                    DwIndex = mover.Prop.DwId,
                    DwModelType = "MODELTYPE_ANIMATED_MESH",
                    SzPart = "",
                    BFly = 0,
                    DwDistant = "MD_MID",
                    BPick = 0,
                    FScale = 1f,
                    BTrans = 0,
                    BShadow = 1,
                    NTextureEx = "ATEX_NONE",
                    BRenderFlag = 1
                };
            }
#endif
            scanner.Close();
        }

        private void SaveModels(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false, new UnicodeEncoding()))
            {
                foreach (MainModelBrace brace in models)
                {
                    SaveModelBrace(brace, writer, 0);
                }
            }
        }

        private void SaveModelBrace(ModelBrace brace, StreamWriter writer, int indent)
        {
            CultureInfo cultureInfo = new CultureInfo("en-US");

            writer.Write($"{new string('\t', indent)}\"{brace.SzName}\"");
            if (brace is MainModelBrace mainModelBrace)
                writer.Write($"\t{mainModelBrace.IType}");
            writer.Write($"\r\n{new string('\t', indent)}{{\r\n");
            foreach (ModelBrace br in brace.Braces)
            {
                SaveModelBrace(br, writer, indent + 1);
            }
            foreach (ModelElem elem in brace.Models)
            {
                writer.Write(new string('\t', indent + 1));
                writer.Write($"\"{elem.SzName}\"\t");
                writer.Write($"{elem.DwIndex}\t");
                writer.Write($"{elem.DwModelType}\t");
                writer.Write($"\"{elem.SzPart}\"\t");
                writer.Write($"{elem.BFly}\t");
                writer.Write($"{elem.DwDistant}\t");
                writer.Write($"{elem.BPick}\t");
                writer.Write($"{elem.FScale.ToString(cultureInfo)}f\t");
                writer.Write($"{elem.BTrans}\t");
                writer.Write($"{elem.BShadow}\t");
                writer.Write($"{elem.NTextureEx}\t");
                writer.Write($"{elem.BRenderFlag}\r\n");
                if (elem.Motions.Count > 0)
                {
                    writer.Write($"{new string('\t', indent + 1)}{{\r\n");
                    foreach (Motion motion in elem.Motions)
                    {
                        writer.Write(new string('\t', indent + 2));
                        writer.Write($"\"{motion.SzMotion}\"\t");
                        writer.Write($"{motion.IMotion}\r\n");
                    }
                    writer.Write($"{new string('\t', indent + 1)}}}\r\n");
                }
            }
            writer.Write($"{new string('\t', indent)}}}\r\n");
        }

        private ModelBrace[] GetBracesByType(int type)
        {
            List<ModelBrace> braces = new List<ModelBrace>();
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
            return null;
        }

        public void SetBraceToModel(ModelElem model, ModelBrace brace)
        {
            ModelBrace oldBrace = GetBraceByModel(model);
            oldBrace?.Models.Remove(model); // Remove old
            brace.Models.Add(model); // Add to new
        }

        private void GetBracesRecursively(List<ModelBrace> braces, ModelBrace brace)
        {
            braces.Add(brace);
            foreach (ModelBrace subBrace in brace.Braces)
            {
                GetBracesRecursively(braces, subBrace);
            }
        }

        private void ClearBraceRecursively(ModelBrace brace)
        {
            foreach (ModelBrace child in brace.Braces)
            {
                ClearBraceRecursively(child);
            }
            brace.Braces.Clear();
            brace.Models.Clear();
        }

        public void GenerateMotions(ModelElem model)
        {
            string[] aniFiles = GetAvalaibleMotionsFilesByModel(model);
            string[] motionIdentifiers = GetMotionsIdentifiers();
            foreach (string file in aniFiles)
            {
                string identifier = motionIdentifiers.FirstOrDefault(x => x.Remove(0, 4).ToLower() == file.ToLower());
                if (string.IsNullOrEmpty(identifier) || model.Motions.Count(x => x.IMotion == identifier) > 0) continue;
                Motion newMotion = new Motion()
                {
                    SzMotion = file,
                    IMotion = identifier
                };
                model.Motions.Add(newMotion);
            }
        }

        public string[] GetAvalaibleMotionsFilesByModel(ModelElem model)
        {
            return Directory.GetFiles(Settings.GetInstance().ResourcePath + "Model\\", $"mvr_{model.SzName}*.ani").Select(x => Path.GetFileNameWithoutExtension(x).Remove(0, $"mvr_{model.SzName}_".Length)).ToArray();
        }

        public void ClearMotions()
        {
            foreach (MainModelBrace brace in this.models) // Avoid memory leaks
                ClearBraceRecursively(brace);
            this.models.Clear();
        }
    }
}
