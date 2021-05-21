using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;


namespace TimetableForCinema.Tests
{
    public class Tests
    {
        [TestCase]
       public void ArrangeMoviesTest(/*MovieInfo[] listMovies,*/ int countOfMovie, MovieInfo[] current)
       {
            List<MovieInfo> listMovies = MovieInfoMock.GetMock();
            

            
            Schedule actual = new Schedule(listMovies);
            
            Assert.AreEqual(actual,expected);

       }
    }
    public static class MovieInfoMock
    {
        public static List<MovieInfo> GetMock()
        {
            List<MovieInfo> result = new List<MovieInfo>();
            result.Add(new MovieInfo("qqq", 120));
            result.Add(new MovieInfo("www", 60));
            result.Add(new MovieInfo("eee", 90));

            
            return result;
        }
    }
}