<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="HW3.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        .table > tbody > tr:first-child > td {
            border: none;
        }
    </style>

    <title>Main</title>
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
                    <a class="navbar-brand" href="#">
                        <img src="http://icons.iconarchive.com/icons/fasticon/happy-bus/128/bus-red-icon.png" width="40" height="40" alt="" />
                    </a>
                    <a class="navbar-brand text-white font-weight-bold " href="">ANADOLU TUR</a>

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
            <div class="card border-light " style="border-width: 3px;">
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-4">
                            <label>Kalkış Noktası</label>
                            <asp:DropDownList ID="DropDownList_kalkis" CssClass="form-control select2-hidden-accessible" runat="server" aria-hidden="true">
                                <asp:ListItem>Bursa</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                        <div class="col-md-4">

                            <label>Varış Noktası</label>
                            <asp:DropDownList ID="DropDownList_varis" CssClass="form-control select2-hidden-accessible" runat="server" aria-hidden="true">
                                <asp:ListItem>İstanbul-AVRUPA(ESENLER)</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                        <div class="col-md-2">
                            <div class="">
                                <label>Tarih</label>
                                <asp:TextBox ID="txtBox_ArrivedDate" CssClass="form-control" TabIndex="25" TextMode="Date" runat="server" MaxLength="10"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-2 text-black-50 right">
                            <div class="form-group form-group-lg form-group-select-plus">
                                <br />
                                <asp:Button ID="btn_sefer_sorgula" CssClass="btn btn-danger" runat="server" Text="Sefer Sorgula" OnClick="btn_sefer_sorgula_Click" />
                            </div>
                        </div>

                        <asp:Label ID="lbl_error" CssClass="text-danger" runat="server" Text="Yukarıdaki tüm alanları doldurunuz."></asp:Label>

                    </div>
                </div>
            </div>
        </div>

        <br />

        <div class="container">

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <ajaxToolkit:Accordion ID="Accordion_sefer_list" runat="server" HeaderCssClass="headerCssClass" ContentCssClass="contentCssClass" HeaderSelectedCssClass="headerSelectedCss" FadeTransitions="True" TransitionDuration="500" AutoSize="Limit" RequireOpenedPane="True" SelectedIndex="-1">
                <Panes>
                    <ajaxToolkit:AccordionPane ID="AccordionPane_sefer_1" runat="server">
                        <Header>
                            <div class="card border-light border-left-0" id="header-card-1" style="height: 130px; border-width: 3px">
                                <div class="card-body border-dotted">
                                    <table class="table  table-no-border" id="T" style="border-bottom: 0px !important; border-color: #ffffff;">
                                        <tbody>
                                            <tr style="border-bottom: 0px !important;">
                                                <td class="text-center" style="width: 200px;">
                                                    <figure class="media">
                                                        <div class="img-wrap">
                                                            <img src="http://otogardayim.com/static/uploads/firma/pamukkale-logo.jpg" class="img-sm" width="75" height="45"><br />
                                                            <asp:Label ID="lbl_sefer_time_1" CssClass="title text-truncate" runat="server" Text="03:15" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                        </div>
                                                    </figure>
                                                </td>
                                                <td class="">
                                                    <img src="http://icons.iconarchive.com/icons/icons8/ios7/128/Time-And-Date-Clock-icon.png" class="img-sm" width="15" height="15">
                                                    <asp:Label ID="lbl_sefer_from_1" runat="server" Text="Label" ForeColor="Gray">Bursa(03:15)</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <img src="http://icons.iconarchive.com/icons/icons8/ios7/128/Time-And-Date-Clock-icon.png" class="img-sm" width="15" height="15">
                                                    <asp:Label ID="lbl_sefer_to_1" runat="server" Text="Label" ForeColor="Gray">İSTANBUL-AVRUPA(ESENLER)(06:15)</asp:Label>
                                                    <br />
                                                    <br />
                                                    <div class="">
                                                        <img src="http://icons.iconarchive.com/icons/iconsmind/outline/128/Wifi-icon.png" class="img-sm" width="20" height="20">&nbsp;&nbsp;&nbsp;
                                                        <img src="http://icons.iconarchive.com/icons/iconsmind/outline/128/TV-icon.png" class="img-sm" width="20" height="20">&nbsp;&nbsp;&nbsp;
                                                        <img src="http://icons.iconarchive.com/icons/iconsmind/outline/128/Plug-In-icon.png" class="img-sm" width="20" height="20">
                                                    </div>

                                                </td>

                                                <td class="text-right">
                                                    <asp:Label ID="lbl_sefer_price_1" CssClass="price" runat="server" Text="62 ₺" Font-Size="Larger" ForeColor="#666666"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btn_sefer_1" CssClass="btn btn-danger" runat="server" Text="Koltuk Seç" OnClick="btn_sefer_Click" />
                                                </td>
                                            </tr>

                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </Header>
                        <%-- CONTENT --%>
                        <Content>
                            <div class="container card border-danger border-top-0" style="border-width: 3px; padding: 5px;">

                                <nav>
                                    <div class="nav nav-tabs" id="nav-tab" role="tablist">
                                        <a class="nav-item nav-link active text-danger" id="nav-koltuk-tab" data-toggle="tab" href="#nav-koltuk_1" role="tab" aria-controls="nav-home" aria-selected="true">Koltuk Seçimi</a>
                                        <a class="nav-item nav-link text-danger" id="nav-sefer-tab_1" data-toggle="tab" href="#nav-sefer_1" role="tab" aria-controls="nav-profile" aria-selected="false">Sefer Bilgisi</a>

                                    </div>
                                </nav>
                                <div class="tab-content" id="nav-tabContent_1">
                                    <div class="tab-pane fade show active " id="nav-koltuk_1" role="tabpanel" aria-labelledby="nav-home-tab">
                                        <div class="card" style="padding: 5px;">
                                            <div class="row">
                                                <div class="col-1">
                                                </div>

                                                <div class="col-md-9">
                                                    <div class="row">
                                                        <br />
                                                        <br />
                                                        <div class="col-md-8 text-left">
                                                            <hr width="100%" weight="2px">
                                                        </div>
                                                        <br />
                                                        <br />
                                                    </div>

                                                    <asp:Panel ID="pnl_otobus_1" runat="server">
                                                    </asp:Panel>

                                                </div>

                                                <asp:Panel ID="pnl_koltuk_secimi_1" runat="server">
                                                    <div class=" text-left">
                                                        <asp:Label ID="Label12" runat="server" Text="Seçtiğiniz Koltuklar"></asp:Label>
                                                    </div>
                                                    <asp:Panel ID="pnl_secili_koltuk_1" runat="server">
                                                    </asp:Panel>

                                                    <asp:Panel ID="pnl_btn_odeme_adimi_1" runat="server">
                                                        <asp:Button ID="btn_odeme_adimina_gec_1" runat="server" CssClass="btn btn-warning" Text="Ödeme Adımına geç" OnClick="Deneme"/>
                                                    </asp:Panel>
                                                </asp:Panel>

                                            </div>

                                        </div>

                                    </div>

                                    <div class="tab-pane fade" id="nav-sefer_1" role="tabpanel" aria-labelledby="nav-profile-tab">
                                    </div>

                                </div>

                            </div>

                        </Content>


                    </ajaxToolkit:AccordionPane>


                    <ajaxToolkit:AccordionPane ID="AccordionPane_sefer_2" runat="server">
                        <Header>
                            <div class="card border-light border-left-0 " style="height: 130px; border-width: 3px">
                                <div class="card-body ">
                                    <table class="table " id="T" style="border-bottom: 0px !important; border-color: #ffffff;">
                                        <tbody>
                                            <tr style="border-bottom: 0px !important;">
                                                <td class="text-center" style="width: 200px;">
                                                    <figure class="media">
                                                        <div class="img-wrap">
                                                            <img src="http://otogardayim.com/static/uploads/firma/pamukkale-logo.jpg" class="img-sm" width="75" height="45"><br />
                                                            <asp:Label ID="lbl_sefer_time_" CssClass="title text-truncate" runat="server" Text="Label" Font-Bold="True" Font-Size="X-Large">07:00</asp:Label>
                                                        </div>
                                                    </figure>
                                                </td>
                                                <td class="">
                                                    <img src="http://icons.iconarchive.com/icons/icons8/ios7/128/Time-And-Date-Clock-icon.png" class="img-sm" width="15" height="15">
                                                    <asp:Label ID="lbl_sefer_from_2" runat="server" Text="Label" ForeColor="Gray">Bursa(07:00)</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <img src="http://icons.iconarchive.com/icons/icons8/ios7/128/Time-And-Date-Clock-icon.png" class="img-sm" width="15" height="15">
                                                    <asp:Label ID="lbl_sefer_to_2" runat="server" Text="Label" ForeColor="Gray">İstanbul-AVRUPA(ESENLER)(10:00)</asp:Label>
                                                    <br />
                                                    <br />
                                                    <div class="">
                                                        <img src="http://icons.iconarchive.com/icons/iconsmind/outline/128/Wifi-icon.png" class="img-sm" width="20" height="20">&nbsp;&nbsp;&nbsp;
                                                        <img src="http://icons.iconarchive.com/icons/iconsmind/outline/128/TV-icon.png" class="img-sm" width="20" height="20">&nbsp;&nbsp;&nbsp;
                                                        <img src="http://icons.iconarchive.com/icons/iconsmind/outline/128/Plug-In-icon.png" class="img-sm" width="20" height="20">
                                                    </div>

                                                </td>

                                                <td class="text-right">
                                                    <asp:Label ID="lbl_sefer_price_2" CssClass="price" runat="server" Text="62 ₺" Font-Size="Larger" ForeColor="#666666"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btn_sefer_2" CssClass="btn btn-danger" runat="server" Text="Koltuk Seç" OnClick="btn_sefer_Click" />
                                                </td>
                                            </tr>

                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </Header>

                        <Content>
                            <div class="container card border-danger border-top-0" style="border-width: 3px; padding: 5px;">

                                <nav>
                                    <div class="nav nav-tabs" id="nav-tab" role="tablist">
                                        <a class="nav-item nav-link active text-danger" id="nav-koltuk-tab" data-toggle="tab" href="#nav-koltuk_2" role="tab" aria-controls="nav-home" aria-selected="true">Koltuk Seçimi</a>
                                        <a class="nav-item nav-link text-danger" id="nav-sefer-tab" data-toggle="tab" href="#nav-sefer_2" role="tab" aria-controls="nav-profile" aria-selected="false">Sefer Bilgisi</a>

                                    </div>
                                </nav>
                                <div class="tab-content" id="nav-tabContent">
                                    <div class="tab-pane fade show active " id="nav-koltuk_2" role="tabpanel" aria-labelledby="nav-home-tab">
                                        <div class="card" style="padding: 5px;">
                                            <div class="row">
                                                <div class="col-1">
                                                </div>

                                                <div class="col-md-9">
                                                    <div class="row">
                                                        <br />
                                                        <br />
                                                        <div class="col-md-8 text-left">
                                                            <hr width="100%" weight="2px">
                                                        </div>
                                                        <br />
                                                        <br />
                                                    </div>

                                                    <asp:Panel ID="pnl_otobus_2" runat="server">
                                                    </asp:Panel>

                                                </div>

                                                <asp:Panel ID="pnl_koltuk_secimi_2" runat="server">
                                                    <div class=" text-left">
                                                        <asp:Label ID="Label1" runat="server" Text="Seçtiğiniz Koltuklar"></asp:Label>
                                                    </div>
                                                     <asp:Panel ID="pnl_secili_koltuk_2" runat="server">
                                                    </asp:Panel>

                                                    <asp:Panel ID="pnl_btn_odeme_adimi_2" runat="server">
                                                        <asp:Button ID="btn_odeme_adimina_gec_2" runat="server" CssClass="btn btn-warning" Text="Ödeme Adımına geç" OnClick="Deneme"/>
                                                    </asp:Panel>
                                                </asp:Panel>

                                            </div>

                                        </div>

                                    </div>

                                    <div class="tab-pane fade" id="nav-sefer_2" role="tabpanel" aria-labelledby="nav-profile-tab">
                                    </div>

                                </div>

                            </div>
                        </Content>
                    </ajaxToolkit:AccordionPane>


                    <ajaxToolkit:AccordionPane ID="AccordionPane_sefer_3" runat="server">
                        <Header>
                            <div class="card border-light border-left-0 " style="height: 130px; border-width: 3px">
                                <div class="card-body">
                                    <table class="table" id="T" style="border-bottom: 0px !important;">
                                        <tbody>
                                            <tr style="border-bottom: 0px !important;">
                                                <td class="text-center" style="width: 200px;">
                                                    <figure class="media">
                                                        <div class="img-wrap">
                                                            <img src="http://otogardayim.com/static/uploads/firma/pamukkale-logo.jpg" class="img-sm" width="75" height="45"><br />
                                                            <asp:Label ID="lbl_sefer_time_3" CssClass="title text-truncate" runat="server" Text="Label" Font-Bold="True" Font-Size="X-Large">09:00</asp:Label>
                                                        </div>
                                                    </figure>
                                                </td>
                                                <td class="">
                                                    <img src="http://icons.iconarchive.com/icons/icons8/ios7/128/Time-And-Date-Clock-icon.png" class="img-sm" width="15" height="15">
                                                    <asp:Label ID="lbl_sefer_from_3" runat="server" Text="Label" ForeColor="Gray">Bursa(09:00)</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <img src="http://icons.iconarchive.com/icons/icons8/ios7/128/Time-And-Date-Clock-icon.png" class="img-sm" width="15" height="15">
                                                    <asp:Label ID="lbl_sefer_to_3" runat="server" Text="Label" ForeColor="Gray">İstanbul-AVRUPA(ESENLER)(12:00)</asp:Label>
                                                    <br />
                                                    <br />
                                                    <div class="">
                                                        <img src="http://icons.iconarchive.com/icons/iconsmind/outline/128/Wifi-icon.png" class="img-sm" width="20" height="20">&nbsp;&nbsp;&nbsp;
                                                        <img src="http://icons.iconarchive.com/icons/iconsmind/outline/128/TV-icon.png" class="img-sm" width="20" height="20">&nbsp;&nbsp;&nbsp;
                                                        <img src="http://icons.iconarchive.com/icons/iconsmind/outline/128/Plug-In-icon.png" class="img-sm" width="20" height="20">
                                                    </div>

                                                </td>

                                                <td class="text-right">
                                                    <asp:Label ID="lbl_sefer_price_3" CssClass="price" runat="server" Text="62 ₺" Font-Size="Larger" ForeColor="#666666"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btn_sefer_3" CssClass="btn btn-danger" runat="server" Text="Koltuk Seç" OnClick="btn_sefer_Click" />
                                                </td>
                                            </tr>

                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </Header>

                        <Content>
                            <div class="container card border-danger border-top-0" style="border-width: 3px; padding: 5px;">

                                <nav>
                                    <div class="nav nav-tabs" id="nav-tab" role="tablist">
                                        <a class="nav-item nav-link active text-danger" id="nav-koltuk-tab" data-toggle="tab" href="#nav-koltuk_3" role="tab" aria-controls="nav-home" aria-selected="true">Koltuk Seçimi</a>
                                        <a class="nav-item nav-link text-danger" id="nav-sefer-tab" data-toggle="tab" href="#nav-sefer_3" role="tab" aria-controls="nav-profile" aria-selected="false">Sefer Bilgisi</a>

                                    </div>
                                </nav>
                                <div class="tab-content" id="nav-tabContent">
                                    <div class="tab-pane fade show active " id="nav-koltuk_3" role="tabpanel" aria-labelledby="nav-home-tab">
                                        <div class="card" style="padding: 5px;">
                                            <div class="row">
                                                <div class="col-1">
                                                </div>

                                                <div class="col-md-9">
                                                    <div class="row">
                                                        <br />
                                                        <br />
                                                        <div class="col-md-8 text-left">
                                                            <hr width="100%" weight="2px">
                                                        </div>
                                                        <br />
                                                        <br />
                                                    </div>

                                                    <asp:Panel ID="pnl_otobus_3" runat="server">
                                                    </asp:Panel>

                                                </div>

                                                <asp:Panel ID="pnl_koltuk_secimi_3" runat="server">
                                                    <div class=" text-left">
                                                        <asp:Label ID="Label2" runat="server" Text="Seçtiğiniz Koltuklar"></asp:Label>
                                                    </div>
                                                     <asp:Panel ID="pnl_secili_koltuk_3" runat="server">
                                                    </asp:Panel>

                                                    <asp:Panel ID="pnl_btn_odeme_adimi_3" runat="server">
                                                        <asp:Button ID="btn_odeme_adimina_gec_3" runat="server" CssClass="btn btn-warning" Text="Ödeme Adımına geç" OnClick="Deneme"/>
                                                    </asp:Panel>
                                                </asp:Panel>

                                            </div>

                                        </div>

                                    </div>

                                    <div class="tab-pane fade" id="nav-sefer_3" role="tabpanel" aria-labelledby="nav-profile-tab">
                                    </div>

                                </div>

                            </div>
                            </div>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                </Panes>
            </ajaxToolkit:Accordion>
        </div>


    </form>

    <script type="text/javascript">
        function ChangeImageBorderColor(e)
        {
            e.style.borderColor = "black";
        }
    </script>

    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>

</body>
</html>
