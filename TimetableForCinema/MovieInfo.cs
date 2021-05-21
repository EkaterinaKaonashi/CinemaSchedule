using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableForCinema
{
    public class MovieInfo
    {
        public MovieInfo()
        {

        }
        public MovieInfo(string name,int duration)
        {
            nameOfMovie = name;
            durationMovie = duration;
        }
        public string nameOfMovie { get; set; }
        public int durationMovie { get; set; }
        
        public TimeSpan startMovie { get; set; }
        public TimeSpan endMovie { get; set; }

        public MovieInfo addMovie()
        {
            return new MovieInfo();
        }
    }
}
