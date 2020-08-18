using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webFinal
{
    public class News
    {
        public int NewsID;
        public string Title;
        public string Description;
        public string Category;
        public string Author;
        public string NewLink;
        public DateTime PubDate;
        public string ImageUrl;

        public News(int NewsID , string Title, string Description, string Category, string Author, string NewLink, DateTime PubDate, string ImageUrl)
        {
            this.NewsID = NewsID;
            this.Title = Title;
            this.Description = Description;
            this.Category = Category;
            this.Author = Author;
            this.NewLink = NewLink;
            this.PubDate = PubDate;
            this.ImageUrl = ImageUrl;
        }

        public News()
        {

        }

    }
}