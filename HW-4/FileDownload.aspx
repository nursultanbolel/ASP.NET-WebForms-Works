<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileDownload.aspx.cs" Inherits="HW4.FileDownload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>File Download</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>

    <style>
        .download {
            border-color: #d9534f;
            border-width: 2px;
            height: 50% !important;
            outline: 2px dashed #92b0b3;
            outline-offset: -10px;
            -webkit-transition: outline-offset .15s ease-in-out, background-color .15s linear;
            transition: outline-offset .15s ease-in-out, background-color .15s linear;
            padding: 0px 0px 0px 0px;
            text-align: center !important;
            margin: 0;
            width: 100% !important;
        }
    </style>

    <script language="javascript" type="text/javascript">
        var size = 2;
        var id = 0;
        function ProgressBars_finish() {
            document.getElementById("pd1").style.width = 300 + "%";
            document.getElementById("pd1").innerHTML = parseInt(300 / 3) + "%";
            document.getElementById("pd2").style.width = 300 + "%";
            document.getElementById("pd2").innerHTML = parseInt(300 / 3) + "%";
            document.getElementById("pd3").style.width = 300 + "%";
            document.getElementById("pd3").innerHTML = parseInt(300 / 3) + "%";
            document.getElementById("Label_error").innerHTML = "File downloading process is completed successfully.";
            id = setInterval("progressClear", 20);
            
        }
        function progressClear() {
            size = size + 1;

            if (size > 100) {
                
                document.getElementById("pd1").style.width = 0 + "%";
                document.getElementById("pd1").innerHTML = parseInt(0) + "%";
                document.getElementById("pd2").style.width = 0 + "%";
                document.getElementById("pd2").innerHTML = parseInt(0) + "%";
                document.getElementById("pd3").style.width = 0 + "%";
                document.getElementById("pd3").innerHTML = parseInt(0) + "%";

                clearTimeout(id);
            }
        }

        function denedene(level) {
            document.getElementById("pd1").style.width = level*3 + "%";
            document.getElementById("pd1"+id).innerHTML = parseInt(level) + "%";
        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel_File_Download" runat="server">
                <ContentTemplate>
                    <div class="container">
                        <br />
                        <div class="row">
                            <div class="col-md-12 text-center">
                                <p class="h1 text-danger">File Download Manager </p>
                            </div>
                        </div>
                        <br />

                        <%-- Input Link 1 --%>

                        <div class="row">
                            <div class="col-md-3" style="padding: 50px 0px 20px; text-align: center !important; margin: 0; width: 100% !important;">
                                <asp:Label ID="Label7" runat="server" CssClass="font-weight-bold text-danger" Text="File 1"></asp:Label>
                            </div>
                            <div class="col-md-9" style="padding: 10px 0px 20px; text-align: center !important; margin: 0; width: 100% !important;">
                                <div class="form-group ">
                                    <div class="card download">
                                        <div class="card-body">
                                            <asp:TextBox ID="TextBox_link1" CssClass="" Style="padding: 10px 0px 10px 5%; text-align: center !important; border: none; width: 100% !important;" runat="server" Font-Bold="True" Text="Paste Url of file"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%-- Progress Bar 1 --%>

                        <div class="row">
                            <div class="col-md-3" style="padding: 10px 0px 20px; text-align: center !important; margin: 0; width: 100% !important;">
                                <%--<asp:Label ID="Label1" runat="server" CssClass="font-weight-bold text-danger" Text="File 1"></asp:Label>--%>
                            </div>
                            <div class="col-md-9" style="padding: 10px 0px 20px; text-align: center !important; margin: 0; width: 100% !important;">
                                <div class="progress">
                                    <asp:UpdateProgress ID="UpdateProgress2" runat="server"></asp:UpdateProgress>
                                    <div class="progress-bar bg-danger" runat="server" id="pd1" role="progressbar" style="width: 0%;" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
                                </div>
                            </div>
                        </div>

                        <%-- Input Link 2 --%>

                        <div class="row">
                            <div class="col-md-3" style="padding: 50px 0px 20px; text-align: center !important; margin: 0; width: 100% !important;">
                                <asp:Label ID="Label8" runat="server" CssClass="font-weight-bold text-danger" Text="File 2"></asp:Label>
                            </div>
                            <div class="col-md-9" style="padding: 10px 0px 20px; text-align: center !important; margin: 0; width: 100% !important;">
                                <div class="form-group ">
                                    <div class="card download">
                                        <div class="card-body">
                                            <asp:TextBox ID="TextBox_link2" CssClass="" Style="padding: 10px 0px 10px 5%; text-align: center !important; border: none; width: 100% !important;" runat="server" Font-Bold="True" Text="Paste Url of file"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%-- Progress Bar 2 --%>

                        <div class="row">
                            <div class="col-md-3" style="padding: 10px 0px 20px; text-align: center !important; margin: 0; width: 100% !important;">
                                <%--<asp:Label ID="Label14" runat="server" CssClass="font-weight-bold text-danger" Text="File 2"></asp:Label>--%>
                            </div>
                            <div class="col-md-9" style="padding: 10px 0px 20px; text-align: center !important; margin: 0; width: 100% !important;">
                                <div class="progress">
                                    <div class="progress-bar bg-danger" runat="server" id="pd2" role="progressbar" style="width: 0%;" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
                                </div>
                            </div>
                        </div>

                        <%-- Input Link 3 --%>

                        <div class="row">
                            <div class="col-md-3" style="padding: 50px 0px 20px; text-align: center !important; margin: 0; width: 100% !important;">
                                <asp:Label ID="Label11" runat="server" CssClass="font-weight-bold text-danger" Text="File 3"></asp:Label>
                            </div>
                            <div class="col-md-9" style="padding: 10px 0px 20px; text-align: center !important; margin: 0; width: 100% !important;">
                                <div class="form-group ">
                                    <div class="card download">
                                        <div class="card-body">
                                            <asp:TextBox ID="TextBox_link3" CssClass="" Style="padding: 10px 0px 0px 5%; text-align: center !important; border: none; width: 100% !important;" runat="server" Font-Bold="True" Text="Paste Url of file"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%-- Progress Bar 3 --%>

                        <div class="row">
                            <div class="col-md-3" style="padding: 10px 0px 20px; text-align: center !important; margin: 0; width: 100% !important;">
                                <%--<asp:Label ID="Label15" runat="server" CssClass="font-weight-bold text-danger" Text="File 3"></asp:Label>--%>
                            </div>
                            <div class="col-md-9" style="padding: 10px 0px 20px; text-align: center !important; margin: 0; width: 100% !important;">
                                <div class="progress">
                                    <div class="progress-bar bg-danger" runat="server" id="pd3" role="progressbar" style="width: 0%;" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
                                </div>
                            </div>
                        </div>

                        <%-- Download Button --%>

                        <div class="row">
                            <div class="col-md-3" style="padding: 10px 0px 20px;">
                                <div id ="control1" runat="server" visible="false">1</div>
                                <div id ="control2" runat="server" visible="false">1</div>
                                <div id ="control3" runat="server" visible="false">1</div>
                            </div>

                            <div class="col-md-6" style="padding: 10px 0px 20px; text-align: center !important;">
                                <asp:Label ID="Label_error" CssClass="text-danger" runat="server" Text=""></asp:Label>
                            </div>

                            <div class="col-md-3" style="padding: 0px 0px 20px; text-align: center !important; margin: 0; width: 100% !important;">
                                <asp:Button ID="btn_download" CssClass="btn btn-outline-danger" runat="server" Text="DOWNLOAD" OnClick="btnDownloadClick"/>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </form>
</body>
<script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
</html>