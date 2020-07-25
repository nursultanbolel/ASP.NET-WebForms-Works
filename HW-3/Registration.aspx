<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="HW3.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        .table > tbody > tr:first-child > td {
            border: none;
        }
    </style>

    <title>Registration</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <nav class="navbar navbar-expand-lg navbar-light bg-danger">
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarTogglerDemo01" aria-controls="navbarTogglerDemo01" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarTogglerDemo01">
                    <a class="navbar-brand" href="MainPage.aspx">
                        <img src="http://icons.iconarchive.com/icons/fasticon/happy-bus/128/bus-red-icon.png" width="40" height="40" alt="" />
                    </a>
                    <a class="navbar-brand text-white font-weight-bold " href="MainPage.aspx">ANADOLU TUR</a>

                </div>
                <div class="text-right">
                    <asp:ImageButton ID="ImageButton1" ImageUrl="http://icons.iconarchive.com/icons/custom-icon-design/silky-line-user/128/user-icon.png" Width="40" Height="40" runat="server" />
                    <asp:ImageButton ID="ImageButton2" ImageUrl="http://icons.iconarchive.com/icons/custom-icon-design/silky-line-user/128/user-add-icon.png" Width="40" Height="40" runat="server" />
                    <asp:ImageButton ID="ImageButton3" ImageUrl="images/cagrimerkezi.png" runat="server" Width="110" />

                </div>
            </nav>

            <div class="container card  border-danger border-top-0 border-left-0 border-right-0" style="border-width: 2px;">
                <nav class="navbar navbar-expand-lg navbar-light ">
                    <a class="p-2 text-muted" href="#">ONLINE BILET</a>
                    <a class="p-2 text-muted" href="#">KURUMSAL</a>
                    <a class="p-2 text-muted" href="#">SEYEHAT KILAVUZU</a>
                    <a class="p-2 text-muted" href="#">MÜŞTERİ HİZMETLERİ</a>
                    <a class="p-2 text-muted" href="#">İLETİŞİM</a>
                </nav>
            </div>
        </header>

        <br />
        <br />

        <div class="container">
            <asp:Panel ID="pnl_list" runat="server">
            </asp:Panel>


        </div>


        <br />
        <br />


        <asp:Panel ID="pnl_info" runat="server">
            <div class="container">
                <div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-6">
                                <div class="card mb-3">
                                    <div class="card-header font-weight-bold">Altın Bilet</div>
                                    <div class="card-body">
                                        <asp:Label ID="lbl_altin_bilet" CssClass="card-text" runat="server" Text="Altın Bilet, bileti olduğu halde otobüsü çeşitli sebeplerden dolayı kaçıran yolcularımıza yeniden yolculuk hakkı tanıyan bilet sistemidir."></asp:Label>
                                        <br />
                                        <asp:CheckBox ID="CheckBox_altın_bilet" class="form-check-input" Text="Yanmaz bilet istiyorum." runat="server" />
                                        <br />
                                    </div>
                                </div>

                            </div>
                            <div class="col-6">
                                <div class="card  mb-3">
                                    <div class="card-header font-weight-bold">Sefer Bilgileri</div>
                                    <div class="card-body">
                                        <asp:Panel ID="pnl_sefer_info" runat="server">

                                            <div class="container text-center">
                                                <div class="row text-center">
                                                    <asp:ImageButton ID="ImageButton_logo" ImageUrl="http://otogardayim.com/static/uploads/firma/pamukkale-logo.jpg" runat="server" Width="110" />
                                                </div>
                                            </div>

                                            <div class="row">
                                                <asp:Label ID="lbl_tarih" runat="server" Text="Tarih: "></asp:Label><br />
                                            </div>
                                            <div class="row">
                                                <asp:Label ID="lbl_kalkis" runat="server" Text="Kalkış: "></asp:Label><br />
                                            </div>

                                            <div class="row">
                                                <asp:Label ID="lbl_varis" runat="server" Text="Varış: "></asp:Label><br />
                                            </div>

                                            <div class="row">
                                                <asp:Label ID="lbl_saat" runat="server" Text="Saat: "></asp:Label><br />
                                            </div>
                                        </asp:Panel>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            </div>
        </asp:Panel>


        </div>

    </form>

    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>

</body>
</html>
