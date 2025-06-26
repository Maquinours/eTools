using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Wpf.Ui.Controls;

namespace eTools_Ultimate.Helpers
{
    public static class ImagesHelper
    {
        public static ImageIcon CreateHighQualityImageIcon(string relativePath, int width, int height)
        {
            BitmapImage bmp = new();
            bmp.BeginInit();
            bmp.UriSource = new Uri($"pack://application:,,,/{relativePath}", UriKind.Absolute);
            bmp.CacheOption = BitmapCacheOption.OnLoad;
            bmp.EndInit();

            var image = new ImageIcon
            {
                Source = bmp,
                Width = width,
                Height = height
            };
            RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.HighQuality);

            return image;
        }
    }
}
