using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;
using System.Data;
using System.Web.UI.HtmlControls;

namespace HW3
{
    public partial class MainPage : System.Web.UI.Page
    {
        ArrayList seferler = new ArrayList();
        ArrayList secilen_koltuklar = new ArrayList();
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\booking.mdb");
        bool control_click_event = true;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Accordion_sefer_list.Visible = false;
                lbl_error.Visible = false;
            }
            else
            {
                Sefer sefer1 = new Sefer("26PMK26-20200328-0315", "BURSA", "İSTANBUL-AVRUPA(ESENLER)", "2020-03-28", "03:15", "62");
                Sefer sefer2 = new Sefer("26PMK27-20200328-0700", "BURSA", "İSTANBUL-AVRUPA(ESENLER)", "2020-03-28", "07:00", "62");
                Sefer sefer3 = new Sefer("26PMK28-20200328-0900", "BURSA", "İSTANBUL-AVRUPA(ESENLER)", "2020-03-28", "09:00", "62");

                seferler.Add((Sefer)sefer1);
                seferler.Add((Sefer)sefer2);
                seferler.Add((Sefer)sefer3);

                secilen_koltuklar = (ArrayList)ViewState["secilen_koltuklar"];
                
                for (int i = 0; i < seferler.Count; i++)
                {
                    fill_accord(i);
                }

            }

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ViewState["secilen_koltuklar"] = secilen_koltuklar;
            pnl_btn_odeme_adimi_1.Visible = false;
            pnl_btn_odeme_adimi_2.Visible = false;
            pnl_btn_odeme_adimi_3.Visible = false;
            if (this.IsPostBack && secilen_koltuklar.Count > 0)
            {
                string[] state_view_koltuk_array = secilen_koltuklar[0].ToString().Split('-');
                if (state_view_koltuk_array[0] == "0")
                {
                    pnl_otobus_1.Controls.Clear();
                    fill_accord(0);
                    fill_koltuk_secimi(0);
                }
                else if (state_view_koltuk_array[0] == "1")
                {
                    pnl_otobus_2.Controls.Clear();
                    fill_accord(1);
                    fill_koltuk_secimi(1);
                }
                else
                {
                    pnl_otobus_3.Controls.Clear();
                    fill_accord(2);
                    fill_koltuk_secimi(2);
                }
            }

        }

        protected void btn_sefer_sorgula_Click(object sender, EventArgs e)
        {
            if (DropDownList_kalkis.SelectedItem.Text == "" || DropDownList_varis.SelectedItem.Text == "" || txtBox_ArrivedDate.Text == "")
            {
                lbl_error.Text = "Yukarıdaki tüm alanları doldurunuz.";
                lbl_error.Visible = true;
                Accordion_sefer_list.Visible = false;
            }
            else
            {
                if (txtBox_ArrivedDate.Text != "2020-03-28")
                {
                    lbl_error.Text = "Seçtiğiniz tarihe ait seferimiz bulunmuyor.";
                    lbl_error.Visible = true;
                    Accordion_sefer_list.Visible = false;
                }
                else
                {
                    lbl_error.Visible = false;
                    Accordion_sefer_list.Visible = true;

                }
            }

        }

        protected void btn_sefer_Click(object sender, EventArgs e)
        {
            //Button btn = (Button)sender;
            //int current_sefer_id = Int32.Parse((btn.ID).Substring(btn.ID.Length - 1));

        }

        public void fill_accord(int sefer_index)
        {
            Sefer current_sefer = (Sefer)seferler[sefer_index];

            OleDbCommand cmd_bus_capacity = new OleDbCommand("select BusCapacity from Booking where BookingID =  '" + current_sefer.BookingId.ToString() + "'", conn);
            conn.Open();
            OleDbDataReader dr_bus_capacity = cmd_bus_capacity.ExecuteReader();
            dr_bus_capacity.Read();
            String sayi = dr_bus_capacity["BusCapacity"].ToString();
            int bus_capacity = Int32.Parse(sayi);
            current_sefer.set_Seat_0(bus_capacity);
            conn.Close();

            OleDbCommand cmd_seats = new OleDbCommand("select PassengerGender,PassenderSeatID from Booking where BookingID =  '" + current_sefer.BookingId.ToString() + "'", conn);
            conn.Open();
            OleDbDataReader dr_seats = cmd_seats.ExecuteReader();
            while (dr_seats.Read())
            {
                if (dr_seats["PassengerGender"].ToString() == "F")
                {
                    current_sefer.Seat[Int32.Parse(dr_seats["PassenderSeatID"].ToString()) - 1] = 1;
                }
                else
                {
                    current_sefer.Seat[Int32.Parse(dr_seats["PassenderSeatID"].ToString()) - 1] = 2;
                }
            }

            conn.Close();

            int bus_row = bus_capacity / 8;

            if (bus_row == 2)
            {
                if (sefer_index == 0)
                {
                    build_otobus_panel(pnl_otobus_1, current_sefer.Seat, sefer_index.ToString());
                }
                else if (sefer_index == 1)
                {
                    build_otobus_panel(pnl_otobus_2, current_sefer.Seat, sefer_index.ToString());
                }
                else
                {
                    build_otobus_panel(pnl_otobus_3, current_sefer.Seat, sefer_index.ToString());
                }
            }
        }

        public void fill_koltuk_secimi(int sefer_index)
        {
            for(int i=0;i<secilen_koltuklar.Count;i++)
            {
                string[] secilen_koltuk = secilen_koltuklar[i].ToString().Split('-');
                if(secilen_koltuk.Length == 3)
                {
                    Panel temp = new Panel();
                    HtmlGenericControl div_koltuk = new HtmlGenericControl("div");
                    div_koltuk.Attributes.Add("class", "text-center");

                    ImageButton img_koltuk = new ImageButton();
                    img_koltuk.Style.Add("border", "solid 3px green");
                    img_koltuk.AlternateText = (i + 1).ToString();

                    if(secilen_koltuk[2]=="F")
                    {
                        img_koltuk.ImageUrl = "~/images/f.svg";
                    }
                    else
                    {
                        img_koltuk.ImageUrl = "~/images/m.svg";
                    }

                    div_koltuk.Controls.Add(img_koltuk);

                    Label lbl_koltuk_no = new Label();
                    lbl_koltuk_no.Text = secilen_koltuk[1];

                    div_koltuk.Controls.Add(lbl_koltuk_no);
                    temp.Controls.Add(div_koltuk);

                    if (sefer_index == 0)
                    {
                        pnl_secili_koltuk_1.Controls.Add(div_koltuk);
                        pnl_btn_odeme_adimi_1.Visible = true;
                    }
                    else if (sefer_index == 1)
                    {
                        pnl_secili_koltuk_2.Controls.Add(div_koltuk);
                        pnl_btn_odeme_adimi_2.Visible = true;
                    }
                    else
                    {
                        pnl_secili_koltuk_3.Controls.Add(div_koltuk);
                        pnl_btn_odeme_adimi_3.Visible = true;
                    }
                    Session["Seferler"] = seferler;
                    Session["Secilen_Koltuklar"] = secilen_koltuklar;
                }
            }
        }

        public HtmlGenericControl create_row(int start_no, int[] seats, string sefer_no)
        {
            bool flag = false;
            bool flag_button = false;

            if (secilen_koltuklar.Count != 0)
            {
                string[] state_view_koltuk_array = secilen_koltuklar[0].ToString().Split('-');
                if (sefer_no == state_view_koltuk_array[0])
                {
                    flag = true;
                }
            }

            HtmlGenericControl div_sira = new HtmlGenericControl("div");
            div_sira.Attributes.Add("class", "row");

            for (int i = start_no; i < 16; i = i + 2)
            {
                HtmlGenericControl div_koltuk = new HtmlGenericControl("div");
                div_koltuk.Attributes.Add("class", "col-md-1 rounded");
                flag_button = false;

                if (flag == true)
                {
                    for (int k = 0; k < secilen_koltuklar.Count && flag_button == false; k++)
                    {
                        string[] state_view_koltuk_array = secilen_koltuklar[k].ToString().Split('-');
                        if (state_view_koltuk_array[1] == (i + 1).ToString())
                        {
                            flag_button = true;
                            if (state_view_koltuk_array.Length == 2)
                            {
                                ImageButton item_female = new ImageButton();
                                item_female.ID = sefer_no + "_" + (i + 1).ToString() + "_F";
                                item_female.ImageUrl = "~/images/female-icon.png";
                                item_female.Attributes.Add("width", "30");
                                item_female.Attributes.Add("height", "30");
                                item_female.Attributes.Add("class", "toggle");
                                item_female.Click += btn_select_gender_Click;

                                ImageButton item_man = new ImageButton();
                                item_man.ID = sefer_no + "_" + (i + 1).ToString() + "_M";
                                item_man.ImageUrl = "~/images/male-icon.png";
                                item_man.Attributes.Add("width", "30");
                                item_man.Attributes.Add("height", "30");
                                item_man.Attributes.Add("class", "btn-group-toggle");
                                item_man.Click += btn_select_gender_Click;

                                div_koltuk.Controls.Add(item_female);
                                div_koltuk.Controls.Add(item_man);
                                div_koltuk.Attributes.Add("class", "col-md-1 border-danger");
                                div_koltuk.Style.Add("border", "solid 3px");

                                control_click_event = false;
                            }
                            else
                            {
                                ImageButton img_koltuk = new ImageButton();
                                //img_koltuk.ID = sefer_no + "-" + (i + 1).ToString();
                                img_koltuk.Click += btn_select_Click;
                                img_koltuk.Style.Add("border", "solid 3px green");
                                img_koltuk.AlternateText = (i + 1).ToString();

                                if (state_view_koltuk_array[2] == "F")
                                {
                                    img_koltuk.ImageUrl = "~/images/f.svg";
                                    img_koltuk.ID = sefer_no + "-" + (i + 1).ToString() + "-F";
                                }
                                else
                                {
                                    img_koltuk.ImageUrl = "~/images/m.svg";
                                    img_koltuk.ID = sefer_no + "-" + (i + 1).ToString() + "-M";
                                }

                                div_koltuk.Controls.Add(img_koltuk);
                            }

                        }
                       
                    }
                }

                if (!flag_button)
                {
                    ImageButton img_koltuk = new ImageButton();
                    img_koltuk.ID = sefer_no + "-" + (i + 1).ToString();

                    if (seats[i] == 1)
                    {
                        img_koltuk.ImageUrl = "~/images/f.svg";
                    }
                    else if (seats[i] == 2)
                    {
                        img_koltuk.ImageUrl = "~/images/m.svg";
                    }
                    else
                    {
                        img_koltuk.ImageUrl = "~/images/e.svg";
                        img_koltuk.Click += btn_select_Click;
                    }

                    img_koltuk.AlternateText = (i + 1).ToString();
                    div_koltuk.Controls.Add(img_koltuk);
                }

                Label lbl_koltuk_no = new Label();
                lbl_koltuk_no.Text = (i + 1).ToString();

                div_koltuk.Controls.Add(lbl_koltuk_no);
                div_sira.Controls.Add(div_koltuk);

            }
            return div_sira;
        }

        private void btn_select_gender_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton gender = (ImageButton)sender;
            string[] btn_koltuk_array = gender.ID.Split('_');
            string seat_gender = "-"+ btn_koltuk_array[2];
            control_click_event = true;

            for (int i = 0; i < secilen_koltuklar.Count; i++)
            {
                if (secilen_koltuklar[i].ToString() == btn_koltuk_array[0] + "-" + btn_koltuk_array[1])
                {
                    secilen_koltuklar[i] = btn_koltuk_array[0] + "-" + btn_koltuk_array[1] + seat_gender;
                }
            }
        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            string[] btn_koltuk_array = btn.ID.Split('-');

            if (secilen_koltuklar.Count > 0)
            {
                string[] state_view_koltuk_array = secilen_koltuklar[0].ToString().Split('-');
                if (state_view_koltuk_array[0] != btn_koltuk_array[0])
                {
                    secilen_koltuklar.Clear();
                    if (state_view_koltuk_array[0] == "0")
                    {
                        pnl_otobus_1.Controls.Clear();
                        fill_accord(0);
                    }
                    else if (state_view_koltuk_array[0] == "1")
                    {
                        pnl_otobus_2.Controls.Clear();
                        fill_accord(1);
                    }
                    else
                    {
                        pnl_otobus_3.Controls.Clear();
                        fill_accord(2);
                    }

                }
            }

            if (control_click_event)
            {
                if (secilen_koltuklar.Contains(btn.ID))
                {
                    secilen_koltuklar.Remove(btn.ID);
                    btn.Style.Add("border", "solid 3px white");
                }
                else
                {
                    secilen_koltuklar.Add(btn.ID);
                    btn.Style.Add("border", "solid 3px green");
                }
            }
        }

        public HtmlGenericControl create_hr_line()
        {
            HtmlGenericControl div_sira = new HtmlGenericControl("div");
            div_sira.Attributes.Add("class", "row");

            HtmlGenericControl div_line = new HtmlGenericControl("div");
            div_line.Attributes.Add("class", "col-md-8 text-left");

            HtmlGenericControl hr_line = new HtmlGenericControl("hr");
            hr_line.Attributes.Add("width", "100%");
            hr_line.Attributes.Add("weight", "2px");

            div_line.Controls.Add(hr_line);

            div_sira.Controls.Add(div_line);

            return div_sira;
        }
        public HtmlGenericControl create_koridor()
        {
            HtmlGenericControl div_sira = new HtmlGenericControl("div");
            div_sira.Attributes.Add("class", "row");

            HtmlGenericControl div_koridor = new HtmlGenericControl("div");
            div_koridor.Attributes.Add("class", "col-md-8 text-center");

            Label lbl_koridor = new Label();
            lbl_koridor.Text = "KORİDOR";
            lbl_koridor.ForeColor = System.Drawing.Color.Gray;

            div_koridor.Controls.Add(lbl_koridor);
            div_sira.Controls.Add(div_koridor);

            return div_sira;
        }
        public void build_otobus_panel(Panel pnl, int[] seats,string sefer_no)
        {
            HtmlGenericControl div_sira_ilk = create_row(1, seats,sefer_no);
            pnl.Controls.Add(div_sira_ilk);

            HtmlGenericControl div_line_1 = create_hr_line();
            pnl.Controls.Add(div_line_1);

            HtmlGenericControl div_koridor = create_koridor();
            pnl.Controls.Add(div_koridor);

            HtmlGenericControl div_line_2 = create_hr_line();
            pnl.Controls.Add(div_line_2);

            HtmlGenericControl div_sira_ikinci = create_row(0, seats, sefer_no);
            pnl.Controls.Add(div_sira_ikinci);
        }

        protected void Deneme(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }
    }
}