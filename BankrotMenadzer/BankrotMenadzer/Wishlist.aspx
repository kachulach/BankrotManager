<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="Wishlist.aspx.cs" Inherits="BankrotManager.Wishlist" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentplaceHolder1" runat="server">
    <script src="Scripts/Page JS/wishlist.js"></script>

    <style>
        .remove-wishlist-item:hover {
            color: red;
            cursor:pointer;
        }
    </style>
    <div class="h1 text-center">Wishlist</div>

    <div class="row">
         <div class="col-xs-10 col-xs-offset-1">
        <div class="panel panel-info">
            <div class="panel-heading">
                <h3 class="panel-title text-center"><b>Wishlist</b></h3>
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
                                <th class="text-center">Buy</th>
                                <th class="text-center">Remove</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="repeater_wishlist">
                                <ItemTemplate>
                                    
                                    <tr class="<%# GetClass(DataBinder.Eval(Container.DataItem, "Amount").ToString()) %>">
                                        <td><%# DataBinder.Eval(Container.DataItem, "Name") %></td>
                                        <td><%# DataBinder.Eval(Container.DataItem, "Category.Name") %></td>
                                        <td><%# DataBinder.Eval(Container.DataItem, "Amount") %></td>
                                        <td><%# DataBinder.Eval(Container.DataItem, "Date") %></td>
                                        <td>
                                            <button class="btn btn-block btn-xs btn-<%# GetClass(DataBinder.Eval(Container.DataItem, "Amount").ToString()) %> buy-wishlist-item" data-id="<%# DataBinder.Eval(Container.DataItem, "ID")%>">Buy</button>
                                        </td>
                                        <td class="remove-wishlist-item" data-id="<%# DataBinder.Eval(Container.DataItem, "ID")%>"><i class="glyphicon glyphicon-remove"></i></td>
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
