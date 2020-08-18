<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsDetail.aspx.cs" Inherits="webFinal.NewsDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DHA</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <script type="text/javascript" language="javascript">
        function routeCategory(url) {
            window.location.href = url;
        }
    </script>
</head>
<body style="background-color: #F3F3F3">
    <form id="form1" runat="server">
        <header>
            <nav class="navbar fixed-top bg-white">
                <div class="container text-center">
                    <a class="navbar-brand" href="/Home.aspx">
                        <img src="https://www3.nhk.or.jp/nhkworld/common/assets/news/images/logo_news.svg" width="75" height="75" class="d-inline-block align-top" alt="">
                    </a>
                    <asp:Label ID="lblGundem" runat="server" Text="Gündem" Font-Bold="True" ForeColor="#494949" onClick="return routeCategory('Home.aspx?category=gundem')"></asp:Label>
                    <asp:Label ID="lblTurkiye" runat="server" Text="Türkiye" Font-Bold="True" ForeColor="#494949" onClick="return routeCategory('Home.aspx?category=turkiye')"></asp:Label>
                    <asp:Label ID="lblDunya" runat="server" Text="Dünya" Font-Bold="True" ForeColor="#494949" onClick="return routeCategory('Home.aspx?category=dunya')"></asp:Label>
                    <asp:Label ID="lblSpor" runat="server" Text="Spor" Font-Bold="True" ForeColor="#494949" onClick="return routeCategory('Home.aspx?category=spor')"></asp:Label>
                    <asp:Label ID="lblEkonomi" runat="server" Text="Ekonomi" Font-Bold="True" ForeColor="#494949" onClick="return routeCategory('Home.aspx?category=ekonomi')"></asp:Label>
                    <asp:Label ID="LabelSaglik" runat="server" Text="Sağlık" Font-Bold="True" ForeColor="#494949" onClick="return routeCategory('Home.aspx?category=saglik')"></asp:Label>
                    <asp:Label ID="lblCevre" runat="server" Text="Çevre" Font-Bold="True" ForeColor="#494949" onClick="return routeCategory('Home.aspx?category=cevre')"></asp:Label>
                </div>
            </nav>
        </header>
        <div style="padding-top: 120px; background-color: #F3F3F3">
            <div class="container">
                <div class="row">
                    <asp:Label ID="lblCategory" runat="server" Text="Label" ForeColor="#494949"></asp:Label>
                </div>
            </div>

            <div class="container">
                <div class="row">
                    <asp:Label ID="lblTitle" runat="server" Text="Label" Font-Bold="True" Font-Size="XX-Large" ForeColor="#C50000"></asp:Label>
                </div>
            </div>

            <div class="container">
                <div class="row  d-flex justify-content-center">
                    <figure class="">
                        <asp:Image ID="imgNew" runat="server" Width="100%" Height="100%" />
                    </figure>
                </div>
            </div>

            <div class="container">
                <div class="row">
                    <asp:Label ID="lblDate" runat="server" Text="Label" ForeColor="#494949"></asp:Label>
                </div>
            </div>
            <br />
            <div class="container">
                <div class="row">
                    <asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <br />
            <div class="container">
                <div class="row">
                    <asp:HyperLink ID="HLNewLink" runat="server">trthaber.com</asp:HyperLink>
                    <asp:Label ID="lblLink" runat="server" Text="'da oku."></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
</html>
