<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="BankrotManager.History" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentplaceHolder1" runat="server">

    <script type="text/javascript" src="//cdn.jsdelivr.net/momentjs/2.9.0/moment.min.js"></script>
    <script type="text/javascript" src="//cdn.jsdelivr.net/bootstrap.daterangepicker/1/daterangepicker.js"></script>
    <link rel="stylesheet" type="text/css" href="//cdn.jsdelivr.net/bootstrap.daterangepicker/1/daterangepicker-bs3.css" />
    <script src="Scripts/Page JS/history.js"></script>

    <style>
        .removeTransaction:hover {
            color: red;
            cursor:pointer;
        }
    </style>

    <div id="message-success" class="alert text-center hidden" role="alert" style="z-index: 100; width: 200px; height: 50px; position: fixed; top: 40px; right: 10px;">
        Message about transaction here
    </div>

    <div class="h1 text-center">History</div>
    <div class="row">
        <div class="col-xs-10 col-xs-offset-1">
            
                <div id="calendar-picker" class="selectbox">
                    <button class="btn btn-success" id="button-select-date"><span class="glyphicon glyphicon-calendar"></span>Select date</button>
                </div>
            <div style="height:20px;">
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-10 col-xs-offset-1">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title text-center"><b>Category statistics</b></h3>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <table class="table table-bordered table-striped text-center">
                            <thead>
                                <tr>
                                    <th class="text-center">Category</th>
                                    <th class="text-center">Cost</th>
                                    <th class="text-center">Number of transactions</th>
                                    <th class="text-center">Total %</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="repeater_stats">
                                    <ItemTemplate>
                                        <tr class="<%# Container.ItemIndex % 2 == 0 ? "success" : "warning" %>">
                                            <td><%# DataBinder.Eval(Container.DataItem, "Category") %></td>
                                            <td><%# DataBinder.Eval(Container.DataItem, "Amount") %></td>
                                            <td><%# DataBinder.Eval(Container.DataItem, "Transactions") %></td>
                                            <td><%# Math.Abs((float)(DataBinder.Eval(Container.DataItem, "Percent"))) %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-xs-10 col-xs-offset-1">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title text-center"><b>Data</b></h3>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <table class="table table-bordered table-striped text-center">
                            <thead>
                                <tr>
                                    <th class="text-center">Name</th>
                                    <th class="text-center">Category</th>
                                    <th class="text-center">Cost</th>
                                    <th class="text-center">Date</th>
                                    <th class="text-center">Remove</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="repeater_rawdata">
                                    <ItemTemplate>
                                        <tr class="<%# Container.ItemIndex % 2 == 0 ? "success" : "warning" %>">
                                            <td><%# DataBinder.Eval(Container.DataItem, "Name") %></td>
                                            <td><%# DataBinder.Eval(Container.DataItem, "Category.Name") %></td>
                                            <td><%# DataBinder.Eval(Container.DataItem, "Amount") %></td>
                                            <td><%# DataBinder.Eval(Container.DataItem, "Date") %></td>
                                            <td class="removeTransaction" data-id="<%# DataBinder.Eval(Container.DataItem, "ID")%>"><i class="glyphicon glyphicon-remove"></i></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
