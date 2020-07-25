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
    public partial class Cart : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList SelectedMovieIndices = (ArrayList)Session["CartInfo"];

            HttpCookie cookie = Request.Cookies["UserInfo"];


            if (cookie != null)
            {

                if (SelectedMovieIndices == null || SelectedMovieIndices.Count == 0)
                {
                    Panel_User_Info.Visible = false;
                    Panel_Cart.Visible = false;
                    Panel_Info.Visible = true;
                    lbl_info.Text = "You're cart is empty! Return to the ";
                    hlbl_link.Text = "Main Page";
                    hlbl_link.NavigateUrl = "~/Default.aspx";
                }
                else
                {
                    Panel_Cart.Visible = true;
                    Panel_User_Info.Visible = true;
                    Panel_Info.Visible = false;
                    lbl_user_name.Text = cookie["first_name"] + " " + cookie["last_name"];
                    Show_Cart();
                }

            }
            else
            {
                Panel_Info.Visible = true;
                Panel_Cart.Visible = false;
                Panel_User_Info.Visible = false;
                lbl_info.Text = "You are not loged please ";
                hlbl_link.Text = "loging!";
                hlbl_link.NavigateUrl = "~/Login.aspx";
            }
        }

        public void Show_Cart()
        {
            ArrayList SelectedMovieIndices = (ArrayList)Session["CartInfo"];

            int count = SelectedMovieIndices.Count;

            for (int i = 0; i < count; i++)
            {
                Movie temp = Find_Movie(System.Convert.ToInt32(SelectedMovieIndices[i]));
                Add_Movie_Cart(temp, i);
            }
        }

        public void Add_Movie_Cart(Movie movie,int array_seq)
        {
            System.Web.UI.HtmlControls.HtmlTableRow r = new System.Web.UI.HtmlControls.HtmlTableRow();
            System.Web.UI.HtmlControls.HtmlTableCell c1 = new System.Web.UI.HtmlControls.HtmlTableCell();

            HtmlGenericControl figure = new HtmlGenericControl("figure");
            figure.Attributes.Add("class", "media");

            HtmlGenericControl div_img_wrap = new HtmlGenericControl("div");
            div_img_wrap.Attributes.Add("class", "img-wrap");

            Image cell_image = new Image();
            cell_image.ImageUrl = movie.MovieUrl;
            cell_image.CssClass = "img-thumbnail img-sm";
            cell_image.Width = 90;
            cell_image.Height = 120;
            div_img_wrap.Controls.Add(cell_image);

            HtmlGenericControl div_media_body = new HtmlGenericControl("div");
            div_media_body.Attributes.Add("class", "media-body");

            Label cell_label_title = new Label();
            cell_label_title.Text = movie.Title;
            cell_label_title.CssClass = "title text-truncate";
            div_media_body.Controls.Add(cell_label_title);

            figure.Controls.Add(div_img_wrap);
            figure.Controls.Add(div_media_body);

            c1.Controls.Add(figure);

            r.Cells.Add(c1);

            System.Web.UI.HtmlControls.HtmlTableCell c2 = new System.Web.UI.HtmlControls.HtmlTableCell();

            HtmlGenericControl div_price_wrap_1 = new HtmlGenericControl("div");
            div_price_wrap_1.Attributes.Add("class", "price-wrap");

            Label cell_label_writer = new Label();
            cell_label_writer.Text = movie.Writer;
            cell_label_writer.CssClass = "title text-truncate";
            div_price_wrap_1.Controls.Add(cell_label_writer);

            c2.Controls.Add(div_price_wrap_1);

            r.Cells.Add(c2);

            System.Web.UI.HtmlControls.HtmlTableCell c3 = new System.Web.UI.HtmlControls.HtmlTableCell();

            HtmlGenericControl div_price_wrap_2 = new HtmlGenericControl("div");
            div_price_wrap_2.Attributes.Add("class", "price-wrap");

            Label cell_label_director = new Label();
            cell_label_director.Text = movie.Director;
            cell_label_director.CssClass = "title text-truncate";
            div_price_wrap_2.Controls.Add(cell_label_director);

            c3.Controls.Add(div_price_wrap_2);

            r.Cells.Add(c3);

            System.Web.UI.HtmlControls.HtmlTableCell c4 = new System.Web.UI.HtmlControls.HtmlTableCell();

            HtmlGenericControl div_price_wrap_3 = new HtmlGenericControl("div");
            div_price_wrap_3.Attributes.Add("class", "price-wrap");

            Label cell_label_year = new Label();
            cell_label_year.Text = movie.Year.ToString();
            cell_label_year.CssClass = "title text-truncate";
            div_price_wrap_3.Controls.Add(cell_label_year);

            c4.Controls.Add(div_price_wrap_3);

            r.Cells.Add(c4);

            System.Web.UI.HtmlControls.HtmlTableCell c5 = new System.Web.UI.HtmlControls.HtmlTableCell();

            HtmlGenericControl div_price_wrap_4 = new HtmlGenericControl("div");
            div_price_wrap_4.Attributes.Add("class", "price-wrap text-right");

            Button cell_delete_button = new Button();
            cell_delete_button.Text = "Remove";
            cell_delete_button.CssClass = "btn btn-outline-danger";
            cell_delete_button.ID = "Button" + array_seq.ToString();
            cell_delete_button.Click += btn_delete_Click;
            div_price_wrap_4.Controls.Add(cell_delete_button);

            c5.Controls.Add(div_price_wrap_4);

            r.Cells.Add(c5);

            Panel_element.Controls.Add(r);

            
            //HtmlGenericControl div_go_default = new HtmlGenericControl("div");
            //Button btn_go_default = new Button();
            //btn_go_default.Text = "Return To Main Page";
            //btn_go_default.ID = "btn_go_default";
            //btn_go_default.CssClass = "btn btn-outline-info btn-lg btn-block";
            //btn_go_default.Click += btn_go_default_Click;


            //div_go_default.Controls.Add(btn_go_default);

            //Panel_Cart.Controls.Add(div_go_default);

        }

        public Movie Find_Movie(int id)
        {
            ArrayList All_MovieIndices = (ArrayList)Session["Info_Movie"];

            Movie temp = new Movie(-1, "", "", "", -1, "");
            int count = All_MovieIndices.Count;

            for(int i=0;i<count;i++)
            {
                temp = (Movie)All_MovieIndices[i];

                if(id == temp.MovieID)
                {
                    return temp;
                }
            }
            return temp;
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            ArrayList SelectedMovieIndices = (ArrayList)Session["CartInfo"];

            Button send = (Button)sender;
            String id = send.ID;
            id = id.Substring(id.Length - 1);

            SelectedMovieIndices.RemoveAt(System.Convert.ToInt32(id));
            Session["CartInfo"] = SelectedMovieIndices;

            Response.Redirect("Cart.aspx");

        }

        protected void btn_log_out_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("UserInfo");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            Response.Redirect("Default.aspx");
        }

        protected void btn_go_default_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

    }
}