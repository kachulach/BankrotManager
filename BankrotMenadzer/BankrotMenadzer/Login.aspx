<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BankrotManager.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Банкрот менаџер</title>
    <link href="content/bootstrap-3.3.4/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .container {
            width: 100%;
            text-align: center;
            min-height: 535px;
        }

        table {
            margin: auto;
        }
    </style>
</head>
<body>
    <form id="loginForm" runat="server">
        <nav class="navbar navbar-default" role="navigation">
            <div class="container-fluid">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-responsive-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand">Bankrupt Manager</a>
                    <span class="navbar-brand glyphicon glyphicon-piggy-bank"></span>
                </div>
                <div class="navbar-collapse collapse navbar-responsive-collapse">
                    <ul class="nav navbar-nav navbar-right" style="padding-right: 30px;">
                        <div class="navbar-form navbar-left" role="search" aria-orientation="vertical">
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" placeholder="Username" ID="tbUsername" runat="server"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tbUsername" Display="Dynamic" ErrorMessage="Enter username!" ForeColor="Red" ValidationGroup="group1" SetFocusOnError="True" Visible="True"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" placeholder="Password" ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tbPassword" Display="Dynamic" ErrorMessage="Enter password!" ForeColor="Red" ValidationGroup="group1" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnLogin" CssClass="form-control btn btn-primary" runat="server" OnClick="btnNajaviSe_Click" Text="Log In" Width="160" ValidationGroup="group1" />
                            </div>
                        </div>
                    </ul>
                </div>
            </div>
        </nav>
        <div class="container">
            <div class="row">
                <div class="row">
                            <div class="page-header">
                                <h1 style="al">Welcome to Bankrupt Manager! <small>The best manager for your cash!</small></h1>
                            </div>
                        </div>
                <div class="col-md-2">
                </div>
                <div class="col-md-8">                                          
                   <div class="row">
                            <div class="col-md-6">
                                <div class="row">
                                    <img width="300px" src="Content/image/logo.jpg" style="padding-left: 5px; padding-right: 3px;" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="row">
                                    <h3>Register now! It's free!</h3>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:TextBox placeholder="Name" CssClass="form-control" ID="tbNameReg" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbNameReg" Display="Dynamic" ErrorMessage="What's your name?" ForeColor="Red" ValidationGroup="group2"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-4">
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:TextBox placeholder="Username" CssClass="form-control" ID="tbUserNameReg" runat="server" OnTextChanged="tbUserNameReg_TextChanged"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbUserNameReg" Display="Dynamic" ErrorMessage="Enter an username" ForeColor="Red" ValidationGroup="group2"></asp:RequiredFieldValidator>
                                            <asp:Label ID="lblUsernameExists" runat="server" ForeColor="Red" Text="Username already exists!" Visible="False"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:TextBox placeholder="Password" CssClass="form-control" ID="tbPasswordReg" runat="server" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbPasswordReg" Display="Dynamic" ErrorMessage="Choose password" ForeColor="Red" ValidationGroup="group2"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:TextBox placeholder="Email" CssClass="form-control" ID="tbEmailReg" runat="server" TextMode="Email"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbEmailReg" Display="Dynamic" ErrorMessage="Enter your email" ForeColor="Red" ValidationGroup="group2"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <asp:Button CssClass="form-control btn btn-success" ID="btnRegistrirajSe" runat="server" OnClick="btn_Click" Text="Register" Width="160" ValidationGroup="group2" />
                                        <asp:Label runat="server" ID="lblError"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>                    
                </div>
                <div class="col-md-2">
                </div>
            </div>
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
