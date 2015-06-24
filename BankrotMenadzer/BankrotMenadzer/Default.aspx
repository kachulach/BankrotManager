<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BankrotManager.Default" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentplaceHolder1" runat="server">
    <script src="Scripts/bm_chart.js"></script>
    <script src="Scripts/TransactionsAPI.js"></script>
    <script src="Scripts/randomColor.js"></script>
    <script src="Scripts/Chart.min.js"></script>
    <script src="Scripts/validator.js"></script>
    <script src="Scripts/Page JS/home.js"></script>

    <div class="row">
        <form role="form" data-toggle="validator">
            <div class="row">
                <div class="col-md-2">
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="name">Transaction name:</label>
                        <input class="form-control" id="name" placeholder="Transaction name" required>    
                        <div class="help-block with-errors"></div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="amount">Amount:</label>
                        <div class="input-group">
                            <div class="input-group-addon">MKD</div>
                            <input type="number" min="0" class="form-control" id="amount" placeholder="Amount" required>
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
                            <button class="btn btn-default btn-block dropdown-toggle" type="button" id="category" data-toggle="dropdown" value="0">
                                Choose category
                                <span class="caret"></span>
                            </button>
                            <ul class="dropdown-menu" role="menu" aria-labelledby="menu1">
                                <asp:Repeater ID="repeater_categories" runat="server">
                                    <ItemTemplate>
-                                       <li role="presentation"><a role="menuitem" data-id="<%# DataBinder.Eval(Container.DataItem, "Key") %>" href="#"><%# DataBinder.Eval(Container.DataItem, "Value") %></a></li>
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
                    <button class="btn btn-success btn-block" id="transaction-add" type="submit"><span class="glyphicon glyphicon-plus"></span> Income</button>
                </div>
                <div class="col-md-2">
                    <button class="btn btn-danger btn-block" id="transaction-remove" type="submit"><span class="glyphicon glyphicon-minus"></span> Spending</button>
                </div>
                <div class="col-md-2">
                    <button class="btn btn-warning btn-block" id="transaction-transfer" type="submit"><span class="glyphicon glyphicon-euro"></span> Save</button>
                </div>
                <div class="col-md-2">
                    <button class="btn btn-primary btn-block" id="transaction-wishlist" type="submit"><span class="glyphicon glyphicon-piggy-bank"></span>Add to wishlist</button>
                </div>
                <div class="col-md-2">
                    <button class="btn btn-default btn-block" id="transaction-clear-form"><span class="glyphicon glyphicon-remove"></span>Clear form</button>
                </div>
                <div class="col-md-1">
                </div>
            </div>
            <div class="row">
                <div style="height: 20px"></div>
            </div>
            <div class="row">
                <div class="col-md-12 text-center">                    
                    <span id="message-success" class="alert alert-success text-center hidden" role="alert">Message about transaction here</span>
                </div>                
            </div>
        </form>

    </div>
    <hr />
    <div class="row">
        <div class="col-md-6">
            <div class="pie-chart-week">
                <h3>Income chart</h3>
                <canvas id="chart_weekSpendings" width="250" height="250"></canvas>
                <div class="chart-legend">
                </div>
            </div>
        </div>
        <div class="col-md-1">
        </div>
        <div class="col-md-6">
            <div id="pie-chart-monthly">
                <h3>Spending chart</h3>
                <canvas id="chart_monthlySpendings" width="250" height="250"></canvas>
                <div class="chart-legend">
                </div>
            </div>
        </div>
    </div>

</asp:Content>
