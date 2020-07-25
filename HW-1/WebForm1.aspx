<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
    <style>
        body {
            background-image: url("https://cdn.suwalls.com/wallpapers/vector/city-skyline-26532-1920x1200.jpg");
            background-repeat: no-repeat;
            background-attachment: fixed;
            background-size: 100% 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-group">
            </br></br>
            <div class="col-md-4 mb-3">
                <asp:Label ID="lbl_header" runat="server" Text="Verify Your Card Here: " CssClass="display-5 text-info text-center font-weight-bold" Font-Size="20pt"></asp:Label>
            </div>
            </br>
            <div class="col-md-4 mb-3">
                <div class="form-row">
                    <div class="col-md-4">
                        <asp:Label ID="lbl_cardType" runat="server" Text="Select Credit Card: " CssClass="display-6 text-info text-left"></asp:Label>
                    </div>
                    <div class="col-md-8">
                        <asp:DropDownList ID="ddl_cardType" runat="server" CssClass="custom-select custom-select-md" required OnSelectedIndexChanged="ddl_cardType_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem>MasterCard</asp:ListItem>
                            <asp:ListItem>Visa</asp:ListItem>
                            <asp:ListItem>JCB</asp:ListItem>
                            <asp:ListItem>Discover</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                </div>
            </div>
            <div class="col-md-4 mb-3">
                <div class="form-row">
                    <div class="col-md-4">
                        <asp:Label ID="lbl_creditCardNumber" runat="server" Text="Enter Number: " CssClass="display-6 text-info text-left"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtBox_cardNumber1" runat="server" CssClass="form-control"  MaxLength="4" pattern="\d{4}" title="First four digits" 
                            ></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtBox_cardNumber2" runat="server" CssClass="form-control"  MaxLength="4" pattern="\d{4}" title="Second four digits" 
                            ></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtBox_cardNumber3" runat="server" CssClass="form-control"  MaxLength="4" pattern="\d{4}" title="Third four digits" 
                            ></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtBox_cardNumber4" runat="server" CssClass="form-control"  MaxLength="4" pattern="\d{4}" title="Fourth four digits" 
                            ></asp:TextBox>
                    </div>

                </div>
            </div>
            <div class="col-md-4 mb-3">
                <div class="form-row">
                    <div class="col-md-4">
                        <asp:Button runat="server" Text="Check" CssClass="btn btn-info pull-center" OnClick="Control" ID="btn_Check" />
                    </div>
                    <div class="col-md-8">
                        <asp:Label ID="lbl_sonuc" runat="server" Text="" CssClass="text-success text-left font-weight-bold"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>

</body>

</html>
