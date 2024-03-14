using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool mediaPlayerIsPlaying = false;
        private bool userIsDraggingSlider = false;
        public MainWindow()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            InitializeComponent();
            
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if ((ME.Source != null) && (ME.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
            {
                sliProgress.Minimum = 0;
                sliProgress.Maximum = ME.NaturalDuration.TimeSpan.TotalSeconds;
                sliProgress.Value = ME.Position.TotalSeconds;
            }
        }
      
        private void Play_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (ME != null) && (ME.Source != null);
        }

        private void Play_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ME.Play();
            mediaPlayerIsPlaying = true;
        }
       

        //}
        private void Open_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.mp3;*.mpg;*.mpeg)|*.mp3;*.mpg;*.mpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
                ME.Source = new Uri(openFileDialog.FileName);
        }

      

        private void Pause_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = mediaPlayerIsPlaying;
        }

        private void Pause_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ME.Pause();
        }

        private void Stop_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = mediaPlayerIsPlaying;
        }

        private void Stop_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ME.Stop();
            mediaPlayerIsPlaying = false;
        }

        //exit
        private void B4_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //volumeSlider
        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ME != null)
            {
                ME.Volume = volumeSlider.Value;

                // Добавьте следующую строку для удостоверения воспроизведения после изменения громкости
                if (ME.LoadedBehavior == MediaState.Pause)
                {
                    ME.Play();
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if ((ME.Source != null) && (ME.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
            {
                sliProgress.Minimum = 0;
                sliProgress.Maximum = ME.NaturalDuration.TimeSpan.TotalSeconds;
                sliProgress.Value = ME.Position.TotalSeconds;
            }
        }


        private void Canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            double delta = (e.Delta > 0) ? 0.1 : -0.1;
           ME.Volume += delta;

            double newVolume = ME.Volume * 100; 
            volumeSlider.Value = Math.Min(Math.Max(newVolume, volumeSlider.Minimum), volumeSlider.Maximum);
        }



        private void sliProgress_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            userIsDraggingSlider = false;
            ME.Position = TimeSpan.FromSeconds(sliProgress.Value);
        }
        private void sliProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblProgressStatus.Text = TimeSpan.FromSeconds(sliProgress.Value).ToString(@"hh\:mm\:ss");
        }


        //browse
        private void B5_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog fd = new()
                {
                    Filter = "MP3 Files (*.mp3)|*.mp3|MP4 File (*.mp4)|*.mp4|3GP File (*.3gp)|*.3gp|Audio File (*.wma)|*.wma|MOV File (*.mov)|*.mov|AVI File (*.avi)|*.avi|Flash Video(*.flv)|*.flv|Video File (*.wmv)|*.wmv|MPEG-2 File (*.mpeg)|*.mpeg|WebM Video (*.webm)|*.webm|All files (*.*)|*.*",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                };
                fd.ShowDialog();
                string filename = fd.FileName;
                if (filename != "")
                {
                    tb.Text = filename;
                    Uri u = new(filename);
                    ME.Source = u;
                    ME.Volume = 100.5;
                    MediaState opt=  MediaState.Play;
                    ME.LoadedBehavior= opt;
                }
                else
                {
                    MessageBox.Show("NO selection", "Empty");
                }
            }
            catch (Exception em)
            {
                Console.WriteLine("Error Massage: " + em.Message);
            }

        }
        
        readonly string videoURL = @"H:\\Віталій\\WPF\\d3\\Start.mp4 ";

        private void Window_loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Uri obj= new(videoURL);
                ME.Source= obj;
                MediaState opt = MediaState.Play;
                ME.LoadedBehavior= opt;

            }   
            catch(Exception ex)
            {
                Console.WriteLine("Error Massage: "+ex.Message);
            }

        }

        private void sliProgress_DragStarted(object sender, DragStartedEventArgs e)
        {
            userIsDraggingSlider = true;

        }

        private void ShowAboutWindow_Click(object sender, RoutedEventArgs e)
        {
           
                AboutWindow aboutWindow = new AboutWindow();
                aboutWindow.ShowDialog();
            


        }
    }
}