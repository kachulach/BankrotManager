<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="BankrotManager.History" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentplaceHolder1" runat="server">
    
    <script type="text/javascript" src="//cdn.jsdelivr.net/momentjs/2.9.0/moment.min.js"></script>
    <script type="text/javascript" src="//cdn.jsdelivr.net/bootstrap.daterangepicker/1/daterangepicker.js"></script>
    <link rel="stylesheet" type="text/css" href="//cdn.jsdelivr.net/bootstrap.daterangepicker/1/daterangepicker-bs3.css" />
    <script src="Scripts/Page JS/history.js"></script>

    <div class="h1 text-center">History</div>
    <div class="row">
        <div id="calendar-picker" class="selectbox">
            <button class="btn btn-success btn-block" id="button-select-date"><span class="glyphicon glyphicon-calendar"></span>Select date</button>
		</div>
    </div>
    <div class="row">
        <div class="">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title text-center"><b>Statistics</b></h3>
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
                                        <td><%# DataBinder.Eval(Container.DataItem, "Percent") %></td>
                                       
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
        <div class="panel panel-info">
            <div class="panel-heading">
                <h3 class="panel-title text-center"><b>Charts</b></h3>
            </div>
            <div class="panel-body">
                <!-- <div class="col-lg-9">-->
                <!-- progress bar -->
                <div class="progress">
                    <div class="progress-bar progress-bar-info progress-bar-striped" role="progressbar" aria-valuenow="20" aria-valuemin="0" aria-valuemax="100" style="width: 20%">
                        <span>20%</span>
                    </div>
                    <span>Pictures</span>
                </div>
                <div class="progress">
                    <div class="progress-bar progress-bar-success progress-bar-striped" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width: 40%">
                        <span>40%</span>
                    </div>
                    <span>Documents</span>
                </div>
                <div class="progress">
                    <div class="progress-bar progress-bar-warning progress-bar-striped" role="progressbar" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100" style="width: 60%">
                        <span>60%</span>
                    </div>
                    <span>Music</span>
                </div>
                <div class="progress">
                    <div class="progress-bar progress-bar-danger progress-bar-striped" role="progressbar" aria-valuenow="80" aria-valuemin="0" aria-valuemax="100" style="width: 80%">
                        <span>80%</span>
                    </div>
                    <span>Video</span>
                </div>
                <!--</div>-->
            </div>
        </div>
    </div>

    <div class="row">
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
                        <asp:Repeater runat="server" id="repeater_rawdata">
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
