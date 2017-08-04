<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="UyeKayit.aspx.cs" Inherits="EsnafBlogu.UyeKayit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 78px;
        }
        th{

            font-weight:bold;
            font-size:11px;
            font-family:'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
            color:#4f6b72;
            border-right:1px solid #C1DAD7;
            border-left:1px solid #C1DAD7;
            border-top:1px solid #C1DAD7;
            letter-spacing: 2px;
            padding:5px 5px 5px 5px;
            text-align:left;
            background:#CAE8EA;
        }

        td{
            border-right:1px solid #C1DAD7;
            border-bottom:1px solid #C1DAD7;
            padding:6px 6px 6px 6px;
            color:#4f6b72;
            background:#fff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

    <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupPosition="Right" TargetControlID="txtDogumTarihi"></asp:CalendarExtender> 


    <table class="auto-style1">
        <thead>
            <tr>
                <th>Üye Kayıt</th>

            </tr>

        </thead>

        <tr>
            <td class="auto-style2">Kullanıcı adı:</td>
            <td>
                <asp:TextBox ID="txtKullaniciAdi" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Şifre:</td>
            <td>
                <asp:TextBox ID="txtSifre" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Şifre Tekrar:</td>
            <td>
                <asp:TextBox ID="txtSifreTekrar" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Email:</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Ad:</td>
            <td>
                <asp:TextBox ID="txtAd" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Soyad:</td>
            <td>
                <asp:TextBox ID="txtSoyad" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Doğum tarihi:</td>
            <td>
                <asp:TextBox ID="txtDogumTarihi" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Cinsiyet:</td>
            <td>
                <asp:RadioButton ID="rbBay" runat="server" Text="Bay" GroupName="Cinsiyet" />
                <asp:RadioButton ID="rbBayan" runat="server" Text="Bayan" GroupName="Cinsiyet" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Telefon:</td>
            <td>
                <asp:TextBox ID="txtTelefon" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Şehir:</td>
            <td>
                <asp:DropDownList ID="drpSehir" runat="server" OnSelectedIndexChanged="drpSehir_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">İlçe:</td>
            <td>
                <asp:DropDownList ID="drpIlce" runat="server" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Adres:</td>
            <td>
                <asp:TextBox ID="txtAdres" runat="server" Height="89px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>
                <asp:Button ID="btnKaydet" runat="server" Text="Kaydet" OnClick="btnKaydet_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
