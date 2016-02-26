<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopMenu.ascx.cs" Inherits="DoChoiOTo.UserControls.TopMenu" %>
<div id='cssmenu'>
    <ul>
        <li><a href='#'><span>Trang chủ </span></a></li>
        <li><a href='#'><span>Giới thiệu </span></a></li>
        <li class='active has-sub'><a href='#'><span>Sản phẩm </span></a>
            <ul>
                <li><a href='#'><span>Sản phẩm nổi bật </span></a></li>
                <li><a href='#'><span>Sản phẩm mới </span></a></li>
            </ul>
        </li>
        <li class='active has-sub'><a href='#'><span>Dịch vụ</span></a>
            <ul>
                <%--<li><a href='#'><span>Sản phẩm nổi bật </span></a></li>
                <li><a href='#'><span>Sản phẩm mới </span></a></li>--%>
                <%
                    var listServices = GetAllServices();
                    foreach (var service in listServices)
                    {
                        Response.Write(string.Format(" <li><a href='#'><span>{0} </span></a></li>", service.ServiceName));
                    }
                %>
            </ul>
        </li>
        <li><a href='#'><span>Tin tức</span></a></li>
        <li class='last'><a href='#'><span>Tuyển dụng</span></a></li>
    </ul>
</div>

<script>
    //$(document).ready(function () {
    //    $('#ulSanPham').hover(function () {
    //        $('#subMenu').removeClass('dropdown');
    //    });
    //    $('#ulSanPham').mouseleave(function () {
    //        $('#subMenu').addClass('dropdown');
    //    });
    //});

</script>
