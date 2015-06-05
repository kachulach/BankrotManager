<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BankrotManager.Default" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentplaceHolder1" runat="server">
    <script src="Scripts/bm_chart.js"></script>
    <script src="Scripts/TransactionsAPI.js"></script>
    <script src="Scripts/randomColor.js"></script>
    <script src="Scripts/Chart.min.js"></script>
    <script src="Scripts/Page JS/home.js"></script>
    <div class="row">
        <div class="page-header">
            <h1>Welcome back! <small>You can see your current funds and you can create new transactions on this page. Also, you can check your weekly report and things in your wishlist that you can afford.</small></h1>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <div class="h3 text-center">Current funds:</div>
        </div>
        <div class="col-md-6">
            <div class="h3 text-center">Affordable items in wishlist:</div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <div class="h1 text-center" style="font-size: 72px"><b>15000</b><small> MKD</small></div>
        </div>
        <div class="col-md-6">
            <div class="table-responsive">
                <table class="table table-striped text-center" style="vertical-align: middle">
                    <tbody>
                        <tr class="active">
                            <td>Banana</td>
                            <td>1265 MKD</td>
                            <td><a class="btn btn-default">Buy now!</a></td>
                        </tr>
                        <tr class="active">
                            <td>Maslinka</td>
                            <td>261 MKD</td>
                            <td><a class="btn btn-default">Buy now!</a></td>
                        </tr>
                        <tr class="active">
                            <td>UESBE Kabel</td>
                            <td>665 MKD</td>
                            <td><a class="btn btn-default">Buy now!</a></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-md-12">
            <div class="h2 text-center">Transactions - <small>Fill out the form below to add a new transaction</small></div>
        </div>
    </div>
    <div class="row">
        <form role="form">
            <div class="row">
                <div class="col-md-2">
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="name">Transaction name:</label>
                        <input class="form-control" id="name" placeholder="Transaction name">
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="amount">Amount:</label>
                        <div class="input-group">
                            <div class="input-group-addon">MKD</div>
                            <input type="text" class="form-control" id="amount" placeholder="Amount">
                            <div class="input-group-addon">.00</div>
                        </div>
                    </div>
                </div>
                <div class="col-md-2">
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="category">Category:</label>
                        <div class="dropdown">
                            <button class="btn btn-default btn-block dropdown-toggle" type="button" id="category" data-toggle="dropdown">
                                Choose category
                                <span class="caret"></span>
                            </button>
                            <ul class="dropdown-menu" role="menu" aria-labelledby="menu1">
                                <asp:Repeater ID="repeater_categories" runat="server">
                                    <ItemTemplate>
-                                       <li role="presentation"><a role="menuitem" tabindex="-1" href="#"><%# DataBinder.Eval(Container.DataItem, "Name") %></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="comment">Comment:</label>
                        <input class="form-control" id="comment" placeholder="Comment">
                    </div>
                </div>
                <div class="col-md-2">
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                </div>
                <div class="col-md-2">
                    <!-- Transactions -->
                    <!-- Income -->
                    <button class="btn btn-success btn-block" id="transaction-add"><span class="glyphicon glyphicon-plus"></span>Add income</button>
                </div>
                <div class="col-md-2">
                    <button class="btn btn-danger btn-block"><span class="glyphicon glyphicon-minus"></span>Add expenditure</button>
                </div>
                <div class="col-md-2">
                    <button class="btn btn-primary btn-block"><span class="glyphicon glyphicon-piggy-bank"></span>Add to wishlist</button>
                </div>
                <div class="col-md-2">
                    <button class="btn btn-default btn-block"><span class="glyphicon glyphicon-remove"></span>Clear form</button>
                </div>
                <div class="col-md-1">
                </div>
            </div>
        </form>
    </div>
    <hr />
    <div class="row">
        <div class="col-md-12">
            <div class="h2 text-center">Spending reports - <small>Nice looking charts of your weekly and monthly spendings</small></div>
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-md-6">
            <div class="pie-chart-week">
                <canvas id="chart_weekSpendings" width="400" height="400"></canvas>
                <div class="chart-legend">
                </div>
            </div>
        </div>
        <div class="col-md-1">
        </div>
        <div class="col-md-6">
            <div id="pie-chart-monthly">
                <canvas id="chart_monthlySpendings" width="400" height="400"></canvas>
                <div class="chart-legend">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
