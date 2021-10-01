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

using System.Windows.Threading;
using System.Timers;




namespace animacja
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static System.Timers.Timer _timer;

        private RotateTransform trRotation;
        private TransformGroup trGroup;

        void SetTimer()
        {
            _timer = new System.Timers.Timer(20);
            _timer.Elapsed += TimerOnElapsed;
            _timer.AutoReset = true;
            _timer.Enabled = true;
            _timer.Start();
        }


        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.BeginInvoke((Action)delegate ()
            {
                if ((double)Application.Current.Properties["xSpeed"] > 0)
                {
                    if (Canvas.GetLeft(Rect) + Rect.ActualWidth + (double)Application.Current.Properties["xSpeed"] > myCanvas.ActualWidth)
                    {
                        Canvas.SetLeft(Rect, myCanvas.ActualWidth - Rect.ActualWidth);
                        Application.Current.Properties["xSpeed"] = -(double)Application.Current.Properties["xSpeed"];
                    }
                    else Canvas.SetLeft(Rect, Math.Abs(Canvas.GetLeft(Rect) + (double)Application.Current.Properties["xSpeed"]));
                }
                else
                {
                    if (Canvas.GetLeft(Rect) < -(double)Application.Current.Properties["xSpeed"])
                    {
                        Canvas.SetLeft(Rect, 0);
                        Application.Current.Properties["xSpeed"] = -(double)Application.Current.Properties["xSpeed"];
                    }
                    else Canvas.SetLeft(Rect, Math.Abs(Canvas.GetLeft(Rect) + (double)Application.Current.Properties["xSpeed"]));
                }



                if ((double)Application.Current.Properties["ySpeed"] > 0)
                {
                    if (Canvas.GetTop(Rect) + Rect.ActualHeight + (double)Application.Current.Properties["ySpeed"] > myCanvas.ActualHeight)
                    {
                        Canvas.SetTop(Rect, myCanvas.ActualHeight - Rect.ActualHeight);
                        Application.Current.Properties["ySpeed"] = -(double)Application.Current.Properties["ySpeed"];
                    }
                    else Canvas.SetTop(Rect, Math.Abs(Canvas.GetTop(Rect) + (double)Application.Current.Properties["ySpeed"]));
                }
                else
                {
                    if (Canvas.GetTop(Rect) < -(double)Application.Current.Properties["ySpeed"])
                    {
                        Canvas.SetTop(Rect, 0);
                        Application.Current.Properties["ySpeed"] = -(double)Application.Current.Properties["ySpeed"];
                    }
                    else Canvas.SetTop(Rect, Math.Abs(Canvas.GetTop(Rect) + (double)Application.Current.Properties["ySpeed"]));
                }


                trRotation.Angle = trRotation.Angle + 0.456*(double)Application.Current.Properties["xSpeed"] + 0.567*(double)Application.Current.Properties["ySpeed"];

                this.MinHeight = Canvas.GetTop(Rect) + Rect.ActualHeight + 55;
                this.MinWidth = Canvas.GetLeft(Rect) + Rect.ActualWidth + 13;
            });
        }


        public MainWindow()
        {
            InitializeComponent();

            Application.Current.Properties["xSpeed"] = (double)1;
            Application.Current.Properties["ySpeed"] = (double)2;
            SetTimer();

            trRotation = new RotateTransform(0);
            trGroup = new TransformGroup();
            trGroup.Children.Add(trRotation);

            Rect.RenderTransform = trGroup;

        }

        private void SETTINGS_Click(object sender, RoutedEventArgs e)
        {
            var window = new SettingsWindow();
            window.DataContext = this;

            window.Owner = this;
            window.ShowDialog();
        }

        private void EXIT_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ABOUT_Click(object sender, RoutedEventArgs e)
        {
            var window = new AboutWindow();

            window.Owner = this;
            window.ShowDialog();
        }
    }
}
