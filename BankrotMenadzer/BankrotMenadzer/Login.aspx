<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BankrotManager.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Банкрот менаџер</title>
 <link href="Content/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .container {
            width: 100%;
            margin-top: 80px;
            text-align: center;
        }

        table {
            margin: auto;
        }

        .container {
            min-height: 535px;
        }
    </style>
</head>
<body>
    <form id="loginForm" runat="server">
        <div class="container">
            <table>
                <tr>
                    <td>Корисничко име:</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="tbUsername" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbUsername" Display="Dynamic" ErrorMessage="Внесете корисничко име" ForeColor="Red" ValidationGroup="group1"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>

                    <td>Лозинка:</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbPassword" Display="Dynamic" ErrorMessage="Внесете лозинка" ForeColor="Red" ValidationGroup="group1"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                    <asp:Button ID="btnLogin" runat="server" OnClick="btnNajaviSe_Click" Text="Најави се" Width="160" ValidationGroup="group1" />
                        </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>Ime:</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="tbNameReg" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbNameReg" Display="Dynamic" ErrorMessage="Внесете го Вашето име" ForeColor="Red" ValidationGroup="group2"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Korisnicko ime:</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="tbUserNameReg" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbUserNameReg" Display="Dynamic" ErrorMessage="Внесете корисничко име" ForeColor="Red" ValidationGroup="group2"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Lozinka:</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="tbPasswordReg" runat="server" TextMode="Password"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbPasswordReg" Display="Dynamic" ErrorMessage="Внесете лозинка" ForeColor="Red" ValidationGroup="group2"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>E-mail:</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="tbEmailReg" runat="server" TextMode="Email"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbEmailReg" Display="Dynamic" ErrorMessage="Внесете е-маил" ForeColor="Red" ValidationGroup="group2"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                    <asp:Button ID="btnRegistrirajSe" runat="server" OnClick="btn_Click" Text="Регистрирај се" Width="160" ValidationGroup="group2" />
                        </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
            </table>
            <br />

        </div>
    </form>

    <div>
        <nav class="navbar navbar-default navbar-bottom" style="border-top-color: #929292; color: #343233; margin-bottom: -15px;" role="note">
            <div class="navbar-footer">
                <p style="text-align: center; vertical-align: central; padding-top: 5px">Банкрот менаџер © 2015. Сите права се задржани.</p>
            </div>
        </nav>

    </div>
    <script src="Scripts/jquery-2.1.0.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>

</body>
</html>
