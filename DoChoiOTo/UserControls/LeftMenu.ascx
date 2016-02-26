<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftMenu.ascx.cs" Inherits="DoChoiOTo.UserControls.LeftMenu" %>
<div class="left_content">
    <div class="title_box">Danh mục</div>
    <ul class="left_menu">
        <%
            var categories = LoadData();
            for (int i = 0; i < categories.Count; i++)
            {
                var cssClass = i % 2 == 0 ? "odd" : "even";
                Response.Write(string.Format("<li class='{0}'><a href=''>{1}</a></li>", cssClass, categories[i].CategoryName));
            }
        %>
    </ul>
    <div class="title_box">Sản phẩm ngẫu nhiên</div>
    <div class="border_box">
        <div class="product_title"><a href="http://all-free-download.com/free-website-templates/">Makita 156 MX-VL</a></div>
        <div class="product_img"><a href="http://all-free-download.com/free-website-templates/">
            <img src="images/p1.jpg" alt="" border="0" /></a></div>
        <div class="prod_price"><span class="reduce">350$</span> <span class="price">270$</span></div>
    </div>
    <%--<div class="title_box">Newsletter</div>
    <div class="border_box">
        <input type="text" name="newsletter" class="newsletter_input" value="your email" />
        <a href="http://all-free-download.com/free-website-templates/" class="join">subscribe</a>
    </div>
    <div class="banner_adds"><a href="http://all-free-download.com/free-website-templates/">
        <img src="images/bann2.jpg" alt="" border="0" /></a> </div>--%>
</div>
