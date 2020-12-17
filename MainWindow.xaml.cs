using System.Windows;
using System.Windows.Input;
using System.IO;
using ProSwapperFOV.Properties;
using System.Windows.Forms;
using System.Diagnostics;
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
            GameFileEditor.SetRes(fovval.ToString(), Screen.PrimaryScreen.Bounds.Width.ToString());
            System.Windows.Forms.MessageBox.Show("Set FOV to " + fovval, "Pro Swapper FOV", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void setresbutton_Click(object sender, RoutedEventArgs e)
        {
            GameFileEditor.SetRes(xres.Text, yres.Text);
            System.Windows.Forms.MessageBox.Show("Set Resolution to " + xres.Text + " x " + yres.Text, "Pro Swapper Resolution Changer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            string screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            GameFileEditor.SetRes(screenHeight, screenWidth);
            System.Windows.Forms.MessageBox.Show("Set Resolution to " + screenWidth + " x " + screenHeight, "Pro Swapper Resolution Changer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void launchfn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("com.epicgames.launcher://apps/Fortnite?action=launch&silent=false");
        }
    }
}
