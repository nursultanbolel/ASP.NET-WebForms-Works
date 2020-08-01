<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="HW4.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>File Upload</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>

    <style>
        .files input {
            height: 50% !important;
            outline: 2px dashed #92b0b3;
            outline-offset: -10px;
            -webkit-transition: outline-offset .15s ease-in-out, background-color .15s linear;
            transition: outline-offset .15s ease-in-out, background-color .15s linear;
            /*padding: 120px 0px 85px 35%;*/
            padding: 60px 0px 20px 35%;
            text-align: center !important;
            margin: 0;
            width: 100% !important;
            border-color: #5bc0de;
            border-width: 2px;
        }

            .files input:focus {
                outline: 2px dashed #92b0b3;
                outline-offset: -10px;
                -webkit-transition: outline-offset .15s ease-in-out, background-color .15s linear;
                transition: outline-offset .15s ease-in-out, background-color .15s linear;
                border: 1px solid #92b0b3;
            }

        .files {
            position: relative
        }

            .files:after {
                pointer-events: none;
                position: absolute;
                top: 30px;
                left: 0;
                width: 25px;
                right: 0;
                height: 28px;
                content: "";
                background-image: url(https://image.flaticon.com/icons/png/128/109/109612.png);
                display: block;
                margin: 0 auto;
                background-size: 100%;
                background-repeat: no-repeat;
            }

        .color input {
            background-color: #f1f1f1;
        }

        .files:before {
            position: absolute;
            bottom: 10px;
            left: 0;
            pointer-events: none;
            width: 100%;
            right: 0;
            height: 57px;
            /*content: " or drag it here. ";*/
            display: block;
            margin: 0 auto;
            color: #2ea591;
            font-weight: 600;
            text-transform: capitalize;
            text-align: center;
        }

        html {
            /*background-color: Gray;*/
            font: 14px Georgia,Serif,Garamond;
        }

        h1 {
            color: Green;
            font-size: 18px;
            border-bottom: Solid 1px orange;
        }

        .clear {
            /*clear: both;*/
        }

        .lbl {
            color: green;
            font-weight: bold;
        }

        .upperColumn {
            margin: auto;
            width: 600px;
            border-bottom: Solid 1px orange;
            background-color: white;
            padding: 10px;
        }

        .bottomColumn {
            margin: auto;
            width: 600px;
            background-color: white;
            padding: 10px;
        }
    </style>

    <script language="javascript" type="text/javascript">

        var size = 2;
        var id = 0;
        function ProgressBars_finish() {
            document.getElementById("pb1").style.width = 300 + "%";
            document.getElementById("pb1").innerHTML = parseInt(300 / 3) + "%";
            document.getElementById("pb2").style.width = 300 + "%";
            document.getElementById("pb2").innerHTML = parseInt(300 / 3) + "%";
            document.getElementById("pb3").style.width = 300 + "%";
            document.getElementById("pb3").innerHTML = parseInt(300 / 3) + "%";
            document.getElementById("Label_error").innerHTML = "File uploading process was completed successfully.";
            id = setInterval("progressClear", 20);

        }
        function progressClear() {
            size = size + 1;

            if (size > 100) {

                document.getElementById("pb1").style.width = 0 + "%";
                document.getElementById("pb1").innerHTML = parseInt(0) + "%";
                document.getElementById("pb2").style.width = 0 + "%";
                document.getElementById("pb2").innerHTML = parseInt(0) + "%";
                document.getElementById("pb3").style.width = 0 + "%";
                document.getElementById("pb3").innerHTML = parseInt(0) + "%";

                clearTimeout(id);
            }
        }

    </script>


</head>
<body>
    <form id="form1" runat="server">

        <asp:Panel ID="Panel_File_Upload" runat="server">
            <%--File Upload 3 Files--%>
            <div class="container">
                <br />
                <div class="row">
                    <div class="col-md-12 text-center">
                        <p class="h1  text-info">File Upload Manager </p>
                    </div>
                </div>
                <br />

                <%-- File Upload Space 1 --%>
                <div class="row">
                    <div class="col-md-3" style="padding: 50px 0px 20px; text-align: center !important; margin: 0; width: 100% !important;">
                        <asp:Label ID="Label1" runat="server" CssClass="font-weight-bold text-primary" Text="Upload Your File 1"></asp:Label>
                    </div>
                    <div class="col-md-9">
                        <div class="form-group files ">
                            <input type="file" id="file1" class="form-control" style="height: 10px;" multiple="" accept=".mp3, .png, .jpg, .gif, .pdf, .docx, .doc, .xls, .xlsx, .ppt, .pptx" runat="server" />
                        </div>
                    </div>

                </div>

                <%-- File Upload Progress 1 --%>
                <asp:Panel ID="Panel_pb_1" runat="server">
                    <div class="row">
                        <div class="col-md-3" style="padding: 10px 0px 20px; text-align: center !important; margin: 0; width: 100% !important;">
                            <%--<asp:Label ID="Label4" runat="server" CssClass="font-weight-bold text-primary" Text="File 1"></asp:Label>--%>
                        </div>
                        <div class="col-md-9" style="padding: 10px 0px 20px; text-align: center !important; margin: 0; width: 100% !important;">
                            <div class="progress">
                                <div class="progress-bar bg-info" runat="server" id="pb1" role="progressbar" style="width: 0%;" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <%-- File Upload Space 2 --%>

                <div class="row">
                    <div class="col-md-3" style="padding: 50px 0px 20px; text-align: center !important; margin: 0; width: 100% !important;">
                        <asp:Label ID="Label2" runat="server" CssClass="font-weight-bold text-primary" Text="Upload Your File 2"></asp:Label>
                    </div>
                    <div class="col-md-9">
                        <div class="form-group files">
                            <input type="file" id="file2" class="form-control" multiple="" accept=".mp3, .png, .jpg, .gif, .pdf, .docx, .doc, .xls, .xlsx, .ppt, .pptx" runat="server" />
                        </div>
                    </div>
                </div>

                <%-- File Upload Progress 2 --%>
                <asp:Panel ID="Panel_pb_2" runat="server" >
                    <div class="row">
                        <div class="col-md-3" style="padding: 10px 0px 20px; text-align: center !important; margin: 0; width: 100% !important;">
                            <%--<asp:Label ID="Label5" runat="server" CssClass="font-weight-bold text-primary" Text="File 2"></asp:Label>--%>
                        </div>
                        <div class="col-md-9" style="padding: 10px 0px 20px; text-align: center !important; margin: 0; width: 100% !important;">
                            <div class="progress">
                                <div class="progress-bar bg-info" runat="server" id="pb2" role="progressbar" style="width: 0%;" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <%-- File Upload Space 3 --%>

                <div class="row">
                    <div class="col-md-3" style="padding: 50px 0px 20px; text-align: center !important; margin: 0; width: 100% !important;">
                        <asp:Label ID="Label3" runat="server" CssClass="font-weight-bold text-primary" Text="Upload Your File 3"></asp:Label>
                    </div>
                    <div class="col-md-9">
                        <div class="form-group files ">
                            <input type="file" id="file3" class="form-control" multiple="" accept=".mp3, .png, .jpg, .gif, .pdf, .docx, .doc, .xls, .xlsx, .ppt, .pptx" runat="server" />
                        </div>
                    </div>
                </div>

                <%-- File Upload Progress 3 --%>
                <asp:Panel ID="Panel_pb_3" runat="server">
                    <div class="row">
                        <div class="col-md-3" style="padding: 10px 0px 20px; text-align: center !important; margin: 0; width: 100% !important;">
                            <%--<asp:Label ID="Label6" runat="server" CssClass="font-weight-bold text-primary" Text="File 3"></asp:Label>--%>
                        </div>
                        <div class="col-md-9" style="padding: 10px 0px 20px; text-align: center !important; margin: 0; width: 100% !important;">
                            <div class="progress">
                                <div class="progress-bar bg-info" runat="server" id="pb3" role="progressbar" style="width: 0%;" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <%-- File Upload  Button --%>

                <div class="row">
                     <div class="col-md-3" style="padding: 10px 0px 20px;">
                        
                    </div>

                    <div class="col-md-6" style="padding: 10px 0px 20px;  text-align: center !important;">
                        <asp:Label ID="Label_error" CssClass="text-danger" runat="server" Text="" ></asp:Label>
                    </div>
                    <div class="col-md-3" style="padding: 0px 0px 20px; text-align: center !important; margin: 0; width: 100% !important;">
                        <asp:Button ID="btnUpload" CssClass="btn btn-outline-info" runat="server" Text="UPLOAD" OnClick="btnUpload_Click" />
                    </div>
                </div>
            </div>

        </asp:Panel>


    </form>
</body>
<script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
</html>
