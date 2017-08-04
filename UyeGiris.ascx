<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UyeGiris.ascx.cs" Inherits="EsnafBlogu.UyeGiris" %>
<style type="text/css">
    .auto-style1 {
        width: 200px;
    }

    .auto-style3 {
        width: 112px;
    }
</style>


<asp:LoginView ID="LoginView1" runat="server">
    <AnonymousTemplate>
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">Kullanıcı Adı:</td>
                <td>
                    <asp:TextBox ID="txtKullaniciAdi" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Şifre:</td>
                <td>
                    <asp:TextBox ID="txtSifre" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>
                    <asp:CheckBox ID="chbBeniHatirla" runat="server" Text="Beni Hatırla" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>
                    <asp:Button ID="btnGiris" runat="server" Text="Giriş" OnClick="btnGiris_Click" />
                </td>
            </tr>
        </table>
    </AnonymousTemplate>

    <LoggedInTemplate>
        Hoşgeldiniz, <a href="Profil.aspx">
            <asp:LoginName ID="LoginName1" runat="server" />
        </a>
        <br />
        <ul>
            <li>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Yazar/MakaleEkle.aspx">Makale Ekle</asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Yazar/YorumOnayla.aspx">Yorum Onayla</asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink runat="server" NavigateUrl="#">Makale Düzenle</asp:HyperLink>
            </li>
            <li>
                <asp:LinkButton ID="lnkCikis" runat="server" OnClick="lnkCikis_Click">Çıkış</asp:LinkButton>
            </li>
        </ul>
    </LoggedInTemplate>

</asp:LoginView>
