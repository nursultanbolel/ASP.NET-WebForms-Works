using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HW2
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList All_MovieIndices = new ArrayList();
            
            HttpCookie cookie = Request.Cookies["UserInfo"];

            if(cookie!=null)
            {
                Panel_Info.Visible = false;
                Panel_User_Info.Visible = true;
                Panel_Movie.Visible = true;
                lbl_user_name.Text = cookie["first_name"] + " " + cookie["last_name"];

                Movie Movie_1 = new Movie(1, "The God Father", "Francis Ford Coppola", "Mario Puzo",1972, "images/the_god_father.jpg");
                Movie Movie_2 = new Movie(2, "The Shawshank Redemption", "Frank Darabont", "Stephen King", 1994, "images/the_shawshank_redemption.jpg");
                Movie Movie_3 = new Movie(3, "The Dark Night", "Christopher Nolan", "Jonathan Nolan", 2008, "images/the_dark_night.jpg");
                Movie Movie_4 = new Movie(4, "12 Angry Men", "Sidney Lumet", "Reginald Rose", 1957, "images/12_angry_men.jpg");
                Movie Movie_5 = new Movie(5, "The Lord of the Rings: The Return of the King", "Peter Jackson", "J.R.R. Tolkien", 2003, "images/the_lord_of_the_rings.jpg");

                All_MovieIndices.Add(Movie_1);
                All_MovieIndices.Add(Movie_2);
                All_MovieIndices.Add(Movie_3);
                All_MovieIndices.Add(Movie_4);
                All_MovieIndices.Add(Movie_5);
                Session["Info_Movie"] = All_MovieIndices;

                Add_Movie_Cart(Movie_1);
                Add_Movie_Cart(Movie_2);
                Add_Movie_Cart(Movie_3);
                Add_Movie_Cart(Movie_4);
                Add_Movie_Cart(Movie_5);

            }
            else
            {
                Panel_Info.Visible = true;
                Panel_User_Info.Visible = false;
                Panel_Movie.Visible = false;
            }
        }

        public void Add_Movie_Cart(Movie movie)
        {
            HtmlGenericControl div_card = new HtmlGenericControl("div");
            div_card.Attributes.Add("class", "card bg-light text-center");

            HtmlGenericControl div_card_body = new HtmlGenericControl("div");
            div_card_body.Attributes.Add("class", "card-body");

            ImageButton btn_movie = new ImageButton();
            btn_movie.ID = "ImageButton" + movie.MovieID.ToString();
            btn_movie.CssClass = "card-img-top";
            btn_movie.Click += movie_Click;
            btn_movie.Width = 300;
            btn_movie.Height = 400;
            btn_movie.ImageUrl = movie.MovieUrl;

            div_card_body.Controls.Add(btn_movie);

            div_card.Controls.Add(div_card_body);

            Panel_element.Controls.Add(div_card);
        }

        protected void btn_log_out_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("UserInfo");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            Response.Redirect("Default.aspx");
        }

        protected void img_shoping_cart_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }

        protected void movie_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton send = (ImageButton)sender;
            String id = send.ID;
            id = id.Substring(id.Length - 1);
            Response.Redirect("MovieInfo.aspx?id=" + id);
        }
    }
}