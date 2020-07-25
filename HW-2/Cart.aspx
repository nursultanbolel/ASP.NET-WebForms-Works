<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="HW2.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cart</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">

        <header>
            <nav class="navbar navbar-expand-lg navbar-light" style="background-color: #e3f2fd;">
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarTogglerDemo01" aria-controls="navbarTogglerDemo01" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarTogglerDemo01">
                    <a class="navbar-brand" href="#">
                        <img src="http://icons.iconarchive.com/icons/hopstarter/button/128/Button-Play-icon.png" width="30" height="30" alt="">
                    </a>
                    <a class="navbar-brand" href="Default.aspx" class="text-primary font-weight-bold">MOVIE SHOP</a>
                </div>
            </nav>
        </header>

        <div>
            <br />
            <asp:Panel ID="Panel_Info" runat="server">
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_info" runat="server" CssClass="text-success" Text="You are not loged please "></asp:Label>
                &nbsp;<asp:HyperLink ID="hlbl_link" Navigate="Login.aspx" runat="server" CssClass="text-warning" Text="loging!" NavigateUrl="~/Login.aspx"></asp:HyperLink>

            </asp:Panel>
        </div>


        <div class="container-fluid card-deck">
            <div class="row">
                <div class="col-2">
                    <asp:Panel ID="Panel_User_Info" runat="server">
                        <div class="card text-center">
                            <div class="card-body">
                                <div>
                                    <asp:Image ID="img_user" runat="server" src="http://icons.iconarchive.com/icons/custom-icon-design/pretty-office-2/128/man-icon.png" Width="30" Height="30" CssClass="center" />
                                    <asp:Label ID="lbl_welcome" runat="server" Text=" Welcome " CssClass="text-primary"></asp:Label><br />
                                    <asp:Label ID="lbl_user_name" runat="server" Text="Label" CssClass="text-primary"></asp:Label>
                                </div>
                                <br />

                                <br />
                                <asp:Button ID="btn_log_out" runat="server" Text="Log Out" CssClass="btn btn-primary btn-block" BackColor="#E3F2FD" BorderColor="#E3F2FD" ClientIDMode="Predictable" ForeColor="Black" OnClick="btn_log_out_Click" />

                            </div>
                        </div>
                    </asp:Panel>
                </div>

                <div class="col-10 text-center">
                    <asp:Panel ID="Panel_Cart" runat="server">

                        <br>
                        <div class="text-center">
                            <asp:Label ID="Label_cart_header" runat="server" CssClass="font-weight-bold text-info h3" Text="Shopping Cart" Font-Bold="True"></asp:Label>
                        </div>
                        <hr>

                        <div class="card">
                            <table class="table table-hover shopping-cart-wrap" id="T">
                                <thead class="text-muted">
                                    <tr class="text-center">
                                        <th scope="col" width="600">Movie</th>
                                        <th scope="col" width="180">Writer</th>
                                        <th scope="col" width="180">Director</th>
                                        <th scope="col" width="180">Year</th>
                                        <th scope="col" width="180"></th>
                                    </tr>
                                </thead>


                                <tbody>
                                    <asp:Panel ID="Panel_element" runat="server">
                                    </asp:Panel>
                                </tbody>

                            </table>
                            <br /><br />

                            <div >
                                <asp:Button ID="btn_go_default" CssClass="btn btn-outline-info btn-lg btn-block"  runat="server" Text="Return To Main Page" OnClick="btn_go_default_Click" /><br />
                            </div>
                            
                    </asp:Panel>
                </div>
            </div>
        </div>

        <div class="container">
        </div>
    </form>

    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>

</body>
</html>
