using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using eTools_Ultimate.Models.Models;
using eTools_Ultimate.Models.Motions;
using eTools_Ultimate.Models.Movers;
using eTools_Ultimate.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace eTools_Ultimate.Views.Controls
{
    /// <summary>
    /// Logique d'interaction pour ItemModel3DViewer.xaml
    /// </summary>
    public partial class ItemModel3DViewer : UserControl, INotifyPropertyChanged
    {
        private enum RenderTarget
        {
            Loot,
            MalePart,
            FemalePart
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public static readonly DependencyProperty ModelProperty = DependencyProperty.Register(
            nameof(Model),
            typeof(Model),
            typeof(ItemModel3DViewer),
            new PropertyMetadata(null, OnModelChanged)
        );

        private RenderTarget CurrentRenderTarget
        {
            get;
            set
            {
                if (field == value) return;

                field = value;
                LoadModel();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentRenderTarget)));
            }
        } = RenderTarget.Loot;

        public Model Model
        {
            get => (Model)GetValue(ModelProperty);
            set => SetValue(ModelProperty, value);
        }

        public D3DImageHost D3DHost { get; } = new();

        public Model3DImageError? Error
        {
            get;
            private set
            {
                if (field == value) return;
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Error)));
            }
        } = null;

        public ItemModel3DViewer()
        {
            InitializeComponent();

            D3DHost.Initialized += D3DHost_Initialized;
        }

        private void LoadModel()
        {
            if (!D3DHost.IsInitialized) return;

            Error = null;
            D3DHost.Clear();

            if (Model is null)
                return;

            //if (!File.Exists(Model.Model3DFilePath))
            //{
            //    Error = String.Format(localizer["Unable to find file: {0}"], CurrentModel.Model3DFilePath);
            //    return;
            //}

            string filePath = CurrentRenderTarget switch
            {
                RenderTarget.Loot => Model.Model3DFilePath,
                RenderTarget.MalePart => Model.MalePartModel3DFilePath,
                RenderTarget.FemalePart => Model.FemalePartModel3DFilePath,
                _ => throw new InvalidOperationException("Invalid RenderTarget value"),
            };


            D3DHost.LoadModel(filePath);

            D3DHost.SetModelTexture(Model.NTextureEx);
            D3DHost.SetScale(Model.FScale);

            //Zoom(720);

            //Render();

            //RefreshMaterialTextures();
        }

        private static void OnModelChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
        {
            var control = (ItemModel3DViewer)d;
            var oldModel = e.OldValue as Model;
            var newModel = e.NewValue as Model;

            control.OnModelChanged(oldModel, newModel);
        }

        private void OnModelChanged(Model? oldModel, Model? newModel)
        {
            if (Model != newModel)
                throw new InvalidOperationException("Mover != newMover");
            if (Model.TypeIdentifier != "OT_ITEM")
                throw new InvalidOperationException("Model.TypeIdentifier != \"OT_ITEM\"");

            LoadModel();

            oldModel?.PropertyChanged -= Model_PropertyChanged;
            newModel?.PropertyChanged += Model_PropertyChanged;
        }

        private void Model_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender != Model)
                throw new InvalidOperationException("sender != Model");

            switch (e.PropertyName)
            {
                case nameof(Model.Model3DFilePath):
                    if (CurrentRenderTarget == RenderTarget.Loot)
                        LoadModel();
                    break;
                case nameof(Model.MalePartModel3DFilePath):
                    if (CurrentRenderTarget == RenderTarget.MalePart)
                        LoadModel();
                    break;
                case nameof(Model.FemalePartModel3DFilePath):
                    if (CurrentRenderTarget == RenderTarget.FemalePart)
                        LoadModel();
                    break;
                case nameof(Model.NTextureEx):
                    // TODO: check if value is possible
                    D3DHost.SetModelTexture(Model.NTextureEx);
                    break;
                case nameof(Model.FScale):
                    D3DHost.SetScale(Model.FScale);
                    break;
                case nameof(Model.TypeIdentifier):
                    if (Model.TypeIdentifier != "OT_ITEM")
                        throw new InvalidOperationException("Model.TypeIdentifier != \"OT_ITEM\"");
                    break;
            }
        }

        private void D3DHost_Initialized(object? sender, EventArgs e)
        {
            LoadModel();
        }

        [RelayCommand]
        private void RenderLootModel()
        {
            CurrentRenderTarget = RenderTarget.Loot;
        }

        [RelayCommand]
        private void RenderMalePartModel()
        {
            CurrentRenderTarget = RenderTarget.MalePart;
        }

        [RelayCommand]
        private void RenderFemalePartModel()
        {
            CurrentRenderTarget = RenderTarget.FemalePart;
        }
    }
}
