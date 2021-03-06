﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="MakaleDetay.aspx.cs" Inherits="EsnafBlogu.MakaleDetay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


    <div class="post">
        <h2 class="title"><a href="#">
            <asp:Literal  ID="ltrBaslik" runat="server" />
            </a></h2>
        <p class="meta">
            <span class="date">
                <asp:Literal ID="ltrTarih" Text="" runat="server" />
                </span>
            <span class="posted">Gönderen <a href="#">
                <asp:Literal ID="ltrGonderen" Text="" runat="server" />
                </a></span>
        </p>
        <div style="clear: both;">&nbsp;</div>
        <div class="entry">
            <p>
                <asp:Literal ID="ltrIcerik" Text="" runat="server" />

                </p>

        </div>
    </div>



    <table style="width:100%">
        <tr>
            <th style="width: 183px">Okunma Sayısı:</th>
            <td>  <asp:Literal ID="ltrOkunmaSayisi" Text="text" runat="server" /></td>
        </tr>

    </table>

    <div class="comment_list">

        <asp:Repeater ID="rptYorumlar" runat="server">
            <ItemTemplate>

                <div class="comment">

                    <div class="comment_gravatar left">

                        <img src="images/sample-gravatar.png" height="32" width="32" />
                    </div>

                    <div class="comment_author left">
                        <a href="#"><%# Eval("AdSoyad") %></a>
                        <div class="comment_date"><a href="#"><%# Eval("YorumTarihi") %></a></div>

                    </div>

                    <div class="clearer">&nbsp;</div>
                    <div class="comment_body">
                        <p>
                            <%# Eval("YorumIcerik") %>
                        </p>
                    </div>


                </div>

            </ItemTemplate>

            <SeparatorTemplate>
                <hr />
            </SeparatorTemplate>
        </asp:Repeater>



    </div>






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
                <asp:LinkButton ID="btnKaydet" runat="server" OnClick="btnKaydet_Click" OnClientClick="return confirm(&quot;Kaydetmek İstiyormusunuz? &quot;)">Kaydet</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>


    </asp:Content>