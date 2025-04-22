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
            {
                ClearBraceRecursively(child);
            }
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

            using (Scanner scanner = new Scanner()) 
            {
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
    }
}
