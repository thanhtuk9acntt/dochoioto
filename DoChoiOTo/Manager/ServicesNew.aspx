<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Site.Master" AutoEventWireup="true" CodeBehind="ServicesNew.aspx.cs" Inherits="DoChoiOTo.Manager.ServicesNew" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 650px;
            height: 30px;
        }

        .auto-style2 {
            width: 100px;
        }

        .auto-style3 {
            width: 100px;
            height: 215px;
        }

        .auto-style4 {
            width: 650px;
            height: 215px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <table>
            <tr>
                <td class="auto-style2">Tên dịch vụ <span class="required">*</span></td>
                <td class="auto-style1">
                    <asp:TextBox runat="server" ID="txtServicesName" Width="456px" MaxLength="150" /></td>
            </tr>
            <tr>
                <td class="auto-style3">Mô tả chi tiết<span class="required">*</span></td>
                <td class="auto-style4">
                    <FCKeditorV2:FCKeditor ID="txtDesciption" BasePath="../fckeditor/" runat="server" Height="300px"></FCKeditorV2:FCKeditor>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Chọn ảnh <span class="required">*</span></td>
                <td class="auto-style1">
                    <asp:FileUpload ID="fileImages"  ClientIDMode="Static" runat="server"  Width="250px" />
                    <div id="image-holder"></div>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style1">
                    <asp:Button runat="server" Text="Lưu" Width="100px" OnClick="btnSave_Click" />

                </td>
            </tr>
        </table>
    </fieldset>

    <script>
        $(document).ready(function () {
            $("#fileImages").on('change', function () {

                if (typeof (FileReader) != "undefined") {

                    var image_holder = $("#image-holder");
                    image_holder.empty();

                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $("<img />", {
                            "src": e.target.result,
                            "class": "thumb-image"
                        }).appendTo(image_holder);

                    }
                    image_holder.show();
                    reader.readAsDataURL($(this)[0].files[0]);
                } else {
                    alert("This browser does not support FileReader.");
                }
            });
        });
</script>
</asp:Content>
