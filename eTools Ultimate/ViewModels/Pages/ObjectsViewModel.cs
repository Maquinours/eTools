using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;

namespace eTools_Ultimate.ViewModels.Pages
{
    public class ObjectsViewModel : INotifyPropertyChanged
    {
        private bool _isInitialized = false;
        private ObservableCollection<FolderNode> _folderHierarchy;
        private int _objectId;
        private string _objectModel;
        private string _objectType = "MODELTYPE_MESH";
        private double _scale = 1.0;
        private bool _hasCollision;
        private bool _hasModelViewerError;
        private string _modelViewerError;
        private ImageSource _modelPreview;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<FolderNode> FolderHierarchy
        {
            get => _folderHierarchy;
            set
            {
                _folderHierarchy = value;
                OnPropertyChanged(nameof(FolderHierarchy));
            }
        }

        public int ObjectId
        {
            get => _objectId;
            set
            {
                _objectId = value;
                OnPropertyChanged(nameof(ObjectId));
            }
        }

        public string ObjectModel
        {
            get => _objectModel;
            set
            {
                _objectModel = value;
                OnPropertyChanged(nameof(ObjectModel));
            }
        }

        public string ObjectType
        {
            get => _objectType;
            set
            {
                _objectType = value;
                OnPropertyChanged(nameof(ObjectType));
            }
        }

        public double Scale
        {
            get => _scale;
            set
            {
                _scale = value;
                OnPropertyChanged(nameof(Scale));
            }
        }

        public bool HasCollision
        {
            get => _hasCollision;
            set
            {
                _hasCollision = value;
                OnPropertyChanged(nameof(HasCollision));
            }
        }

        public bool HasModelViewerError
        {
            get => _hasModelViewerError;
            set
            {
                _hasModelViewerError = value;
                OnPropertyChanged(nameof(HasModelViewerError));
            }
        }

        public string ModelViewerError
        {
            get => _modelViewerError;
            set
            {
                _modelViewerError = value;
                OnPropertyChanged(nameof(ModelViewerError));
            }
        }

        public ImageSource ModelPreview
        {
            get => _modelPreview;
            set
            {
                _modelPreview = value;
                OnPropertyChanged(nameof(ModelPreview));
            }
        }

        public ICommand SelectModelCommand { get; }
        public ICommand IncreaseScaleCommand { get; }
        public ICommand DecreaseScaleCommand { get; }

        public ObjectsViewModel()
        {
            SelectModelCommand = new RelayCommand(OnSelectModel);
            IncreaseScaleCommand = new RelayCommand(OnIncreaseScale);
            DecreaseScaleCommand = new RelayCommand(OnDecreaseScale);
            InitializeViewModel();
        }

        private void InitializeViewModel()
        {
            if (_isInitialized) return;

            // Initialize folder hierarchy
            _folderHierarchy = new ObservableCollection<FolderNode>();
            LoadFolderHierarchy();

            _isInitialized = true;
        }

        private void LoadFolderHierarchy()
        {
            // Example data
            var root = new FolderNode 
            { 
                Name = "Objects",
                FrameCount = 100,
                Children = new ObservableCollection<FolderNode>
                {
                    new FolderNode { Name = "Category 1", FrameCount = 30 },
                    new FolderNode { Name = "Category 2", FrameCount = 70 }
                }
            };

            FolderHierarchy = new ObservableCollection<FolderNode> { root };
        }

        private void OnSelectModel()
        {
            // TODO: Implement model selection dialog
        }

        private void OnIncreaseScale()
        {
            if (Scale < 100)
            {
                Scale += 0.1;
                Scale = Math.Round(Scale, 1);
            }
        }

        private void OnDecreaseScale()
        {
            if (Scale > 0.1)
            {
                Scale -= 0.1;
                Scale = Math.Round(Scale, 1);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class FolderNode : INotifyPropertyChanged
    {
        private string _name;
        private int _frameCount;
        private ObservableCollection<FolderNode> _children;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int FrameCount
        {
            get => _frameCount;
            set
            {
                _frameCount = value;
                OnPropertyChanged(nameof(FrameCount));
            }
        }

        public ObservableCollection<FolderNode> Children
        {
            get => _children;
            set
            {
                _children = value;
                OnPropertyChanged(nameof(Children));
            }
        }

        public FolderNode()
        {
            Children = new ObservableCollection<FolderNode>();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }
}