using System.Windows;
using System.Windows.Input;
using System.IO;
using ProSwapperFOV.Properties;
namespace ProSwapperFOV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            //Get's user's GameUserSettings.ini
            if (!File.Exists(Settings.Default.GameDir))
            {
                Settings.Default.GameDir = GameFileEditor.fndir;
                Settings.Default.Save();
            }
            fndir.Text = Settings.Default.GameDir;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private void FOVSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            valuelbl.Content = "Value: " + (int)FOVSlider.Value;
        }

        private void setfov_Click(object sender, RoutedEventArgs e)
        {
            int fovval = (int)FOVSlider.Value;
            GameFileEditor.SetRes(fovval.ToString(), "1920");
            MessageBox.Show("Set FOV to " + fovval, "Pro Swapper FOV", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void setresbutton_Click(object sender, RoutedEventArgs e)
        {
            GameFileEditor.SetRes(xres.Text, yres.Text);
            MessageBox.Show("Set Resolution to " + xres.Text + " x " + yres.Text, "Pro Swapper Resolution Changer", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
