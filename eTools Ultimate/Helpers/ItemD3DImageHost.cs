using eTools_Ultimate.Models.Items;
using eTools_Ultimate.Models.Models;
using eTools_Ultimate.Models.Movers;
using eTools_Ultimate.Resources;
using eTools_Ultimate.Services;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace eTools_Ultimate.Helpers
{
    [ObservableObject]
    public partial class ItemD3DImageHost(IntPtr hwnd, IStringLocalizer<Translations> localizer) : D3DImageHost(hwnd)
    {
        [ObservableProperty]
        private bool _auto3DRendering = false;

        public string? Error
        {
            get => field;
            private set
            {
                if (field != value)
                {
                    field = value;
                    OnPropertyChanged();
                }
            }
        }


        public Model? CurrentModel
        {
            get => field;
            set
            {
                if (value == field)
                    return;

                field?.PropertyChanged -= CurrentModel_PropertyChanged;

                field = value;

                OnPropertyChanged();

                Clear();

                if (value is not null)
                {
                    value.PropertyChanged += CurrentModel_PropertyChanged;

                    LoadModel();
                    SetModelTexture();
                    SetScale();
                    Zoom(720);
                }
                else
                    Error = localizer["This item has no model associated."];
            }
        }

        public string[] MaterialTextures
        {
            get;
            private set
            {
                if (value == field)
                    return;
                field = value;
                OnPropertyChanged();
            }
        } = [];

        private void CurrentModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (sender != CurrentModel) throw new InvalidOperationException("sender != CurrentModel");

            switch (e.PropertyName)
            {
                case nameof(Model.NTextureEx):
                    SetModelTexture();
                    break;
                case nameof(Model.FScale):
                    SetScale();
                    break;
                case nameof(Model.Model3DFilePath):
                    Clear();
                    LoadModel();
                    break;
            }
        }

        public void SetCurrentModel(Model? model)
        {
            if (model == CurrentModel)
                return;

            CurrentModel = model;

            Clear();

            if (model is not null)
            {
                LoadModel();

            }
        }

        private void LoadModel()
        {
            if (CurrentModel is null)
                return;

            Auto3DRendering = false;
            Error = null;
            //NativeMethods.DeleteModel(_native); // Clear the previous model if any
            //NativeMethods.DeleteReferenceModel(_native); // Clear the reference model if any
            //Render();

            if (!File.Exists(CurrentModel.Model3DFilePath))
            {
                Error = String.Format(localizer["Unable to find file: {0}"], CurrentModel.Model3DFilePath);
                return;
            }

            NativeMethods.LoadModel(_native, CurrentModel.Model3DFilePath);

            SetModelTexture();
            SetScale();

            Render();

            RefreshMaterialTextures();
        }

        private void SetModelTexture()
        {
            if (CurrentModel is null) return;

            int textureEx = CurrentModel.NTextureEx;
            NativeMethods.SetTextureEx(_native, textureEx);
            if (!Auto3DRendering)
                Render();
        }

        private void SetScale()
        {
            if (CurrentModel is null) return;

            float scale = CurrentModel.FScale;
            NativeMethods.SetScale(_native, scale);
            if (!Auto3DRendering)
                Render();
        }

        private void RefreshMaterialTextures()
        {
            int texturesLength = NativeMethods.GetMaterialTexturesSize(_native);

            List<string> textureFiles = [];
            for (int i = 0; i < texturesLength; i++)
            {
                IntPtr textureName = NativeMethods.GetMaterialTexture(_native, i);
                string? texture = Marshal.PtrToStringAnsi(textureName);
                texture = Path.GetFileNameWithoutExtension(texture);
                if (texture is not null)
                    textureFiles.Add(texture);
            }
            MaterialTextures = [.. textureFiles];
        }

        private void Clear()
        {
            DeleteModel();
            DeleteReferenceModel();
            Render();
        }

        private void DeleteModel()
        {
            NativeMethods.DeleteModel(_native);
        }

        private void DeleteReferenceModel()
        {
            NativeMethods.DeleteModel(_native);
        }
    }
}
