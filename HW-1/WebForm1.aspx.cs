using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public String message;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Control(object sender, EventArgs e)
        {
            String cardType = ddl_cardType.SelectedValue.ToString();
            String cardNumber1 = txtBox_cardNumber1.Text.ToString();
            String cardNumber2 = txtBox_cardNumber2.Text.ToString();
            String cardNumber3 = txtBox_cardNumber3.Text.ToString();
            String cardNumber4 = txtBox_cardNumber4.Text.ToString();

            if(cardNumber1 == "" | cardNumber2 == "" | cardNumber3 == "" | cardNumber4 == "")
            {
                lbl_sonuc.CssClass = "text-warning text-left font-weight-bold";
                message = "You must enter a 4-4-4-4 card number.";
            }
            else
            {
                String cardNumber = cardNumber1 + cardNumber2 + cardNumber3 + cardNumber4;

                Boolean sonuc = CardValidation(cardType, cardNumber);

                if(sonuc)
                {
                    lbl_sonuc.CssClass = "text-success text-left font-weight-bold";
                }
                else
                {
                    lbl_sonuc.CssClass = "text-warning text-left font-weight-bold";
                }
                
            }
            
            lbl_sonuc.Text = message;

        }

        public bool CardValidation(String cardType, String cardNumber)
        {
            if (cardType == "" | cardNumber == "")
            {
                return false;
            }
            switch (cardType)
            {
                case "MasterCard":
                    if (Regex.Match(cardNumber, @"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$").Success)
                    {
                        message = "Valid";
                        return true;
                    }
                    message = "Credit card number is in invalid format.";
                    return false;
                    

                case "Visa":
                    if (Regex.Match(cardNumber, @"^4[0-9]{12}(?:[0-9]{3})?$").Success)
                    {
                        message = "Valid";
                        return true;
                    }
                    message = "Credit card number is in invalid format.";
                    return false;
                    

                case "JCB":
                    if (Regex.Match(cardNumber, @"^(?:2131|1800|35\d{3})\d{11}$").Success)
                    {
                        message = "Valid";
                        return true;
                    }
                    message = "Credit card number is in invalid format.";
                    return false;
                    ;

                case "Discover":
                    if (Regex.Match(cardNumber, @"^6(?:011|5[0-9]{2})[0-9]{12}$").Success)
                    {
                        message = "Valid";
                        return true;
                    }
                    message = "Credit card number is in invalid format.";
                    return false;
                    
                default:
                    message = "Unknown card type";
                    return false;
            }

        }

        protected void ddl_cardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_sonuc.Text = "    ";
        }


    }
}