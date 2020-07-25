using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HW2
{
    public partial class MovieInfo : System.Web.UI.Page
    {
        String movie_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UserInfo"];
            ArrayList All_MovieIndices = new ArrayList();
            All_MovieIndices = (ArrayList)Session["Info_Movie"];

            lbl_add_info.Visible = false;

            if (All_MovieIndices == null)
            {
                Response.Redirect("Default.aspx");
            }

            if (cookie != null)
            {

                movie_id = Request.QueryString["id"];
                Panel_User_Info.Visible = true;
                lbl_user_name.Text = cookie["first_name"] + " " + cookie["last_name"];

                if (movie_id != null && All_MovieIndices!= null)
                {
                    try
                    {
                        int i = System.Convert.ToInt32(movie_id);
                        
                        if(i<=All_MovieIndices.Count)
                        {
                            Movie chosen_movie = (Movie)All_MovieIndices[i-1];
                            Panel_Info.Visible = false;
                            Panel_Movie.Visible = true;

                            ImageButton_movie.ImageUrl = chosen_movie.MovieUrl;
                            lbl_title.Text = chosen_movie.Title;
                            lbl_writer_black.Text = chosen_movie.Writer;
                            lbl_director_black.Text = chosen_movie.Director;
                            lbl_year_black.Text = chosen_movie.Year.ToString();
                        }

                        else
                        {
                            Panel_Info.Visible = true;
                            Panel_Movie.Visible = false;
                            hlbl_link.Visible = false;
                            Panel_User_Info.Visible = false;
                            lbl_info.Text = "Please specify suitable movie id!";
                        }

                    }
                    catch (FormatException)
                    {
                        hlbl_link.Visible = false;
                        Panel_Movie.Visible = false;
                        Panel_User_Info.Visible = false;
                        lbl_info.Text = "Please specify suitable movie id!";
                    }
                    
                }
                else
                {
                    hlbl_link.Visible = false;
                    Panel_Movie.Visible = false;
                    Panel_User_Info.Visible = false;
                    lbl_info.Text = "Please specify movie id!";
                }

            }
            else
            {
                Panel_Info.Visible = true;
                Panel_Movie.Visible = false;
                Panel_User_Info.Visible = false;
            }

        }

        protected void btn_add_cart_Click(object sender, EventArgs e)
        {
            ArrayList SelectedMovieIndices = (ArrayList)Session["CartInfo"];
            lbl_add_info.Visible = true;

            if (SelectedMovieIndices != null)
            {
                if(SelectedMovieIndices.Contains(movie_id))
                {
                    lbl_add_info.Text = "Movie is already in the shopping cart";
                }
                else
                {
                    SelectedMovieIndices.Add(movie_id);
                    lbl_add_info.Text = "Movie was added to the shopping cart";
                }
            }
            else
            {
                SelectedMovieIndices = new ArrayList();
                SelectedMovieIndices.Add(movie_id);
                Session["CartInfo"] = SelectedMovieIndices;
                lbl_add_info.Text = "Movie was added to the shopping cart";
            }
        }

        protected void btn_go_to_cart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }

        protected void btn_go_default_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btn_log_out_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("UserInfo");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            Response.Redirect("Default.aspx");
        }
    }
}