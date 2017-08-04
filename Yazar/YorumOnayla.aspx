<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="YorumOnayla.aspx.cs" Inherits="EsnafBlogu.Yazar.YorumOnayla" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


    <table class="auto-style1">
        <tr>
            <td style="width: 238px">Kategoriler:</td>
            <td>
                <asp:DropDownList ID="ddlKategoriler" runat="server" Width="223px" AutoPostBack="True" OnSelectedIndexChanged="ddlKategoriler_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">

                <asp:GridView ID="grdYorumlar" runat="server" AutoGenerateColumns="false">

                    <Columns>
                        <asp:TemplateField HeaderText="MakaleBaslik">

                            <ItemTemplate>
                                <%#Eval("Baslik").ToString().Length>50? Eval("Baslik").ToString().Substring(0,50)+"..." : Eval("Baslik").ToString() %>
                            </ItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Yorum">

                            <ItemTemplate>

                                <%#Eval("YorumIcerik").ToString().Length>50? Eval("YorumIcerik").ToString().Substring(0,50)+"...":Eval("YorumIcerik").ToString() %>
                            </ItemTemplate>

                        </asp:TemplateField>


                        <asp:TemplateField>
                            <ItemTemplate>

                                <a href="<%# "OnaylamaSayfasi.aspx?yid="+ Eval("YorumID") %>">Yorumu Onayla</a>

                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>

                </asp:GridView>

            </td>

        </tr>
    </table>




</asp:Content>
