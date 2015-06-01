<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MacedonianRedCrossYouth.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentplaceHolder1" runat="server">
    <style>
        tr.highlight td {
            padding-bottom: 10px;
        }

        .auto-style1 {
            width: 228px;
        }
        </style>
    <form id="form1" runat="server">
        <div style="width: 550px; margin: auto;">
            <table style="margin: auto;">
                <tr>
                    <td colspan="2" style="background-color: #bcbcbc; text-align: center;">Приходи</td>
                </tr>
                <tr>
                    <td class="tdStyle">Парични средства:<asp:Label ID="Price" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td class="auto-style1">Име на трансакцијата:<asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="tdStyle">
                        <asp:TextBox ID="tbPrice" runat="server" Width="220" TextMode="Number"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="tbName" runat="server" Width="220"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tdStyle">Категорија:<asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    </td>
                    <td class="auto-style1">Датум:<asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="tdStyle">
                        <asp:DropDownList ID="ddCategory" runat="server" Width="220">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="tbDatum" runat="server" TextMode="Date" Width="220"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tdStyle">Коментар:</td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="tdStyle">
                        <asp:TextBox ID="tbComment" runat="server" Width="220" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                        <asp:Button ID="btnAddIncome" runat="server" Text="Додади приход" OnClick="btnAddIncome_Click" Width="233px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="background-color: #bcbcbc; text-align: center;">Расходи</td>
                </tr>
                <tr>
                    <td class="tdStyle">Парични средства:<asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                    <td class="auto-style1">Име на производ/услуга:<asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="tdStyle">
                        <asp:TextBox ID="tbExpenditure" runat="server" Width="220" TextMode="Number"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="tbNameProduct" runat="server" Width="220"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tdStyle">Категорија:<asp:Label ID="Label6" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    </td>
                    <td class="auto-style1">Датум:<asp:Label ID="Label7" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="tdStyle">
                        <asp:DropDownList ID="ddCategory2" runat="server" Width="220">
                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                            <asp:ListItem Value="1">Машки</asp:ListItem>
                            <asp:ListItem Value="2">Женски</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="tbDate2" runat="server" TextMode="Date" Width="220"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tdStyle">Коментар:</td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="tdStyle">
                        <asp:TextBox ID="tbCommentExpenditure" runat="server" Width="220" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                        <asp:Button ID="btnExpenditure" runat="server" Text="Додади расход" OnClick="btnAddExpenditure_Click" Width="115px" />
                        <asp:Button ID="btnWishlist" runat="server" Text="Wishlist" OnClick="btnAddWishlist_Click" Width="113px" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
