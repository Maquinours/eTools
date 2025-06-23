using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Models
{
    public interface ITerrainItem { }

    //public class WaterTexList(int listCnt, float fWaterFrame, int[] pList)
    //{
    //    int _listCnt = listCnt;
    //    float _fWaterFrame = fWaterFrame;
    //    int[] _pList = pList;

    //    public int[] PList => _pList;
    //}

    public class TerrainBraceProp(string name, int frameCount)
    {
        private string _name = name;
        private int _frameCount = frameCount;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int FrameCount
        {
            get => _frameCount;
            set => _frameCount = value;
        }
    }
    public class TerrainBrace(TerrainBraceProp prop, List<ITerrainItem> children) : ITerrainItem
    {
        private readonly TerrainBraceProp _prop = prop;
        private readonly List<ITerrainItem> _children = children;

        public TerrainBraceProp Prop => _prop;
        public List<ITerrainItem> Children => _children;
    }

    public class TerrainProp(int dwId, int frameCount, string szTextureFileName, int bBlock, string szSoundFileName)
    {
        private int _dwId = dwId;
        private int _frameCount = frameCount;
        private string _szTextureFileName = szTextureFileName;
        private int _bBlock = bBlock;
        private string _szSoundFileName = szSoundFileName;

        public int DwId
        {
            get => _dwId;
            set => _dwId = value;
        }
        public int FrameCount
        {
            get => _frameCount;
            set => _frameCount = value;
        }
        public string SzTextureFileName
        {
            get => _szTextureFileName;
            set => _szTextureFileName = value;
        }
        public int BBlock
        {
            get => _bBlock;
            set => _bBlock = value;
        }
        public string SzSoundFileName
        {
            get => _szSoundFileName;
            set => _szSoundFileName = value;
        }
    }

    public class Terrain(TerrainProp prop) : ITerrainItem
    {
        private readonly TerrainProp _prop = prop;

        public TerrainProp Prop => _prop;
    }
}
