using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class MediaPlayerModel
    {
        public string MediaFilePath { get; set; }
        public double Volume { get; set; }
        public TimeSpan Position { get; set; }
        public TimeSpan Duration { get; set; }
        public bool IsPlaying { get; set; }
    }
}
