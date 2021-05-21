using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableForCinema
{
    public class Schedule
    {
        int durationOfHall { get; set; }
        int fillTime = 0;
        TimeSpan startCinemaWork = new TimeSpan(10, 00, 00);

        //TimeSpan startMovie = new TimeSpan();
        //TimeSpan endMovie = new TimeSpan();

        TimeSpan endCinemaWork = new TimeSpan(24, 00, 00);

        int s = 90;

        List<MovieInfo> gotMovieList = new List<MovieInfo>();

        List<MovieInfo> orderOfMovies = new List<MovieInfo>();


        //List<MovieInfo> schedule = new List<MovieInfo>();

        List<MovieInfo> tmpList = new List<MovieInfo>();


        MovieInfo ShortestMovie;
        public Schedule()
        {

        }
        public Schedule(List<MovieInfo> listMovies)
        {
            durationOfHall = 840;
            gotMovieList = listMovies;


            ArrangeMovies();
            
        }
        public List<MovieInfo> SetTime()
        {
            List<MovieInfo> schedule = new List<MovieInfo>();
            for (int i = 0; i < orderOfMovies.Count; i++)
            {

                if (schedule.Count == 0)
                {

                    schedule.Add(orderOfMovies[i]);
                    schedule[i].startMovie = new TimeSpan(10, 00, 00);
                    schedule[i].endMovie = schedule[i].startMovie + TimeSpan.FromMinutes(schedule[i].durationMovie);
                }
                else
                {
                    schedule.Add(orderOfMovies[i]);
                    schedule[i].startMovie = schedule[i - 1].endMovie;
                    schedule[i].endMovie = schedule[i].startMovie + TimeSpan.FromMinutes(schedule[i].durationMovie);
                }


            }
            return schedule;

        }


        public List<MovieInfo> ArrangeMovies()
        {
            //if (fillTime == 0)
            //{
            //    tmpList.AddRange(gotMovieList);
            //}

            //int indexOfShortesMovie = FindSchortedMovie();
            //if (fillTime <= durationOfHall)
            //{
            //    if (fillTime + ShortestMovie.durationMovie > durationOfHall)
            //    {
            //        return orderOfMovies;
            //    }

            //    AddShortestMovie();

            //    tmpList.RemoveAt(indexOfShortesMovie);
            //    if (tmpList.Count == 0)
            //    {
            //        tmpList.AddRange(gotMovieList);

            //    }
            //    ArrangeMovies();
            //}
            //return orderOfMovies;
            if (fillTime == 0)
            {
                foreach (var movie in gotMovieList)
                {
                    orderOfMovies.Add(new MovieInfo(movie.nameOfMovie, movie.durationMovie));
                    fillTime += movie.durationMovie;
                    tmpList.AddRange(gotMovieList);
                }


            }
            int indexOfShortesMovie = FindSchortedMovie();
            //if (fillTime <= durationOfHall)
            //{
            //    if (fillTime + ShortestMovie.durationMovie > durationOfHall)
            //    {
            //        return orderOfMovies;
            //    }

            //    AddShortestMovie();
            //    if (tmpList.Count == 0)
            //    {
            //        tmpList.AddRange(gotMovieList);

            //    }

            //}
            FillAvailableTime();

            return orderOfMovies;

        }
        private List<MovieInfo> FillAvailableTime()
        {
            if(ShortestMovie.durationMovie + fillTime <= durationOfHall)
            {
                AddShortestMovie();
                if (ShortestMovie.durationMovie + fillTime <= durationOfHall)
                {
                    FillAvailableTime();
                }
            }
            return orderOfMovies;
        }

        private void AddShortestMovie()
        {
            orderOfMovies.Add(new MovieInfo(ShortestMovie.nameOfMovie, ShortestMovie.durationMovie));
            fillTime += ShortestMovie.durationMovie;
        }

        private int FindSchortedMovie()
        {
            ShortestMovie = tmpList.OrderBy(s => s.durationMovie).FirstOrDefault();
            int indexOfShortesMovie = tmpList.IndexOf(ShortestMovie);
            return indexOfShortesMovie;
        }
    }


}
