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

namespace animacja
{
    /// <summary>
    /// Logika interakcji dla klasy SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {

        public SettingsWindow()
        {
            InitializeComponent();
            xSpeedSlider.Value = Math.Abs((double)Application.Current.Properties["xSpeed"]);

            ySpeedSlider.Value = Math.Abs((double)Application.Current.Properties["ySpeed"]);
        }

        private void SettingsCancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SettingsApplyClick(object sender, RoutedEventArgs e)
        {
            if(Math.Sign((double)Application.Current.Properties["xSpeed"]) != 0)
                Application.Current.Properties["xSpeed"] = Math.Sign((double)Application.Current.Properties["xSpeed"]) * xSpeedSlider.Value;
            else
                Application.Current.Properties["xSpeed"] = xSpeedSlider.Value;


            if (Math.Sign((double)Application.Current.Properties["ySpeed"]) != 0)
                Application.Current.Properties["ySpeed"] = Math.Sign((double)Application.Current.Properties["ySpeed"]) * ySpeedSlider.Value;
            else
                Application.Current.Properties["ySpeed"] = ySpeedSlider.Value;

            this.Close();
        }
    }
}
