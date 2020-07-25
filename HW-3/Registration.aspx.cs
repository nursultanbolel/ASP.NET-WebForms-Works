using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HW3
{
    public partial class Registration : System.Web.UI.Page
    {
        ArrayList seferler = new ArrayList();
        ArrayList secilen_koltuklar = new ArrayList();
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\booking.mdb");
        protected void Page_Load(object sender, EventArgs e)
        {
            seferler = (ArrayList)Session["Seferler"];
            secilen_koltuklar = (ArrayList)Session["Secilen_Koltuklar"];

            if(secilen_koltuklar == null)
            {
                Response.Redirect("MainPage.aspx");
            }

            string[] secilen_sefer = secilen_koltuklar[0].ToString().Split('-');
            Sefer current_sefer = (Sefer)seferler[Int32.Parse(secilen_sefer[0])];

            if (!this.IsPostBack)
            {
                lbl_tarih.Text = lbl_tarih.Text + current_sefer.Date;
                lbl_kalkis.Text = lbl_kalkis.Text + current_sefer.From;
                lbl_varis.Text = lbl_varis.Text + current_sefer.To;
                lbl_saat.Text = lbl_saat.Text + current_sefer.Hour;
            }

            for (int i = 0; i < secilen_koltuklar.Count; i++)
            {
                string[] secilen_koltuk = secilen_koltuklar[i].ToString().Split('-');

                HtmlGenericControl div_card = new HtmlGenericControl("div");
                div_card.Attributes.Add("class", "card border-light");
                div_card.Attributes.Add("style", "border-width: 3px;");

                HtmlGenericControl div_card_body = new HtmlGenericControl("div");
                div_card_body.Attributes.Add("class", "card-body");

                HtmlGenericControl div_row = new HtmlGenericControl("div");
                div_row.Attributes.Add("class", "row");

                HtmlGenericControl div_col_1 = new HtmlGenericControl("div");
                div_col_1.Attributes.Add("class", "col-md-1");

                ImageButton img_btn = new ImageButton();
                if (secilen_koltuk[2] == "F")
                {
                    img_btn.ImageUrl = "~/images/f.svg";
                }
                else
                {
                    img_btn.ImageUrl = "~/images/m.svg";
                }

                Label lbl_koltuk_no = new Label();
                lbl_koltuk_no.Text = secilen_koltuk[1];

                div_col_1.Controls.Add(img_btn);

                div_col_1.Controls.Add(new Literal() {Text = "<hr/>" });

                div_col_1.Controls.Add(lbl_koltuk_no);

                HtmlGenericControl div_col_2 = new HtmlGenericControl("div");
                div_col_2.Attributes.Add("class", "col-md-2");

                TextBox txt_box_name = new TextBox();
                txt_box_name.ID = "txt_box_name_"+i.ToString();
                txt_box_name.Attributes.Add("class", "form-control");
                txt_box_name.Attributes.Add("placeholder", "Ad");
                txt_box_name.Attributes.Add("type", "text");
                div_col_2.Controls.Add(txt_box_name);

                HtmlGenericControl div_col_3 = new HtmlGenericControl("div");
                div_col_3.Attributes.Add("class", "col-md-2");

                TextBox txt_box_surname = new TextBox();
                txt_box_surname.ID = "txt_box_surname_" + i.ToString();
                txt_box_surname.Attributes.Add("class", "form-control");
                txt_box_surname.Attributes.Add("placeholder", "Soyad");
                txt_box_surname.Attributes.Add("type", "text");
                div_col_3.Controls.Add(txt_box_surname);

                HtmlGenericControl div_col_4 = new HtmlGenericControl("div");
                div_col_4.Attributes.Add("class", "col-md-2");

                TextBox txt_box_phone = new TextBox();
                txt_box_phone.ID = "txt_box_phone_" + i.ToString();
                txt_box_phone.Attributes.Add("class", "form-control");
                txt_box_phone.Attributes.Add("placeholder", "500-000-00-00");
                txt_box_phone.Attributes.Add("pattern", "[0-9]{3}-[0-9]{3}-[0-9]{2}-[0-9]{2}");
                txt_box_phone.Attributes.Add("title", "Telefon numarası 500-000-00-00 bu düzene uymalıdır. ");
                txt_box_phone.Attributes.Add("type", "tel");
                div_col_4.Controls.Add(txt_box_phone);

                HtmlGenericControl div_col_5 = new HtmlGenericControl("div");
                div_col_5.Attributes.Add("class", "col-md-2");

                TextBox txt_box_email = new TextBox();
                txt_box_email.ID = "txt_box_email_" + i.ToString();
                txt_box_email.Attributes.Add("class", "form-control");
                txt_box_email.Attributes.Add("placeholder", "Email");
                txt_box_email.Attributes.Add("type", "text");
                div_col_5.Controls.Add(txt_box_email);

                HtmlGenericControl div_col_6 = new HtmlGenericControl("div");
                div_col_6.Attributes.Add("class", "col-md-2");

                TextBox txt_box_tc = new TextBox();
                txt_box_tc.ID = "txt_box_tc_" + i.ToString();
                txt_box_tc.Attributes.Add("class", "form-control");
                txt_box_tc.Attributes.Add("placeholder", "TC");
                txt_box_tc.Attributes.Add("type", "number");
                txt_box_tc.Attributes.Add("pattern", "[0-9]{11}");
                txt_box_tc.Attributes.Add("title", "TC 11 haneli sayı olmalıdır.");
                txt_box_tc.Attributes.Add("type", "tel");
                div_col_6.Controls.Add(txt_box_tc);

                HtmlGenericControl div_col_7 = new HtmlGenericControl("div");
                div_col_7.Attributes.Add("class", "col-md-1 right");

                Button btn_register = new Button();
                btn_register.ID = "btn_register_" + i.ToString();
                btn_register.Attributes.Add("class", "btn btn-danger");
                btn_register.Text = "Register";
                div_col_7.Controls.Add(btn_register);
                btn_register.Click += Btn_register_Click;

                Label lbl_error = new Label();
                lbl_error.ID = "lbl_error_"+i.ToString();
                lbl_error.Visible = false;
                lbl_error.Attributes.Add("class", "text-danger");

                div_row.Controls.Add(div_col_1);
                div_row.Controls.Add(div_col_2);
                div_row.Controls.Add(div_col_3);
                div_row.Controls.Add(div_col_4);
                div_row.Controls.Add(div_col_5);
                div_row.Controls.Add(div_col_6);
                div_row.Controls.Add(div_col_7);
                div_row.Controls.Add(lbl_error);
                div_card_body.Controls.Add(div_row);
                div_card.Controls.Add(div_card_body);
                pnl_list.Controls.Add(div_card);
            }

        }

        private void Btn_register_Click(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn = (Button)sender;

            string btn_id = btn.ID;
            int secilen_koltuk_sira = Int32.Parse(btn_id.Substring(btn_id.Length - 1));
            String[] secilen_koltuk = secilen_koltuklar[secilen_koltuk_sira].ToString().Split('-');

            TextBox txt_box_name = (TextBox)pnl_list.FindControl("txt_box_name_"+ secilen_koltuk_sira.ToString());
            TextBox txt_box_surname = (TextBox)pnl_list.FindControl("txt_box_surname_" + secilen_koltuk_sira.ToString());
            TextBox txt_box_phone = (TextBox)pnl_list.FindControl("txt_box_phone_" + secilen_koltuk_sira.ToString());
            TextBox txt_box_email = (TextBox)pnl_list.FindControl("txt_box_email_" + secilen_koltuk_sira.ToString());
            TextBox txt_box_tc = (TextBox)pnl_list.FindControl("txt_box_tc_" + secilen_koltuk_sira.ToString());
            Label lbl_error = (Label)pnl_list.FindControl("lbl_error_" + secilen_koltuk_sira.ToString());

            if (txt_box_name.Text == "" || txt_box_surname.Text == "" || txt_box_phone.Text == "" || txt_box_email.Text == "" || txt_box_tc.Text == "") 
            {
                lbl_error.Text = "Yukarıdaki tüm alanları doldurunuz.";
                lbl_error.Visible = true;
            }
            else
            {
                OleDbCommand bus_booking = new OleDbCommand("select count(*) from Booking where BookingID = '" + ((Sefer)seferler[Int32.Parse(secilen_koltuk[0])]).BookingId + "' and PassenderSeatID = '" + secilen_koltuk[1] + "'", conn);
                conn.Open();
                int numberOfRecords = bus_booking.ExecuteNonQuery();
                conn.Close();

                if (numberOfRecords >= 1)
                {
                    lbl_error.Visible = true;
                    lbl_error.Text = "Bu koltuk başka bir müşteriye aittir. Satın alınamaz.";
                }
                else
                {
                    if (btn.Enabled)
                    {
                        try
                        {

                            OleDbCommand insert_booking = new OleDbCommand("INSERT INTO Booking (BookingID,BusCapacity,PassengerID,PassenderSeatID,PassengerName,PassengerSurname,PassengerGender,PassengerEmail,PassengerPhone) " +
                                "VALUES (@bookingID,@busCapacity,@passengerID,@passenderSeatID,@passengerName,@passengerSurname,@passengerGender,@passengerEmail,@passengerPhone) ", conn);
                            conn.Open();
                            insert_booking.Parameters.AddWithValue("@bookingID", ((Sefer)seferler[Int32.Parse(secilen_koltuk[0])]).BookingId);
                            insert_booking.Parameters.AddWithValue("@busCapacity", ((Sefer)seferler[Int32.Parse(secilen_koltuk[0])]).Seat.Length.ToString());
                            insert_booking.Parameters.AddWithValue("@passengerID", txt_box_tc.Text);
                            insert_booking.Parameters.AddWithValue("@passenderSeatID", secilen_koltuk[1]);
                            insert_booking.Parameters.AddWithValue("@passengerName", txt_box_name.Text);
                            insert_booking.Parameters.AddWithValue("@passengerSurname", txt_box_surname.Text);
                            insert_booking.Parameters.AddWithValue("@passengerGender", secilen_koltuk[2]);
                            insert_booking.Parameters.AddWithValue("@passengerEmail", txt_box_email.Text);
                            insert_booking.Parameters.AddWithValue("@passengerPhone", txt_box_phone.Text);

                            insert_booking.ExecuteNonQuery();
                            conn.Close();

                            lbl_error.Visible = true;
                            lbl_error.Attributes.Add("class", "text-warning");
                            lbl_error.Text = "Kaydınız tamamlandı.";
                            btn.Enabled = false;
                        }
                        catch
                        {
                            lbl_error.Visible = true;
                            lbl_error.Attributes.Add("class", "text-danger");
                            lbl_error.Text = "Kaydınız tamamlanamadı.Tekrar deneyin.";
                        }
                    }
                }
               
            }

        }
    }
}