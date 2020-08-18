using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace webFinal
{
    public partial class Home : System.Web.UI.Page
    {
        private DatabaseHandler dh = DatabaseHandler.getInitial();
        ArrayList filteredNews = new ArrayList();
        ArrayList allNews = new ArrayList();
        ArrayList lastNews = new ArrayList();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            string category = Request.QueryString["category"];

            if(category != null)
            {
                PnlGeneral.Visible = false;
                PnlCategory.Visible = true;
                if (category == "turkiye")
                {
                    filteredNews = dh.getNewsByCategory("Türkiye");
                    lblCategory.Text = "Türkiye";
                }
                else if (category == "dunya")
                {
                    filteredNews = dh.getNewsByCategory("Dünya");
                    lblCategory.Text = "Dünya";
                }
                else if (category == "spor")
                {
                    filteredNews = dh.getNewsByCategory("Spor");
                    lblCategory.Text = "Spor";
                }
                else if (category == "ekonomi")
                {
                    filteredNews = dh.getNewsByCategory("Ekonomi");
                    lblCategory.Text = "Ekonomi";
                }
                else if (category == "saglik")
                {
                    filteredNews = dh.getNewsByCategory("Sağlık");
                    lblCategory.Text = "Sağlık";
                }
                else if (category == "gundem")
                {
                    filteredNews = dh.getNewsByCategory("Gündem");
                    lblCategory.Text = "Gündem";
                }
                else if (category == "cevre")
                {
                    filteredNews = dh.getNewsByCategory("Çevre");
                    lblCategory.Text = "Çevre";
                }
                fillCategoryNews();
            }
            else
            {
                PnlGeneral.Visible = true;
                PnlCategory.Visible = false;
                allNews = (ArrayList)Session["todayNews"];
                fillSlideBar();
                fillRightSlider();
                fillTodayNews();
                fillLastNews();
            }
        }

        protected void fillSlideBar()
        {
            int counter = 0;
            for (int i = 0; i < allNews.Count && counter < 5; i ++) 
            {
               News tempNews = (News)allNews[i];
               if(tempNews.ImageUrl != "")
                {
                    HtmlGenericControl carouselItem = new HtmlGenericControl("div");
                    carouselItem.Attributes.Add("onclick", "return routeDetail('NewsDetail.aspx" + "?title=" + tempNews.Title + "');");
                    carouselItem.Attributes.Add("style", "height:400px; width:100%;");
                    if (counter == 0)
                    {
                        carouselItem.Attributes.Add("class", "carousel-item active");
                    }
                    else
                    {
                        carouselItem.Attributes.Add("class", "carousel-item");
                    }
                    
                    PnlSlider.Controls.Add(carouselItem);

                    System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
                    img.CssClass = "d-block w-100 rounded";
                    img.Attributes.Add("style", "height: 100%; width: 100%; object-fit:contain;");
                    img.Attributes.Add("src", tempNews.ImageUrl);

                    carouselItem.Controls.Add(img);

                    HtmlGenericControl carouselCaption = new HtmlGenericControl("div");
                    carouselCaption.Attributes.Add("class", "carousel-caption d-none d-md-block");

                    carouselItem.Controls.Add(carouselCaption);

                    Label lbl = new Label();
                    lbl.CssClass = "text-warning";
                    lbl.Text = tempNews.Title;
                    lbl.Font.Size = FontUnit.XXLarge;
                    lbl.Font.Bold = true;
                    lbl.BorderColor = Color.Black;

                    carouselCaption.Controls.Add(lbl);
                    counter += 1;
                }
            }
        }

        protected void fillRightSlider()
        {
            int counter = 0;
            for (int i = 0; i < allNews.Count && counter < 4; i++)
            {
                News tempNews = (News)allNews[i];
                if (tempNews.ImageUrl != "")
                {
                    HtmlGenericControl card = new HtmlGenericControl("div");
                    card.Attributes.Add("onclick", "return routeDetail('NewsDetail.aspx" + "?title=" + tempNews.Title + "');");
                    card.Attributes.Add("style", "max-height:100px; background-color: #FFFFFF; border-radius: 0;  padding-bottom: 10px;");
                    card.Attributes.Add("class", "card");

                    PnlRight.Controls.Add(card);

                    HtmlGenericControl row = new HtmlGenericControl("div");
                    row.Attributes.Add("class", "row no-gutters");

                    card.Controls.Add(row);

                    HtmlGenericControl mdFirst = new HtmlGenericControl("div");
                    mdFirst.Attributes.Add("class", "col-md-4");

                    row.Controls.Add(mdFirst);

                    System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
                    img.Attributes.Add("style", "height:100px;width:100px;border-radius: 0");
                    img.Attributes.Add("src", tempNews.ImageUrl);

                    mdFirst.Controls.Add(img);

                    HtmlGenericControl mdSecod = new HtmlGenericControl("div");
                    mdSecod.Attributes.Add("class", "col-md-8");

                    row.Controls.Add(mdSecod);

                    HtmlGenericControl cardBody = new HtmlGenericControl("div");
                    cardBody.Attributes.Add("class", "card-body");

                    mdSecod.Controls.Add(cardBody);

                    Label lbl = new Label();
                    lbl.CssClass = "card-title";
                    lbl.Text = tempNews.Title;
                    lbl.Font.Size = FontUnit.Large;
                    lbl.Font.Bold = true;

                    cardBody.Controls.Add(lbl);

                    counter++;
                }
            }
        }

        protected void fillTodayNews()
        {
            for (int i = 0; i < allNews.Count; i++)
            {
                News tempNews = (News)allNews[i];
                DateTime today = DateTime.Today;
                if (tempNews.PubDate.Day == today.Day && tempNews.PubDate.Month == today.Month && tempNews.PubDate.Year == today.Year)
                {
                    HtmlGenericControl card = new HtmlGenericControl("div");
                    card.Attributes.Add("class", "card");
                    
                    card.Attributes.Add("onclick", "return routeDetail('NewsDetail.aspx" + "?title=" + tempNews.Title + "');");

                    PnlToday.Controls.Add(card);

                    if (tempNews.ImageUrl != "")
                    {
                        System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
                        img.CssClass = "card-img-top";
                        img.Attributes.Add("src", tempNews.ImageUrl);
                        card.Controls.Add(img);
                    }

                    HtmlGenericControl cardBody = new HtmlGenericControl("div");
                    cardBody.Attributes.Add("class", "card-body");
                    
                    card.Controls.Add(cardBody);

                    Label lbl = new Label();
                    lbl.CssClass = "card-title";
                    lbl.Text = tempNews.Title;
                    lbl.Font.Size = FontUnit.Large;
                    lbl.Font.Bold = true;
                   
                    cardBody.Controls.Add(lbl);
                }

            }

        }

        protected void fillLastNews()
        {
            lastNews = dh.getLastNews();

            for (int i = 0; i < lastNews.Count; i++) 
            {
                News tempNews = (News)lastNews[i];

                HtmlGenericControl card = new HtmlGenericControl("div");
                card.Attributes.Add("class", "card");
                
                card.Attributes.Add("onclick", "return routeDetail('NewsDetail.aspx" + "?title=" + tempNews.Title + "');");

                PnlLastNews.Controls.Add(card);

                if(tempNews.ImageUrl != "")
                {
                    System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
                    img.CssClass = "card-img-top";
                    img.Attributes.Add("src", tempNews.ImageUrl);
                    card.Controls.Add(img);
                }
               
                HtmlGenericControl cardBody = new HtmlGenericControl("div");
                cardBody.Attributes.Add("class", "card-body");
                cardBody.Attributes.Add("style", "background-color: #C50000;");

                card.Controls.Add(cardBody);

                Label lbl = new Label();
                lbl.CssClass = "card-title";
                lbl.Text = tempNews.Title;
                lbl.Font.Size = FontUnit.Large;
                lbl.Font.Bold = true;
                lbl.ForeColor = Color.White;
               
                cardBody.Controls.Add(lbl);
            }

        }

        protected void fillCategoryNews()
        {
            for (int i = 0; i < filteredNews.Count; i++)
            {
                News tempNews = (News)filteredNews[i];
                DateTime today = DateTime.Today;

                HtmlGenericControl card = new HtmlGenericControl("div");
                card.Attributes.Add("class", "card");

                card.Attributes.Add("onclick", "return routeDetail('NewsDetail.aspx" + "?title=" + tempNews.Title + "');");

                PnlCategory.Controls.Add(card);

                if (tempNews.ImageUrl != "")
                {
                    System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
                    img.CssClass = "card-img-top";
                    img.Attributes.Add("src", tempNews.ImageUrl);
                    card.Controls.Add(img);
                }

                HtmlGenericControl cardBody = new HtmlGenericControl("div");
                cardBody.Attributes.Add("class", "card-body");

                card.Controls.Add(cardBody);

                Label lbl = new Label();
                lbl.CssClass = "card-title";
                lbl.Text = tempNews.Title;
                lbl.Font.Size = FontUnit.Large;
                lbl.Font.Bold = true;

                cardBody.Controls.Add(lbl);
            }
        }

    }
}