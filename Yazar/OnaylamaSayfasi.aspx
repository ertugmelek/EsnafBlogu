<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="OnaylamaSayfasi.aspx.cs" Inherits="EsnafBlogu.Yazar.OnaylamaSayfasi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">

        <asp:View ID="view1" runat="server">   
            <table class="auto-style1">
        <tr>
            <td>Ad Soyad:</td>
            <td>
                <asp:TextBox ID="txtAdSoyad" runat="server" Width="173px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Email:</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Width="172px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>WebSite:</td>
            <td>
                <asp:TextBox ID="txtWebSite" runat="server" Height="18px" Width="171px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Yorum:</td>
            <td>
                <asp:TextBox ID="txtYorum" runat="server" Height="83px" TextMode="MultiLine" Width="175px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:LinkButton ID="btnOnayla" runat="server"  OnClientClick="return confirm(&quot;Onaylamak İstiyormusunuz? &quot;)" OnClick="btnOnayla_Click">Onayla</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
        </asp:View>

        <asp:View  ID="view2" runat="server" >

            <a href="../default.aspx">Yorum Onaylanmıştır.Anasayfaya Dönmek için tıklayınız...</a>
        </asp:View>
    </asp:MultiView>



</asp:Content>
