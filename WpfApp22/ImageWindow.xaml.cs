using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace WpfApp22
{
    /// <summary>
    /// Interaction logic for ImageWindow.xaml
    /// </summary>
    public partial class ImageWindow : Window
    {
        public ImageWindow()
        {
            InitializeComponent();
        }

        // private void OpenImageFile()
        // {
        //     var dlg = new OpenFileDialog();
        //     dlg.Title = "Select an image";
        //     dlg.Filter = "Image file|*.gif;*.png;*.jpeg;*.jpg;*.bmp|All files|*.*";
        //
        //     if (dlg.ShowDialog() == true)
        //     {
        //         var window = new ImageWindow();
        //         if (window.SetImage(dlg.FileName))
        //         {
        //             window.Show();
        //         }
        //     }
        // }

        public bool SetImage(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return false;
            }

            var bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.UriSource = new Uri(filePath);
            bmp.EndInit();
            img.Source = bmp;
            this.Title = System.IO.Path.GetFileName(filePath);

            return true;
        }

        private void ChangeWindowSize(bool isZoom)
        {
            int plusMinus = isZoom ? 1 : -1;

            this.Height += (this.Height * 0.1) * plusMinus;
            this.Width += (this.Width * 0.1) * plusMinus;

            if (this.Height < MinHeight || this.Width < MinWidth)
            {
                this.Height = MinHeight;
                this.Width = MinWidth;
            }
        }

        private void Window_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            ChangeWindowSize(e.Delta > 0);
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void plusButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeWindowSize(true);
        }

        private void minusButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeWindowSize(false);
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
