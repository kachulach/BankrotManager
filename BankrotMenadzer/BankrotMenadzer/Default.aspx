<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BankrotManager.Default" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentplaceHolder1" runat="server">
    <script src="Scripts/bm_chart.js"></script>
    <script src="Scripts/TransactionsAPI.js"></script>
    <script src="Scripts/randomColor.js"></script>
    <script src="Scripts/Chart.min.js"></script>
    <script src="Scripts/validator.js"></script>
    <script src="Scripts/Page JS/home.js"></script>

    <div class="row">
        <div class="col-xs-8">
            <form role="form" data-toggle="validator">
                <div class="row">

                    <div class="col-xs-6">
                        <div class="form-group">
                            <label for="name">Transaction name:</label>
                            <input class="form-control" id="name" placeholder="Transaction name" required>
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>
                    <div class="col-xs-6">
                        <div class="form-group">
                            <label for="amount">Amount:</label>
                            <div class="input-group">
                                <div class="input-group-addon">MKD</div>
                                <input type="number" min="0" class="form-control" id="amount" placeholder="Amount" required>
                                <div class="input-group-addon">.00</div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">

                    <div class="col-xs-6 col-xs-offset-0">
                        <div class="form-group">
                            <label for="category">Category:</label>
                            <div class="dropdown">
                                <button class="btn btn-default btn-block dropdown-toggle" type="button" id="category" data-toggle="dropdown" value="0">
                                    Choose category
                                <span class="caret"></span>
                                </button>
                                <ul class="dropdown-menu" role="menu" aria-labelledby="menu1">
                                    <asp:Repeater ID="repeater_categories" runat="server">
                                        <ItemTemplate>
                                            -                                      
                                            <li role="presentation"><a role="menuitem" data-id="<%# DataBinder.Eval(Container.DataItem, "Key") %>" href="#"><%# DataBinder.Eval(Container.DataItem, "Value") %></a></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-6">
                        <div class="form-group">
                            <label for="comment">Comment:</label>
                            <input class="form-control" id="comment" placeholder="Comment">
                        </div>
                    </div>

                </div>
                <div class="row">
                    <div class="col-xs-2">
                        <button class="btn btn-success btn-block" id="transaction-add" type="submit"><span class="glyphicon glyphicon-plus"></span>Income</button>
                    </div>
                    <div class="col-xs-3">
                        <button class="btn btn-danger btn-block" id="transaction-remove" type="submit"><span class="glyphicon glyphicon-minus"></span>Spending</button>
                    </div>
                    <div class="col-xs-2">
                        <button class="btn btn-warning btn-block" id="transaction-transfer" type="submit"><span class="glyphicon glyphicon-euro"></span>Save</button>
                    </div>
                    <div class="col-xs-3">
                        <button class="btn btn-primary btn-block" id="transaction-wishlist" type="submit"><span class="glyphicon glyphicon-piggy-bank"></span>Add to wishlist</button>
                    </div>
                    <div class="col-xs-2">
                        <button class="btn btn-info btn-block" id="transaction-clear-form"><span class="glyphicon glyphicon-remove"></span>Clear form</button>
                    </div>
                </div>
                <div class="row">
                    <div style="height: 20px"></div>
                </div>
                <div class="row">
                    <div class="col-xs-12 text-center">
                        <span id="message-success" class="alert alert-success text-center hidden" role="alert">Message about transaction here</span>
                    </div>
                </div>
            </form>
        </div>
        <div class="col-xs-4">
            <label>Affordable items from Wishlist</label>
            <div class="table-responsive">
                <table class="table table-striped text-center" style="vertical-align: middle">
                    <tbody>
                        <asp:Repeater runat="server" ID="repeater_wishlist">
                            <ItemTemplate>
                                <tr class="active">
                                    <td style="vertical-align: middle"><%# DataBinder.Eval(Container.DataItem, "Name") %></td>
                                    <td style="vertical-align: middle"><%# DataBinder.Eval(Container.DataItem, "Amount") %> MKD</td>
                                    <td><a class="btn btn-xs buy-wishlist-item" data-id="<%# DataBinder.Eval(Container.DataItem, "ID") %>">Buy now!</a></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>

    </div>
    <hr />
    <div class="row">
        <div class="col-xs-3 col-xs-offset-2">
            <div class="pie-chart-week">
                <h3>Income chart</h3>
                <canvas id="chart_weekSpendings"></canvas>
                <div class="chart-legend">
                </div>
            </div>
        </div>
        <div class="col-xs-3 col-xs-offset-2">
            <div id="pie-chart-monthly">
                <h3>Spending chart</h3>
                <canvas id="chart_monthlySpendings"></canvas>
                <div class="chart-legend">
                </div>
            </div>
        </div>
    </div>

</asp:Content>
