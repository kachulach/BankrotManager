<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="BankrotManager.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentplaceHolder1" runat="server">
    <div class="h1 text-center">History</div>
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
                                    <th class="text-center">Numbor of transactions</th>
                                    <th class="text-center">Total %</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr class="active">
                                    <td>/index.html</td>
                                    <td>1265</td>
                                    <td>32.3%</td>
                                    <td>$321.33</td>
                                </tr>
                                <tr class="success">
                                    <td>/about.html</td>
                                    <td>261</td>
                                    <td>33.3%</td>
                                    <td>$234.12</td>
                                </tr>
                                <tr class="warning">
                                    <td>/sales.html</td>
                                    <td>665</td>
                                    <td>21.3%</td>
                                    <td>$16.34</td>
                                </tr>
                                <tr class="danger">
                                    <td>/blog.html</td>
                                    <td>9516</td>
                                    <td>89.3%</td>
                                    <td>$1644.43</td>
                                </tr>
                                <tr>
                                    <td>/404.html</td>
                                    <td>23</td>
                                    <td>34.3%</td>
                                    <td>$23.52</td>
                                </tr>
                                <tr>
                                    <td>/services.html</td>
                                    <td>421</td>
                                    <td>60.3%</td>
                                    <td>$724.32</td>
                                </tr>
                                <tr>
                                    <td>/blog/post.html</td>
                                    <td>1233</td>
                                    <td>93.2%</td>
                                    <td>$126.34</td>
                                </tr>
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
                            </tr>
                        </thead>
                        <tbody>
                            <tr class="active">
                                <td>/index.html</td>
                                <td>1265</td>
                                <td>32.3%</td>
                                <td>$321.33</td>
                            </tr>
                            <tr class="success">
                                <td>/about.html</td>
                                <td>261</td>
                                <td>33.3%</td>
                                <td>$234.12</td>
                            </tr>
                            <tr class="warning">
                                <td>/sales.html</td>
                                <td>665</td>
                                <td>21.3%</td>
                                <td>$16.34</td>
                            </tr>
                            <tr class="danger">
                                <td>/blog.html</td>
                                <td>9516</td>
                                <td>89.3%</td>
                                <td>$1644.43</td>
                            </tr>
                            <tr>
                                <td>/404.html</td>
                                <td>23</td>
                                <td>34.3%</td>
                                <td>$23.52</td>
                            </tr>
                            <tr>
                                <td>/services.html</td>
                                <td>421</td>
                                <td>60.3%</td>
                                <td>$724.32</td>
                            </tr>
                            <tr>
                                <td>/blog/post.html</td>
                                <td>1233</td>
                                <td>93.2%</td>
                                <td>$126.34</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
