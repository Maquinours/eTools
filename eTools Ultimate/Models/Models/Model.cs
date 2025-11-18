using eTools_Ultimate.Helpers;
using eTools_Ultimate.Services;
using Microsoft.Extensions.DependencyInjection;
using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Xml.Linq;

namespace eTools_Ultimate.Models.Models
{
    public class Model : IModelItem, INotifyPropertyChanged, IDisposable
    {
        #region Fields
        private uint _dwType;
        private uint _dwIndex;
        private string _szName;
        private uint _dwModelType;
        private string _szPart;
        private byte _bFly;
        private byte _dwDistant;
        private byte _bPick;
        private float _fScale;
        private byte _bTrans;
        private byte _bShadow;
        private int _nTextureEx;
        private byte _bRenderFlag;
        private readonly ObservableCollection<ModelMotion> _motions;
        #endregion

        #region Events
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Properties
        #region Backing properties
        public uint DwType { get => _dwType; set => SetValue(ref _dwType, value); }
        public uint DwIndex { get => _dwIndex; set => SetValue(ref _dwIndex, value); }
        public string SzName { get => _szName; set => SetValue(ref _szName, value); }
        public uint DwModelType { get => _dwModelType; set => SetValue(ref _dwModelType, value); }
        public string SzPart { get => _szPart; set => SetValue(ref _szPart, value); }
        public byte BFly { get => _bFly; set => SetValue(ref _bFly, value); }
        public byte DwDistant { get => _dwDistant; set => SetValue(ref _dwDistant, value); }
        public byte BPick { get => _bPick; set => SetValue(ref _bPick, value); }
        public float FScale { get => _fScale; set => SetValue(ref _fScale, value); }
        public byte BTrans { get => _bTrans; set => SetValue(ref _bTrans, value); }
        public byte BShadow { get => _bShadow; set => SetValue(ref _bShadow, value); }
        public int NTextureEx { get => _nTextureEx; set => SetValue(ref _nTextureEx, value); }
        public byte BRenderFlag { get => _bRenderFlag; set => SetValue(ref _bRenderFlag, value); }
        public ObservableCollection<ModelMotion> Motions => _motions;
        #endregion

        #region Calculated properties
        public ModelBrace Brace // Maybe we should watch for braces changes to handle refresh problems, but I'm not sure if it's necessary for now.
        {
            get => App.Services.GetRequiredService<ModelsService>().GetBraceByModel(this);
            set { if (Brace != value) { App.Services.GetRequiredService<ModelsService>().SetBraceToModel(this, value); } }
        }

        public string Model3DFileName
        {
            get
            {
                IDictionary<string, int> defines = App.Services.GetRequiredService<DefinesService>().Defines;

                string result = string.Empty;

                if (defines.TryGetValue("MODELTYPE_BILLBOARD", out int billboardModelTypeValue) && DwModelType == billboardModelTypeValue)
                {
                    result += SzName;
                    return result;
                }

                if (defines.TryGetValue("OT_SFX", out int sfxObjectTypeValue) && DwType == sfxObjectTypeValue && SzName.Contains('_'))
                    result += SzName;

                else
                {
                    string root = Constants.ModelFilenameRoot[DwType];
                    result += $"{root}_{SzName}";
                }

                if (defines.TryGetValue("MODELTYPE_SFX", out int sfxModelTypeValue) && DwModelType != sfxModelTypeValue)
                    result += ".o3d";
                return result;
            }
        }

        public string Model3DFilePath
        {
            get
            {
                Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;

                string modelsFolderPath = settings.ModelsFolderPath ?? settings.DefaultModelsFolderPath;

                return Path.Combine(modelsFolderPath, Model3DFileName);
            }
        }

        public string TypeIdentifier => Script.NumberToString(DwType, App.Services.GetRequiredService<DefinesService>().ReversedObjectTypeDefines);

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
                    return Script.NumberToString(DwIndex, reversedDefines);

                return DwIndex.ToString(CultureInfo.InvariantCulture);
            }
        }

        public string ModelTypeIdentifier => Script.NumberToString(DwModelType, App.Services.GetRequiredService<DefinesService>().ReversedModelTypeDefines);

        public string DistantIdentifier => Script.NumberToString(DwDistant, App.Services.GetRequiredService<DefinesService>().ReversedModelDistantDefines);
        public string TextureExIdentifier => Script.NumberToString(NTextureEx, App.Services.GetRequiredService<DefinesService>().ReversedAdditionalTextureDefines);

        public ICollectionView MotionsView => CollectionViewSource.GetDefaultView(Motions);
        #endregion
        #endregion

        #region Constructors
        public Model(uint dwType, uint dwIndex, string szName, uint dwModelType, string szPart, byte bFly, byte dwDistant, byte bPick, float fScale, byte bTrans, byte bShadow, int nTextureEx, byte bRenderFlag, IEnumerable<ModelMotion> motions)
        {
            _dwType = dwType;
            _dwIndex = dwIndex;
            _szName = szName;
            _dwModelType = dwModelType;
            _szPart = szPart;
            _bFly = bFly;
            _dwDistant = dwDistant;
            _bPick = bPick;
            _fScale = fScale;
            _bTrans = bTrans;
            _bShadow = bShadow;
            _nTextureEx = nTextureEx;
            _bRenderFlag = bRenderFlag;
            _motions = [.. motions];

            Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;

            PropertyChanged += Model_PropertyChanged;
            settings.PropertyChanged += Settings_PropertyChanged;
        }
        #endregion

        #region Methods
        #region Public methods
        public void Dispose()
        {
            Settings settings = App.Services.GetRequiredService<SettingsService>().Settings;

            PropertyChanged -= Model_PropertyChanged;
            settings.PropertyChanged -= Settings_PropertyChanged;

            foreach(ModelMotion motion in Motions)
                motion.Dispose();

            Motions.Clear();

            GC.SuppressFinalize(this);
        }
        #endregion

        #region Private methods
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void NotifyPropertyChanged<T>(string propertyName, T oldValue, T newValue)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedExtendedEventArgs(propertyName, oldValue, newValue));
        }

        private bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            if (!typeof(T).IsValueType && typeof(T) != typeof(string)) throw new Exception($"Motion SetValue with not safe to assign directly property {propertyName}");
            T old = field;
            field = value;
            NotifyPropertyChanged(propertyName, old, value);
            return true;
        }

        #region Event handlers
        private void Model_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender != this) throw new InvalidOperationException("Model::Model_PropertyChanged exception : sender is not this");

            switch (e.PropertyName)
            {
                case nameof(DwType):
                case nameof(DwModelType):
                case nameof(SzName):
                    NotifyPropertyChanged(nameof(Model3DFileName));
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
        #endregion
        #endregion
        #endregion
    }
}
