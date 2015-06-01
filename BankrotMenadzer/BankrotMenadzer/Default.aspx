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
                    <td colspan="2" style="background-color: #bcbcbc; text-align: center;">Приходи / Расходи / Желботека</td>
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
                        <asp:ImageButton ID="btnIncome" runat="server" Height="24px" ImageAlign="Middle" ImageUrl="~/Content/image/add.png" OnClick="btnAddIncome_Click" Width="24px" />
                        <asp:ImageButton ID="btnExpenditure" runat="server" Height="30px" ImageAlign="Middle" ImageUrl="~/Content/image/minus.png" OnClick="btnAddExpenditure_Click" Width="30px" />
                        <asp:ImageButton ID="btnWishlist" runat="server" Height="30px" ImageAlign="Middle" ImageUrl="~/Content/image/wishlist.png" OnClick="btnAddWish_Click" Width="30px" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
