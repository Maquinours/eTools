//using eTools_Ultimate.Models.Items;
//using eTools_Ultimate.Models.Models;
//using eTools_Ultimate.Models.Movers;
//using eTools_Ultimate.Resources;
//using eTools_Ultimate.Services;
//using Microsoft.Extensions.Localization;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Runtime.InteropServices;
//using System.Text;

//namespace eTools_Ultimate.Helpers
//{
//    public enum RenderingItem
//    {
//        Loot,
//        MalePart,
//        FemalePart
//    }

//    [ObservableObject]
//    public partial class ItemD3DImageHost(IntPtr hwnd, IStringLocalizer<Translations> localizer) : D3DImageHost(hwnd)
//    {
//        [ObservableProperty]
//        private bool _auto3DRendering = false;

//        public string? Error
//        {
//            get => field;
//            private set
//            {
//                if (field != value)
//                {
//                    field = value;
//                    OnPropertyChanged();
//                }
//            }
//        }

//        public Item? CurrentItem
//        {
//            get;
//            set
//            {
//                if (value == field)
//                    return;

//                field?.PropertyChanged -= CurrentItem_PropertyChanged;
//                field = value;
//                field?.PropertyChanged += CurrentItem_PropertyChanged;

//                CurrentModel = value?.Model;
//            }
//        }

//        public Model? CurrentModel
//        {
//            get => field;
//            private set
//            {
//                if (value == field)
//                    return;

//                field?.PropertyChanged -= CurrentModel_PropertyChanged;

//                field = value;

//                OnPropertyChanged();

//                Clear();

//                RenderingItem = RenderingItem.Loot;

//                if (value is not null)
//                {
//                    value.PropertyChanged += CurrentModel_PropertyChanged;

//                    LoadModel();
//                }
//                else
//                    Error = localizer["This item has no model associated."];
//            }
//        }

//        public RenderingItem RenderingItem
//        {
//            get;
//            set
//            {
//                if (value == field)
//                    return;
//                field = value;
//                OnPropertyChanged();

//                Clear();
//                LoadModel();
//            }
//        } = RenderingItem.Loot;

//        public string[] MaterialTextures
//        {
//            get;
//            private set
//            {
//                if (value == field)
//                    return;
//                field = value;
//                OnPropertyChanged();
//            }
//        } = [];

//        private void CurrentItem_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
//        {
//            if (sender != CurrentItem) throw new InvalidOperationException("sender != CurrentItem");
//            if (CurrentItem == null) throw new InvalidOperationException("CurrentItem == null");

//            switch (e.PropertyName)
//            {
//                case nameof(Item.Model):
//                    CurrentModel = CurrentItem.Model;
//                    break;
//            }
//        }

//        private void CurrentModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
//        {
//            if (sender != CurrentModel) throw new InvalidOperationException("sender != CurrentModel");

//            switch (e.PropertyName)
//            {
//                case nameof(Model.NTextureEx):
//                    SetModelTexture();
//                    break;
//                case nameof(Model.FScale):
//                    SetScale();
//                    break;
//                case nameof(Model.Model3DFilePath):
//                    if (RenderingItem == RenderingItem.Loot)
//                    {
//                        Clear();
//                        LoadModel();
//                    }
//                    break;
//                case nameof(Model.MalePartModel3DFilePath):
//                    if (RenderingItem == RenderingItem.MalePart)
//                    {
//                        Clear();
//                        LoadModel();
//                    }
//                    break;
//                case nameof(Model.FemalePartModel3DFilePath):
//                    if (RenderingItem == RenderingItem.FemalePart)
//                    {
//                        Clear();
//                        LoadModel();
//                    }
//                    break;
//            }
//        }

//        private void LoadModel()
//        {
//            if (CurrentModel is null)
//                return;

//            Auto3DRendering = false;
//            Error = null;
//            //NativeMethods.DeleteModel(_native); // Clear the previous model if any
//            //NativeMethods.DeleteReferenceModel(_native); // Clear the reference model if any
//            //Render();

//            if (!File.Exists(CurrentModel.Model3DFilePath))
//            {
//                Error = String.Format(localizer["Unable to find file: {0}"], CurrentModel.Model3DFilePath);
//                return;
//            }

//            string filePath = RenderingItem switch
//            {
//                RenderingItem.Loot => CurrentModel.Model3DFilePath,
//                RenderingItem.MalePart => CurrentModel.MalePartModel3DFilePath,
//                RenderingItem.FemalePart => CurrentModel.FemalePartModel3DFilePath,
//                _ => throw new NotImplementedException(),
//            };

//            NativeMethods.LoadModel(_native, filePath);

//            SetModelTexture();
//            SetScale();

//            Zoom(720);

//            Render();

//            RefreshMaterialTextures();
//        }

//        private void SetModelTexture()
//        {
//            if (CurrentModel is null) return;

//            int textureEx = CurrentModel.NTextureEx;
//            NativeMethods.SetTextureEx(_native, textureEx);
//            if (!Auto3DRendering)
//                Render();
//        }

//        private void SetScale()
//        {
//            if (CurrentModel is null) return;

//            float scale = CurrentModel.FScale;
//            NativeMethods.SetScale(_native, scale);
//            if (!Auto3DRendering)
//                Render();
//        }

//        private void RefreshMaterialTextures()
//        {
//            MaterialTextures = [];

//            if(RenderingItem != RenderingItem.Loot)
//                return;

//            int texturesLength = NativeMethods.GetMaterialTexturesSize(_native);

//            List<string> textureFiles = [];
//            for (int i = 0; i < texturesLength; i++)
//            {
//                IntPtr textureName = NativeMethods.GetMaterialTexture(_native, i);
//                string? texture = Marshal.PtrToStringAnsi(textureName);
//                texture = Path.GetFileNameWithoutExtension(texture);
//                if (texture is not null)
//                    textureFiles.Add(texture);
//            }
//            MaterialTextures = [.. textureFiles];
//        }

//        private void Clear()
//        {
//            DeleteModel();
//            DeleteReferenceModel();
//            Render();
//        }

//        private void DeleteModel()
//        {
//            NativeMethods.DeleteModel(_native);
//        }

//        private void DeleteReferenceModel()
//        {
//            NativeMethods.DeleteModel(_native);
//        }
//    }
//}
