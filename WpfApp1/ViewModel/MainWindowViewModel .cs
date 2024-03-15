using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private MediaPlayerModel _player;

        public MainWindowViewModel()
        {
            _player = new MediaPlayerModel();
            PlayCommand = new RelayCommand(Play);
            PauseCommand = new RelayCommand(Pause);
            StopCommand = new RelayCommand(Stop);
            OpenCommand = new RelayCommand(Open);
            RewindCommand = new RelayCommand(Rewind);
            FastForwardCommand = new RelayCommand(FastForward);
        }
        public string MediaFilePath
        {
            get { return _player.MediaFilePath; }
            set
            {
                _player.MediaFilePath = value;
                OnPropertyChanged(nameof(MediaFilePath));
            }
        }
        public TimeSpan Position
        {
            get { return _player.Position; }
            set
            {
                _player.Position = value;
                OnPropertyChanged(nameof(Position));
            }
        }
        public TimeSpan Duration
        {
            get { return _player.Duration; }
            set
            {
                _player.Duration = value;
                OnPropertyChanged(nameof(Duration));
            }
        }
        public bool IsPlaying
        {
            get { return _player.IsPlaying; }
            set
            {
                _player.IsPlaying = value;
                OnPropertyChanged(nameof(IsPlaying));
            }
        }
   

        public ICommand PlayCommand { get; set; } 
        public ICommand PauseCommand { get; set; }
        public ICommand StopCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand RewCommand { get; set; }
        public ICommand FfwCommand { get; set; }

        private void Play(object parametr)
        {
            
        }
        private void Pause(object parametr) { }
        private void Stop(object parametr) { }
        private void Open(object parametr) { }
        private void Rew(object parametr) { }
        private void Ffw(object parametr) { }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
