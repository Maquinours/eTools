using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;

namespace eTools_Ultimate.Models.Motions
{
    public class Motion : INotifyPropertyChanged
    {
        private int _motionId;
        private string _motionIdKey;
        private string _motionIcon;
        private string _playIdKey;
        private string _inGameName;
        private string _description;
        private BitmapImage _motionIconImage;

        /// <summary>
        /// Unique identifier for the motion
        /// </summary>
        public int MotionId
        {
            get => _motionId;
            set
            {
                if (_motionId != value)
                {
                    _motionId = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Internal key identifier for the motion
        /// </summary>
        public string MotionIdKey
        {
            get => _motionIdKey;
            set
            {
                if (_motionIdKey != value)
                {
                    _motionIdKey = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Path to the icon image
        /// </summary>
        public string MotionIcon
        {
            get => _motionIcon;
            set
            {
                if (_motionIcon != value)
                {
                    _motionIcon = value;
                    OnPropertyChanged();
                    LoadIconImage();
                }
            }
        }

        /// <summary>
        /// Key used to trigger the motion animation
        /// </summary>
        public string PlayIdKey
        {
            get => _playIdKey;
            set
            {
                if (_playIdKey != value)
                {
                    _playIdKey = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Name displayed in game
        /// </summary>
        public string InGameName
        {
            get => _inGameName;
            set
            {
                if (_inGameName != value)
                {
                    _inGameName = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Description of the motion
        /// </summary>
        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Image for the motion icon
        /// </summary>
        public BitmapImage MotionIconImage
        {
            get => _motionIconImage;
            set
            {
                if (_motionIconImage != value)
                {
                    _motionIconImage = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Loads the icon image from the file path
        /// </summary>
        private void LoadIconImage()
        {
            if (string.IsNullOrEmpty(MotionIcon))
                return;

            try
            {
                if (File.Exists(MotionIcon))
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.UriSource = new Uri(MotionIcon, UriKind.Absolute);
                    bitmap.EndInit();
                    MotionIconImage = bitmap;
                }
                else
                {
                    // Default placeholder image could be set here
                    MotionIconImage = null;
                }
            }
            catch (Exception)
            {
                // Log exception
                MotionIconImage = null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 