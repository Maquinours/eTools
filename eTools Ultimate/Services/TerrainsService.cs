using eTools_Ultimate.Exceptions;
using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using Scan;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Services
{
    class TerrainsService
    {
        private static readonly Lazy<TerrainsService> _instance = new(() => new());
        public static TerrainsService Instance => _instance.Value;

        public ObservableCollection<ITerrainItem> TerrainItems { get; set; } = [];

        public void Load()
        {
            string filePath = $"{Settings.Instance.ResourcesFolderPath}{Path.DirectorySeparatorChar}Terrain.inc"; // TODO: Use a proper path from Settings

            using Scanner scanner = new();

            scanner.Load(filePath);

            List<TerrainBrace> braces = [];

            while(true)
            {
                int i = scanner.GetNumber(); // folder name or terrain ID

                if(scanner.EndOfStream)
                {
                    if (braces.Count > 0)
                        throw new IncorrectlyFormattedFileException(filePath);
                    else
                        break;
                }
                else if(scanner.Token == "}")
                    braces.RemoveAt(braces.Count - 1); // Close the last brace if we hit a closing brace

                else if (scanner.TokenType == TokenType.STRING)
                {
                    string folderName = scanner.Token;
                    int frameCount = scanner.GetNumber();

                    scanner.GetToken(); // Expecting '{'

                    TerrainBraceProp braceProp = new(folderName, frameCount);
                    TerrainBrace brace = new(braceProp, []);

                    if (braces.Count > 0)
                        braces[^1].Children.Add(brace);
                    else
                        TerrainItems.Add(brace);
                    braces.Add(brace);
                }
                else if(scanner.TokenType == TokenType.NUMBER)
                {
                    int dwId = i;
                    int frameCount = scanner.GetNumber();
                    string textureFileName = scanner.GetToken();
                    int bBlock = scanner.GetNumber();
                    string soundFileName = scanner.GetToken();

                    TerrainProp terrainProp = new(dwId, frameCount, textureFileName, bBlock, soundFileName);
                    Terrain terrain = new(terrainProp);
                    if (braces.Count > 0)
                        braces[^1].Children.Add(terrain);
                    else
                        TerrainItems.Add(terrain);
                }

            }

//            int nWaterFrame;
//            WaterTexList[]? pWaterIndexList = null;

//            int nSize = 0;
//            int nBrace = 1;
//            int frameCount = 0, imageCount = 0, idCnt = 0;

//            int i = scanner.GetNumber();
//            frameCount = scanner.GetNumber();

//            if(frameCount != 0)
//            {
//                nWaterFrame = frameCount;
//                pWaterIndexList = new WaterTexList[nWaterFrame];
//            }

//            while(nBrace != 0)
//            {
//                if(scanner.Token == "}" || scanner.EndOfStream)
//                {
//                    nBrace--;
//                    if (nBrace > 0)
//                    {
//                        scanner.SetMark();
//                        i = scanner.GetNumber();
//                        if (i > nSize) nSize = i;

//                        frameCount = scanner.GetNumber();
//                        idCnt = 0;

//                        if (nBrace == 1 && frameCount != 0)
//                        {
//                            nWaterFrame = frameCount;
//                            pWaterIndexList = new WaterTexList[nWaterFrame];
//                            imageCount = 0;
//                        }
//                        else if (nBrace == 2 && frameCount != 0)
//                        {
//                            if (pWaterIndexList == null) throw new InvalidOperationException("Water index list is null.");

//                            int listCount = frameCount;
//                            float fWaterFrame = 0.15f;
//                            int[] pList = [frameCount];
//                            //#if __VER >= 14 // __WATER_EXT
//                            //					m_pWaterIndexList[ImageCnt].fWaterFrame = 0.15f;
//                            //#endif //__WATER_EXT
//                            pWaterIndexList[imageCount] = new WaterTexList(listCount, fWaterFrame, pList);
//                            imageCount++;
//                        }
//                        continue;
//                    }
//                    if(nBrace == 0)
//                        continue;
//                }

//                scanner.GetToken(); // { or file name

//                if(scanner.Token == "{")
//                {
//                    nBrace++;
//                    scanner.SetMark();
//                    i = scanner.GetNumber();
//                    frameCount = scanner.GetNumber();
//                    if(i == 0)
//                    {
//                        if(nBrace == 2 & frameCount != 0)
//                        {
//                            int listCount = frameCount;
//                            float fWaterFrame = 0.15f;
//                            int[] pList = new int[frameCount];
////#if __VER >= 14 // __WATER_EXT
////					m_pWaterIndexList[ImageCnt].fWaterFrame = 0.15f;
////#endif //__WATER_EXT
//                            pWaterIndexList[imageCount] = new WaterTexList(listCount, fWaterFrame, pList);
//                            imageCount++;
//                        }
//                    }

//                    if (i > nSize) nSize = i;
//                    continue;
//                }
//                else
//                {
//                    scanner.GoMark();
//                    i = scanner.GetNumber();
//                    if(i > nSize) nSize = i;
//                    frameCount = scanner.GetNumber();
//                    if(nBrace == 3)
//                    {
//                        pWaterIndexList[imageCount - 1].PList[idCnt] = i;
//                        idCnt++;
//                    }
//                }

//                int dwId = i;
//                string szTextureFileName = scanner.GetToken();
//                int bBlock = scanner.GetNumber();
//                string soundFileName = scanner.GetToken();

//                TerrainProp terrainProp = new(dwId, szTextureFileName, bBlock, soundFileName);
//                terrains.Add(terrainProp); // TODO: Remove, used for testing

//                scanner.SetMark();
//                i = scanner.GetNumber();
//                if(i > nSize) nSize = i;
//            }
        }

        public void Save()
        {
            string filePath = $"{Settings.Instance.ResourcesFolderPath}{Path.DirectorySeparatorChar}Terrain.inc"; // TODO: Use a proper path from Settings

            using StreamWriter writer = new(filePath, false, new UTF8Encoding(false));
            writer.WriteLine("// ========================================");
            writer.WriteLine("// Generated by eTools Ultimate");
            writer.WriteLine("// https://github.com/Maquinours/eTools");
            writer.WriteLine("// ========================================");
            writer.WriteLine();

            foreach(ITerrainItem terrainItem in TerrainItems)
                SaveItem(writer, terrainItem, 0);
        }

        private void SaveItem(StreamWriter writer, ITerrainItem item, int indentLevel)
        {
            if (item is TerrainBrace brace)
            {
                writer.Write(new string('\t', indentLevel));
                writer.Write('"');
                writer.Write(brace.Prop.Name);
                writer.Write('"');
                writer.Write('\t');
                writer.Write(brace.Prop.FrameCount.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine();
                writer.Write(new string('\t', indentLevel));
                writer.Write('{');
                writer.WriteLine();
                foreach (ITerrainItem child in brace.Children)
                {
                    SaveItem(writer, child, indentLevel + 1);
                }
                writer.Write(new string('\t', indentLevel));
                writer.Write('}');
                writer.WriteLine();
            }
            else if(item is Terrain terrain)
            {
                writer.Write(new string('\t', indentLevel));
                writer.Write(terrain.Prop.DwId.ToString(CultureInfo.InvariantCulture));
                writer.Write('\t');
                writer.Write(terrain.Prop.FrameCount.ToString(CultureInfo.InvariantCulture));
                writer.Write('\t');
                writer.Write('"');
                writer.Write(terrain.Prop.SzTextureFileName);
                writer.Write('"');
                writer.Write('\t');
                writer.Write(terrain.Prop.BBlock.ToString(CultureInfo.InvariantCulture));
                writer.Write('\t');
                writer.Write('"');
                writer.Write(terrain.Prop.SzSoundFileName);
                writer.Write('"');
                writer.WriteLine();
            }
        }
    }
}
