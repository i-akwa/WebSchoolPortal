<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReciptPage.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.School_Administrator.ReciptPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/app.v1.css" rel="stylesheet" />
    <link href="../../css/font.css" rel="stylesheet" />
    <link href="../../js/fuelux/fuelux.css" rel="stylesheet" />
</head>
<body style="background-color:#374b5e; height:600px; width:100%;">
    <div class="modal-dialog">
        <div class="modal-content">
            <header class="header b-b b-light hidden-print"> <button  class="btn btn-sm btn-info pull-right" onclick="window.print();"><i class="fa fa-print"></i>&nbsp;Print</button> <p>Invoice</p> </header>
            <div class="modal-header">

                <h4 class="modal-title"><center><asp:Label ID="Title" runat="server" /> </center></h4>
            </div>
            <div class="modal-body">
                <form id="form1" runat="server">
                    <div class="table-responsive">
                        <table class="table table-reponsive table-striped b-t b-light" >
                            <tr>
                                <td><strong>Name : </strong></td>
                                <td>
                                    <asp:Label ID="Name" runat="server" /></td>
                            </tr>
                            <tr>
                                <td><strong>Roll Number : </strong></td>
                                <td>
                                    <asp:Label ID="Roll" runat="server" /></td>
                            </tr>
                            <tr>
                                <td><strong>PaymentDate : </strong></td>
                                <td>
                                    <asp:Label ID="PayDate" runat="server" /></td>
                            </tr>
                            <tr>
                                <td><strong>Class : </strong></td>
                                <td>
                                    <asp:Label ID="Class" runat="server" /></td>
                            </tr>
                            <tr>
                                <td><strong>Fees :</strong></td>
                                <td>
                                    <asp:Label ID="Fees" runat="server" /></td>
                            </tr>
                            <tr>
                                <td><strong>Amount Paid : </strong></td>
                                <td>
                                    <asp:Label ID="AP" runat="server" /></td>
                            </tr>
                            <tr>
                                <td><strong>Term : </strong></td>
                                <td>
                                    <asp:Label runat="server" ID="Term" />
                                </td>
                            </tr>
                            <tr>
                                <td><strong>Status: </strong></td>
                                <td>
                                    <asp:Label ID="status" runat="server" /></td>
                            </tr>
                        </table>
                    </div>
                </form>
                <div class="modal-footer"><a href="FeesPayment.aspx" class="btn btn-sm btn-info hidden-print" data-dismiss="modal">Close</a> </div>
            </div>
            <!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
        </div>


  


    <script type="text/javascript" src="<%= ResolveUrl("~/App_Resources/js/app.plugin.js") %>"></script>
 <script type="text/javascript" src="<%= ResolveUrl("~/App_Resources/js/fuelux/fuelux.js") %>"></script>
 <script type="text/javascript" src="<%= ResolveUrl("~/App_Resources/js/parsley/parsley.min.js") %>"></script>
 <script type="text/javascript" src="<%= ResolveUrl("~/App_Resources/js/app.plugin.js") %>"></script>
  
</body>
</html>
