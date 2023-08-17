<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NetVipsCrash._Default" %>
<form runat="server">
<h1>NetVips crash</h1>
<h2>Source image</h2>
<img src="Images/source.jpg" height="500"/>

<asp:Button runat="server" OnClick="OnServerClick" Text="Create thumbnail" id="butThumbnail"/>
    
</form>