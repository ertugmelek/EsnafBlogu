<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Giris.aspx.cs" Inherits="EsnafBlogu.Giris" %>
<%@ Register src="UyeGiris.ascx" tagname="UyeGiris" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <fieldset>
<legend>Kullanıcı Girişi</legend>

        <uc1:UyeGiris ID="UyeGiris1" runat="server" />

    </fieldset>


</asp:Content>
