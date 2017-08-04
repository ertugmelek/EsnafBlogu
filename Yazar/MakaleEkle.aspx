<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="MakaleEkle.aspx.cs" Inherits="EsnafBlogu.Yazar.MakaleEkle" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table style="width: 100%">
        <script src="../ckeditor/ckeditor.js"></script>
        <tr>
            <td class="auto-style3" style="width: 138px">Kategorisi:</td>
            <td>
                <asp:DropDownList ID="drpKategoriler" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style3" style="width: 138px">Başlık:</td>
            <td>
                <asp:TextBox ID="txtBaslik" runat="server" Height="52px" TextMode="MultiLine" Width="186px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3" style="width: 138px">Makale İçerik:</td>
            <td>
                <textarea class="ckeditor" id="editor1" name="S1" style="height: 127px; width: 299px" runat="server"></textarea></td>
        </tr>
        <tr>
            <td class="auto-style3" style="width: 138px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3" style="width: 138px">&nbsp;</td>
            <td>
                <asp:Button ID="btnMakaleKaydet" runat="server" Text="Makale Kaydet" OnClick="btnMakaleKaydet_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3" style="width: 138px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
