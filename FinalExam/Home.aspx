<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="webFinal.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DHA</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <script type="text/javascript" language="javascript">
        function routeDetail(url) {
            window.location.href = url;
        }
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

        <asp:Panel ID="PnlGeneral" runat="server">
            <div style="padding-top: 120px;">
                <%-- Slide Bar --%>
                <div class="container">
                    <div class="row d-flex justify-content-center">
                        <div class="col-8">
                            <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                                <ol class="carousel-indicators rounded">
                                    <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                                    <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                                    <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                                    <li data-target="#carouselExampleIndicators" data-slide-to="3"></li>
                                    <li data-target="#carouselExampleIndicators" data-slide-to="4"></li>
                                </ol>
                                <div class="carousel-inner">
                                    <asp:Panel ID="PnlSlider" runat="server"></asp:Panel>

                                </div>
                                <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                    <span class="sr-only">Previous</span>
                                </a>
                                <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                    <span class="sr-only">Next</span>
                                </a>
                            </div>
                        </div>
                        <div class="col-4">
                            <asp:Panel ID="PnlRight" runat="server"></asp:Panel>
                        </div>
                    </div>
                </div>
                <br />
                <%-- Bugünkü LABEL--%>
                <div class="container">
                    <div class="row">
                        <div class="col-12">
                            <asp:Label ID="Label9" runat="server" Text="BUGÜNKÜ HABERLER" Font-Bold="True" Font-Size="Large" ForeColor="#494949"></asp:Label>
                        </div>
                    </div>
                </div>
                <br />
                <%-- Bugünkü Haberler Cards --%>
                <div class="container">
                    <div class="card-columns">
                        <asp:Panel ID="PnlToday" runat="server"></asp:Panel>
                    </div>
                </div>
                <%-- Güncel  LABEL--%>
                <div class="container">
                    <div class="row">
                        <div class="col-12">
                            <asp:Label ID="Label8" runat="server" Text="GÜNCEL HABERLER" Font-Bold="True" Font-Size="Large" ForeColor="#494949"></asp:Label>
                        </div>
                    </div>
                </div>
                <br />
                <%-- Güncel Haberler Cards --%>
                <div class="container">
                    <div class="card-columns">
                        <asp:Panel ID="PnlLastNews" runat="server"></asp:Panel>
                    </div>
                </div>
                <br />
            </div>
        </asp:Panel>

        <asp:Panel ID="PanelFilter" runat="server">
            <div style="padding-top: 120px;">
                <%-- Category LABEL--%>
                <div class="container">
                    <div class="row">
                        <div class="col-12">
                            <asp:Label ID="lblCategory" runat="server" Text="" Font-Bold="True" Font-Size="Large" ForeColor="#494949"></asp:Label>
                        </div>
                    </div>
                </div>
                <br />
                <%-- Category Cards--%>
                <div class="container">
                    <div class="card-columns">
                        <asp:Panel ID="PnlCategory" runat="server"></asp:Panel>
                    </div>
                </div>
            </div>
        </asp:Panel>

    </form>
</body>
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
</html>
