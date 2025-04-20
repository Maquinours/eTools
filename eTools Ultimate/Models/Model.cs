using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Models
{
    public class Motion : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _szMotion;
        private string _iMotion;

        public string SzMotion { get => this._szMotion; set { this._szMotion = value; this.NotifyPropertyChanged(); } }
        public string IMotion { get => this._iMotion; set { this._iMotion = value; this.NotifyPropertyChanged(); } }
    }

    public class ModelBrace : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _szName;
        private List<ModelBrace> _braces;
        private List<ModelElem> _models;

        public string SzName { get => this._szName; set { if (this.SzName != value) { this._szName = value; this.NotifyPropertyChanged(); } } }
        public List<ModelBrace> Braces { get => this._braces; set { if (this.Braces != value) { this._braces = value; this.NotifyPropertyChanged(); } } }
        public List<ModelElem> Models { get => this._models; set { if (this.Models != value) { this._models = value; this.NotifyPropertyChanged(); } } }

        public ModelBrace()
        {
            this.SzName = string.Empty;
            this.Braces = new List<ModelBrace>();
            this.Models = new List<ModelElem>();
        }
    }
    internal class MainModelBrace : ModelBrace
    {
        private int _iType;

        public int IType { get => this._iType; set { if (this.IType != value) { this._iType = value; this.NotifyPropertyChanged(); } } }
    }

    public class ModelElem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _dwType;
        private string _dwIndex;
        private string _szName;
        private string _dwModelType;
        private string _szPart;
        private int _bFly;
        private string _dwDistant;
        private int _bPick;
        private float _fScale;
        private int _bTrans;
        private int _bShadow;
        private string _nTextureEx;
        private int _bRenderFlag;
        private List<Motion> _motions;

        public int DwType { get => this._dwType; set { if (this.DwType != value) { this._dwType = value; this.NotifyPropertyChanged(); } } }
        public string DwIndex { get => this._dwIndex; set { if (this.DwIndex != value) { this._dwIndex = value; this.NotifyPropertyChanged(); } } }
        public string SzName { get => this._szName; set { if (this.SzName != value) { this._szName = value; this.NotifyPropertyChanged(); } } }
        public string DwModelType { get => this._dwModelType; set { if (this.DwModelType != value) { this._dwModelType = value; this.NotifyPropertyChanged(); } } }
        public string SzPart { get => this._szPart; set { if (this.SzPart != value) { this._szPart = value; this.NotifyPropertyChanged(); } } }
        public int BFly { get => this._bFly; set { if (this.BFly != value) { this._bFly = value; this.NotifyPropertyChanged(); } } }
        public string DwDistant { get => this._dwDistant; set { if (this.DwDistant != value) { this._dwDistant = value; this.NotifyPropertyChanged(); } } }
        public int BPick { get => this._bPick; set { if (this.BPick != value) { this._bPick = value; this.NotifyPropertyChanged(); } } }
        public float FScale { get => this._fScale; set { if (this.FScale != value) { this._fScale = value; this.NotifyPropertyChanged(); } } }
        public int BTrans { get => this._bTrans; set { if (this.BTrans != value) { this._bTrans = value; this.NotifyPropertyChanged(); } } }
        public int BShadow { get => this._bShadow; set { if (this.BShadow != value) { this._bShadow = value; this.NotifyPropertyChanged(); } } }
        public string NTextureEx { get => this._nTextureEx; set { if (this.NTextureEx != value) { this._nTextureEx = value; this.NotifyPropertyChanged(); } } }
        public int BRenderFlag { get => this._bRenderFlag; set { if (this.BRenderFlag != value) { this._bRenderFlag = value; this.NotifyPropertyChanged(); } } }

        public List<Motion> Motions { get => this._motions; private set { if (this.Motions != value) { this._motions = value; this.NotifyPropertyChanged(); } } }

        // TODO: maybe readd it
        //public ModelBrace Brace // Maybe we should watch for braces changes to handle refresh problems, but I'm not sure if it's necessary for now.
        //{
        //    get => Project.GetInstance().GetBraceByModel(this);
        //    set { if (this.Brace != value) { Project.GetInstance().SetBraceToModel(this, value); this.NotifyPropertyChanged(); } }
        //}

        public ModelElem()
        {
            this.Motions = new List<Motion>();
        }
    }
}
