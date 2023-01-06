using System.Collections.Generic;

namespace eTools
{
    public class Motion
    {
        public string SzMotion { get; set; }
        public string IMotion { get; set; }
    }

    internal class ModelBrace
    {
        public string SzName { get; set; }
        public List<ModelBrace> Braces { get; set; }
        public List<ModelElem> Models { get; set; }

        public ModelBrace()
        {
            this.SzName = string.Empty;
            this.Braces = new List<ModelBrace>();
            this.Models = new List<ModelElem>();
        }
    }
    internal class MainModelBrace : ModelBrace
    {
        public int IType { get; set; }
    }

    public class ModelElem
    {
        public int DwType { get; set; }
        public string DwIndex { get; set; }
        public string SzName { get; set; }
        public string DwModelType { get; set; }
        public string SzPart { get; set; }
        public int BFly { get; set; }
        public string DwDistant { get; set; }
        public int BPick { get; set; }
        public float FScale { get; set; }
        public int BTrans { get; set; }
        public int BShadow { get; set; }
        public string NTextureEx { get; set; }
        public int BRenderFlag { get; set; }

        public List<Motion> Motions { get; set; }

        public ModelElem()
        {
            this.Motions = new List<Motion>();
        }
    }
}