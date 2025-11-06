using eTools_Ultimate.Helpers;
using eTools_Ultimate.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace eTools_Ultimate.Models
{
    public interface IModelItem { }

    public class ModelMotionProp(uint iMotion, string szMotion)
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private uint _iMotion = iMotion;
        private string _szMotion = szMotion;

        public uint IMotion { get => this._iMotion; set => SetValue(ref _iMotion, value); }
        public string SzMotion { get => this._szMotion; set => SetValue(ref _szMotion, value); }

        private bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            if (!typeof(T).IsValueType && typeof(T) != typeof(string)) throw new Exception($"Motion SetValue with not safe to assign directly property {propertyName}");
            T old = field;
            field = value;
            this.NotifyPropertyChanged(propertyName, old, value);
            return true;
        }
        private void NotifyPropertyChanged<T>(string propertyName, T oldValue, T newValue)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedExtendedEventArgs(propertyName, oldValue, newValue));
        }
    }

    public class ModelMotion : INotifyPropertyChanged
    {
        private readonly ModelMotionProp _prop;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ModelMotionProp Prop => _prop;

        public string MotionTypeIdentifier
        {
            get => Script.NumberToString(Prop.IMotion, App.Services.GetRequiredService<DefinesService>().ReversedMotionTypeDefines);
            set
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    Prop.IMotion = (uint)val;
            }
        }

        public ModelMotion(ModelMotionProp prop)
        {
            _prop = prop;

            Prop.PropertyChanged += Prop_PropertyChanged;
        }

        private void Prop_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(sender != Prop) 
                throw new InvalidOperationException("ModelMotion::Prop_PropertyChanged exception : sender is not Prop");

            switch (e.PropertyName)
            {
                case nameof(Prop.IMotion):
                    this.NotifyPropertyChanged(nameof(MotionTypeIdentifier));
                    break;
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            
        }
    }

    public class ModelBraceProp(string szName)
    {
        private string _szName = szName;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string SzName { get => _szName; set => SetValue(ref _szName, value); }

        protected bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            if (!typeof(T).IsValueType && typeof(T) != typeof(string)) throw new Exception($"ModelBraceProp::SetValue exception : field is not safe to assign directly property {propertyName}");
            T old = field;
            field = value;
            this.NotifyPropertyChanged(propertyName, old, value);
            return true;
        }
        private void NotifyPropertyChanged<T>(string propertyName, T oldValue, T newValue)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedExtendedEventArgs(propertyName, oldValue, newValue));
        }
    }

    public class ModelBrace(ModelBraceProp prop, IEnumerable<IModelItem> children) : IModelItem, IDisposable
    {
        protected readonly ModelBraceProp _prop = prop;
        private readonly ObservableCollection<IModelItem> _children = [..children];

        public ModelBraceProp Prop => _prop;
        public ObservableCollection<IModelItem> Children => _children;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

    public class MainModelBraceProp(string szName, uint iType) : ModelBraceProp(szName)
    {
        private uint _iType = iType;

        public uint IType { get => this._iType; set => SetValue(ref _iType, value); }
    }

    public class MainModelBrace(MainModelBraceProp prop, IEnumerable<IModelItem> children) : ModelBrace(prop, children)
    {
        private readonly new MainModelBraceProp _prop = prop;

        public new MainModelBraceProp Prop => _prop;
    }

    public class ModelProp(uint dwType, uint dwIndex, string szName, uint dwModelType, string szPart, byte bFly, byte dwDistant, byte bPick, float fScale, byte bTrans, byte bShadow, int nTextureEx, byte bRenderFlag) : INotifyPropertyChanged
    {
        private uint _dwType = dwType;
        private uint _dwIndex = dwIndex;
        private string _szName = szName;
        private uint _dwModelType = dwModelType;
        private string _szPart = szPart;
        private byte _bFly = bFly;
        private byte _dwDistant = dwDistant;
        private byte _bPick = bPick;
        private float _fScale = fScale;
        private byte _bTrans = bTrans;
        private byte _bShadow = bShadow;
        private int _nTextureEx = nTextureEx;
        private byte _bRenderFlag = bRenderFlag;

        public event PropertyChangedEventHandler? PropertyChanged;

        public uint DwType { get => this._dwType; set => SetValue(ref _dwType, value); }
        public uint DwIndex { get => this._dwIndex; set => SetValue(ref _dwIndex, value); }
        public string SzName { get => this._szName; set => SetValue(ref _szName, value); }
        public uint DwModelType { get => this._dwModelType; set => SetValue(ref _dwModelType, value); }
        public string SzPart { get => this._szPart; set => SetValue(ref _szPart, value); }
        public byte BFly { get => this._bFly; set => SetValue(ref _bFly, value); }
        public byte DwDistant { get => this._dwDistant; set => SetValue(ref _dwDistant, value); }
        public byte BPick { get => this._bPick; set => SetValue(ref _bPick, value); }
        public float FScale { get => this._fScale; set => SetValue(ref _fScale, value); }
        public byte BTrans { get => this._bTrans; set => SetValue(ref _bTrans, value); }
        public byte BShadow { get => this._bShadow; set => SetValue(ref _bShadow, value); }
        public int NTextureEx { get => this._nTextureEx; set => SetValue(ref _nTextureEx, value); }
        public byte BRenderFlag { get => this._bRenderFlag; set => SetValue(ref _bRenderFlag, value); }

        private bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            if (!typeof(T).IsValueType && typeof(T) != typeof(string)) throw new Exception($"Motion SetValue with not safe to assign directly property {propertyName}");
            T old = field;
            field = value;
            this.NotifyPropertyChanged(propertyName, old, value);
            return true;
        }
        private void NotifyPropertyChanged<T>(string propertyName, T oldValue, T newValue)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedExtendedEventArgs(propertyName, oldValue, newValue));
        }
    }

    public class Model : IModelItem, INotifyPropertyChanged, IDisposable
    {
        private readonly ModelProp _prop;
        private readonly ObservableCollection<ModelMotion> _motions;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ModelProp Prop => _prop;
        public ObservableCollection<ModelMotion> Motions => _motions;

        public ModelBrace Brace // Maybe we should watch for braces changes to handle refresh problems, but I'm not sure if it's necessary for now.
        {
            get => App.Services.GetRequiredService<ModelsService>().GetBraceByModel(this);
            set { if (this.Brace != value) { App.Services.GetRequiredService<ModelsService>().SetBraceToModel(this, value); this.NotifyPropertyChanged(); } }
        }

        public string Model3DFilePath
        {
            get
            {
                Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;
                IDictionary<string, int> defines = App.Services.GetRequiredService<DefinesService>().Defines;

                string modelsFolderPath = settings.ModelsFolderPath ?? settings.DefaultModelsFolderPath;

                string result = modelsFolderPath;

                if (defines.TryGetValue("MODELTYPE_BILLBOARD", out int billboardModelTypeValue) && Prop.DwModelType == billboardModelTypeValue)
                {
                    result += Prop.SzName;
                    return result;
                }


                if (defines.TryGetValue("OT_SFX", out int sfxObjectTypeValue) && Prop.DwType == sfxObjectTypeValue && Prop.SzName.Contains('_'))
                    result += Prop.SzName;

                else
                {
                    string root = Constants.ModelFilenameRoot[Prop.DwType];
                    result += $"{root}_{Prop.SzName}";
                }

                if (defines.TryGetValue("MODELTYPE_SFX", out int sfxModelTypeValue) && Prop.DwModelType != sfxModelTypeValue)
                    result += ".o3d";
                return result;
            }
        }

        public string TypeIdentifier => Script.NumberToString(Prop.DwType, App.Services.GetRequiredService<DefinesService>().ReversedObjectTypeDefines);

        public string Identifier
        {
            get
            {
                DefinesService definesService = App.Services.GetRequiredService<DefinesService>();

                IDictionary<int, string>? reversedDefines = TypeIdentifier switch
                {
                    "OT_CTRL" => definesService.ReversedControlDefines,
                    "OT_SFX" => definesService.ReversedSfxDefines,
                    "OT_ITEM" => definesService.ReversedItemDefines,
                    "OT_MOVER" => definesService.ReversedMoverDefines,
                    "OT_REGION" => definesService.ReversedRegionDefines,
                    "OT_SHIP" => null,
                    "OT_PATH" => definesService.ReversedRegionDefines,
                    _ => null,
                };

                if (reversedDefines is not null)
                    return Script.NumberToString(Prop.DwIndex, reversedDefines);

                return Prop.DwIndex.ToString(CultureInfo.InvariantCulture);
            }
        }

        public string ModelTypeIdentifier => Script.NumberToString(Prop.DwModelType, App.Services.GetRequiredService<DefinesService>().ReversedModelTypeDefines);

        public string DistantIdentifier => Script.NumberToString(Prop.DwDistant, App.Services.GetRequiredService<DefinesService>().ReversedModelDistantDefines);
        public string TextureExIdentifier => Script.NumberToString(Prop.NTextureEx, App.Services.GetRequiredService<DefinesService>().ReversedAdditionalTextureDefines);

        public ICollectionView MotionsView => CollectionViewSource.GetDefaultView(Motions);

        public Model(ModelProp prop, IEnumerable<ModelMotion> motions)
        {
            _prop = prop;
            _motions = [..motions];

            Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;

            Prop.PropertyChanged += Prop_PropertyChanged;
            settings.PropertyChanged += this.Settings_PropertyChanged;
        }

        public void Dispose()
        {
            Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;

            Prop.PropertyChanged -= Prop_PropertyChanged;
            settings.PropertyChanged -= this.Settings_PropertyChanged;

            GC.SuppressFinalize(this);
        }

        private void Prop_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(sender != Prop) throw new InvalidOperationException("Model::Prop_PropertyChanged exception : sender is not Prop");

            switch (e.PropertyName)
            {
                case nameof(Prop.DwType):
                case nameof(Prop.DwModelType):
                case nameof(Prop.SzName):
                    NotifyPropertyChanged(nameof(Model3DFilePath));
                    // Add handles to settings path
                    break;
            }
        }

        private void Settings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Settings.ModelsFolderPath):
                    NotifyPropertyChanged(nameof(Model3DFilePath));
                    break;
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    //public class ModelElem : INotifyPropertyChanged, IDisposable
    //{
    //    public event PropertyChangedEventHandler? PropertyChanged;

    //    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    //        switch(propertyName)
    //        {
    //            case nameof(this.DwType):
    //            case nameof(this.DwModelType):
    //            case nameof(this.SzName):
    //                NotifyPropertyChanged(nameof(this.Model3DFilePath));
    //                // Add handles to settings path
    //                break;
    //        }
    //    }

    //    private int _dwType;
    //    private int _dwIndex;
    //    private string _szName;
    //    private int _dwModelType;
    //    private string _szPart;
    //    private int _bFly;
    //    private int _dwDistant;
    //    private int _bPick;
    //    private float _fScale;
    //    private int _bTrans;
    //    private int _bShadow;
    //    private int _nTextureEx;
    //    private int _bRenderFlag;
    //    private ObservableCollection<ModelMotion> _motions;

    //    public int DwType { get => this._dwType; set { if (this.DwType != value) { this._dwType = value; this.NotifyPropertyChanged(); } } }
    //    public int DwIndex { get => this._dwIndex; set { if (this.DwIndex != value) { this._dwIndex = value; this.NotifyPropertyChanged(); } } }
    //    public string SzName { get => this._szName; set { if (this.SzName != value) { this._szName = value; this.NotifyPropertyChanged(); } } }
    //    public int DwModelType { get => this._dwModelType; set { if (this.DwModelType != value) { this._dwModelType = value; this.NotifyPropertyChanged(); } } }
    //    public string SzPart { get => this._szPart; set { if (this.SzPart != value) { this._szPart = value; this.NotifyPropertyChanged(); } } }
    //    public int BFly { get => this._bFly; set { if (this.BFly != value) { this._bFly = value; this.NotifyPropertyChanged(); } } }
    //    public int DwDistant { get => this._dwDistant; set { if (this.DwDistant != value) { this._dwDistant = value; this.NotifyPropertyChanged(); } } }
    //    public int BPick { get => this._bPick; set { if (this.BPick != value) { this._bPick = value; this.NotifyPropertyChanged(); } } }
    //    public float FScale { get => this._fScale; set { if (this.FScale != value) { this._fScale = value; this.NotifyPropertyChanged(); } } }
    //    public int BTrans { get => this._bTrans; set { if (this.BTrans != value) { this._bTrans = value; this.NotifyPropertyChanged(); } } }
    //    public int BShadow { get => this._bShadow; set { if (this.BShadow != value) { this._bShadow = value; this.NotifyPropertyChanged(); } } }
    //    public int NTextureEx { get => this._nTextureEx; set { if (this.NTextureEx != value) { this._nTextureEx = value; this.NotifyPropertyChanged(); } } }
    //    public int BRenderFlag { get => this._bRenderFlag; set { if (this.BRenderFlag != value) { this._bRenderFlag = value; this.NotifyPropertyChanged(); } } }

    //    public ObservableCollection<ModelMotion> Motions { get => this._motions; private set { if (this.Motions != value) { this._motions = value; this.NotifyPropertyChanged(); } } }

    //    public ICollectionView MotionsView => CollectionViewSource.GetDefaultView(Motions);

    //    public ModelElem()
    //    {
    //        Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;

    //        this.Motions = [];
    //        settings.PropertyChanged += this.Settings_PropertyChanged;
    //    }

    //    public void Dispose()
    //    {
    //        Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;

    //        settings.PropertyChanged -= this.Settings_PropertyChanged;
    //    }

    //    private void Settings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    //    {
    //        switch(e.PropertyName)
    //        {
    //            case nameof(Settings.ModelsFolderPath):
    //                NotifyPropertyChanged(nameof(this.Model3DFilePath));
    //                break;
    //        }
    //    }
    //}
}
