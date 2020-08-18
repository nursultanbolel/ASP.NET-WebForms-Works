using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webFinal
{
    public partial class NewsDetail : System.Web.UI.Page
    {
        DatabaseHandler dh = DatabaseHandler.getInitial();
        protected void Page_Load(object sender, EventArgs e)
        {
            News selectedNews = dh.getNewsByTitle(Request.QueryString["title"]);
            lblCategory.Text = selectedNews.Category;
            lblTitle.Text = selectedNews.Title;
            lblDate.Text = selectedNews.PubDate.Day.ToString() + '.' + selectedNews.PubDate.Month.ToString() + '.' + selectedNews.PubDate.Year.ToString();
            lblDescription.Text = selectedNews.Description;
            HLNewLink.NavigateUrl = selectedNews.NewLink;

            if(selectedNews.ImageUrl != "")
            {
                imgNew.Visible = true;
                imgNew.Attributes.Add("src", selectedNews.ImageUrl);
            }
            else
            {
                imgNew.Visible = false;
            }
        }
    }
}