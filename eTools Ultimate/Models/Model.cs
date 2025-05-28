using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using eTools_Ultimate.Services;

namespace eTools_Ultimate.Models
{
    public class ModelMotion : INotifyPropertyChanged
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

    public class ModelElem : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            switch(propertyName)
            {
                case nameof(this.DwType):
                case nameof(this.DwModelType):
                case nameof(this.SzName):
                    NotifyPropertyChanged(nameof(this.Model3DFilePath));
                    // Add handles to settings path
                    break;
            }
        }

        private int _dwType;
        private int _dwIndex;
        private string _szName;
        private int _dwModelType;
        private string _szPart;
        private int _bFly;
        private int _dwDistant;
        private int _bPick;
        private float _fScale;
        private int _bTrans;
        private int _bShadow;
        private int _nTextureEx;
        private int _bRenderFlag;
        private List<ModelMotion> _motions;

        public int DwType { get => this._dwType; set { if (this.DwType != value) { this._dwType = value; this.NotifyPropertyChanged(); } } }
        public int DwIndex { get => this._dwIndex; set { if (this.DwIndex != value) { this._dwIndex = value; this.NotifyPropertyChanged(); } } }
        public string SzName { get => this._szName; set { if (this.SzName != value) { this._szName = value; this.NotifyPropertyChanged(); } } }
        public int DwModelType { get => this._dwModelType; set { if (this.DwModelType != value) { this._dwModelType = value; this.NotifyPropertyChanged(); } } }
        public string SzPart { get => this._szPart; set { if (this.SzPart != value) { this._szPart = value; this.NotifyPropertyChanged(); } } }
        public int BFly { get => this._bFly; set { if (this.BFly != value) { this._bFly = value; this.NotifyPropertyChanged(); } } }
        public int DwDistant { get => this._dwDistant; set { if (this.DwDistant != value) { this._dwDistant = value; this.NotifyPropertyChanged(); } } }
        public int BPick { get => this._bPick; set { if (this.BPick != value) { this._bPick = value; this.NotifyPropertyChanged(); } } }
        public float FScale { get => this._fScale; set { if (this.FScale != value) { this._fScale = value; this.NotifyPropertyChanged(); } } }
        public int BTrans { get => this._bTrans; set { if (this.BTrans != value) { this._bTrans = value; this.NotifyPropertyChanged(); } } }
        public int BShadow { get => this._bShadow; set { if (this.BShadow != value) { this._bShadow = value; this.NotifyPropertyChanged(); } } }
        public int NTextureEx { get => this._nTextureEx; set { if (this.NTextureEx != value) { this._nTextureEx = value; this.NotifyPropertyChanged(); } } }
        public int BRenderFlag { get => this._bRenderFlag; set { if (this.BRenderFlag != value) { this._bRenderFlag = value; this.NotifyPropertyChanged(); } } }

        public List<ModelMotion> Motions { get => this._motions; private set { if (this.Motions != value) { this._motions = value; this.NotifyPropertyChanged(); } } }

        public ModelBrace Brace // Maybe we should watch for braces changes to handle refresh problems, but I'm not sure if it's necessary for now.
        {
            get => ModelsService.Instance.GetBraceByModel(this);
            set { if (this.Brace != value) { ModelsService.Instance.SetBraceToModel(this, value); this.NotifyPropertyChanged(); } }
        }

        public string Model3DFilePath
        {
            get
            {
                Settings settings = Settings.Instance;
                string modelsFolderPath = settings.ModelsFolderPath ?? settings.DefaultModelsFolderPath;

                string result = modelsFolderPath;

                if (DefinesService.Instance.Defines.TryGetValue("MODELTYPE_BILLBOARD", out int billboardModelTypeValue) && this.DwModelType == billboardModelTypeValue)
                {
                    result += this.SzName;
                    return result;
                }


                if (DefinesService.Instance.Defines.TryGetValue("OT_SFX", out int sfxObjectTypeValue) && this.DwType == sfxObjectTypeValue && this.SzName.Contains('_'))
                    result += this.SzName;

                else
                {
                    string root = Constants.ModelFilenameRoot[this.DwType];
                    result += $"{root}_{this.SzName}";
                }

                if (DefinesService.Instance.Defines.TryGetValue("MODELTYPE_SFX", out int sfxModelTypeValue) && this.DwModelType == sfxModelTypeValue)
                    result += ".o3d";
                return result;
            }
        }

        public ModelElem()
        {
            this.Motions = new List<ModelMotion>();
            Settings.Instance.PropertyChanged += this.Settings_PropertyChanged;
        }

        public void Dispose()
        {
            Settings.Instance.PropertyChanged -= this.Settings_PropertyChanged;
        }

        private void Settings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case nameof(Settings.ModelsFolderPath):
                    NotifyPropertyChanged(nameof(this.Model3DFilePath));
                    break;
            }
        }
    }
}
