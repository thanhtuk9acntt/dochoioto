<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Site.Master" AutoEventWireup="true" CodeBehind="ProductNew.aspx.cs" Inherits="DoChoiOTo.Manager.ProductNew" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 30px;
            width: 100px;
        }

        .auto-style2 {
            width: 648px;
        }

        .auto-style3 {
            width: 100px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td class="auto-style1">Tên sản phẩm</td>
            <td class="auto-style2">
                <asp:TextBox runat="server" ID="txtProductName" /></td>
        </tr>
        <tr>
            <td class="auto-style1">Nhóm sản phẩm</td>
            <td>
                <asp:DropDownList runat="server" ID="ddlCategory" /></td>
        </tr>
        <tr>
            <td class="auto-style3">Mô tả chi tiết</td>
            <td>
                <FCKeditorV2:FCKeditor ID="txtDescription" BasePath="../fckeditor/" runat="server" Height="500px"></FCKeditorV2:FCKeditor>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Giá gốc</td>
            <td>
                <asp:TextBox runat="server" ID="txtOldPrice" /></td>
        </tr>
        <tr>
            <td class="auto-style1">Giá khuyến mại</td>
            <td>
                <asp:TextBox runat="server" ID="txtNewPrice" /></td>
        </tr>

        <tr>
            <td class="auto-style1">Ảnh sản phẩm</td>
            <td>
                <asp:FileUpload runat="server" ClientIDMode="Static" ID="fileImages" AllowMultiple="true" Width="517px" />
                <div id="image-holder"></div>
            </td>
        </tr>
        <tr>
            <td class="auto-style3"></td>
            <td>
                <asp:Button runat="server" OnClick="btnSave_Click" ID="btnSave" Text="Lưu" /></td>
        </tr>
    </table>

    <script>
        $(document).ready(function () {

            $("#fileImages").on('change', function () {

                //Get count of selected files
                var countFiles = $(this)[0].files.length;

                var imgPath = $(this)[0].value;
                var extn = imgPath.substring(imgPath.lastIndexOf('.') + 1).toLowerCase();
                var image_holder = $("#image-holder");
                image_holder.empty();

                if (extn == "gif" || extn == "png" || extn == "jpg" || extn == "jpeg") {
                    if (typeof (FileReader) != "undefined") {

                        //loop for each file selected for uploaded.
                        for (var i = 0; i < countFiles; i++) {

                            var reader = new FileReader();
                            reader.onload = function (e) {
                                $("<img />", {
                                    "src": e.target.result,
                                    "class": "thumb-image"
                                }).appendTo(image_holder);
                            }

                            image_holder.show();
                            reader.readAsDataURL($(this)[0].files[i]);
                        }

                    } else {
                        alert("This browser does not support FileReader.");
                    }
                } else {
                    alert("Pls select only images");
                }
            });
        });
    </script>
</asp:Content>
