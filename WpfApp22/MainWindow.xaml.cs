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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace WpfApp22
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void OpenImageFile()
        {
            var dlg = new OpenFileDialog();
            dlg.Title = "Select an image";
            dlg.Filter = "Image file|*.gif;*.png;*.jpeg;*.jpg;*.bmp|All files|*.*";

            if (dlg.ShowDialog() == true)
            {
                var window = new ImageWindow();
                if (window.SetImage(dlg.FileName))
                // if (window.SetBinding(dlg.FileName))
                {
                    window.Show();
                }
            }
        }

        private void Open_OnClick(object sender, RoutedEventArgs e)
        {
            OpenImageFile();
        }

        private void CloseAll_OnClick(object sender, RoutedEventArgs e)
        {
            CloseSubWindows();
        }

        private void CloseSubWindows()
        {
            foreach (Window w in App.Current.Windows)
            {
                if (w != this)
                {
                    w.Close();
                }
            }
        }
        
        private void

        private void MainWindow_OnClosed(object sender, EventArgs e)
        {
            CloseSubWindows();
        }
    }
}
