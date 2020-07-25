using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW2
{
    public class Movie
    {
        public int MovieID;
        public string Title;
        public string Writer;
        public string Director;
        public int Year;
        public string MovieUrl;
        public Movie(int MovieID, string Title, string Director,
        string Writer, int Year, string MovieUrl)
        {
            this.MovieID = MovieID;
            this.Title = Title;
            this.Director = Director;
            this.Writer = Writer;
            this.Year = Year;
            this.MovieUrl = MovieUrl;
        }
    }
}