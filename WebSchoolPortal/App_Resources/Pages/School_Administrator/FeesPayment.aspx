<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="FeesPayment.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.School_Administrator.FeesPayment" %>
<%@ MasterType VirtualPath="~/App_Resources/MasterPage/AppMaster.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .form-control {
            width: 80%;
        }
        #MidBodyPlacholder_Balance {
            display: inline-block;
        }
        #MidBodyPlacholder_Pay {
            width: 80%;
        }
         @media (max-width: 992px) {
            .form-control {
                width: 100%;
            }
             #MidBodyPlacholder_Pay {
                width: 100%;
            }
       }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">
     <asp:ScriptManager ID="scriptManager1" runat="server" />
    <link href="../../js/select2/theme.css" rel="stylesheet" />
    <link href="../../js/fuelux/fuelux.css" rel="stylesheet" />

   
     <div class="alert alert-info">
            <button type="button" class="close" data-dismiss="alert">×</button>
            <i class="fa fa-info-sign"></i><span style="font-size:small; color:red; animation:ease-in; color:red;"><strong>Notice!</strong>When Paying Fees: Ensure you check the right checkbox(s) if student fall under the categories. <a href="#" class="alert-link"></a></span>

        </div>
    
    <asp:UpdatePanel ID="HoldPostBack" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <section class="panel panel-default">
                <header class="panel-heading font-bold">Pay Fees </header>
                <div class="panel-body">
                    <div class=" form form-horizontal">

                        <div class="form-group">
                            <label class="col-sm-2 control-label">Fees Categories</label>


                            <div class="col-sm-10">
                                <div class="checkbox">
                                    <label>
                                        <asp:CheckBox ID="chkIsBorder" runat="server" AutoPostBack="true" Checked="false" OnCheckedChanged="chkIsBorder_CheckedChanged" />
                                        Boarder
                                    </label>
                                </div>

                                <div class="checkbox">
                                    <label>
                                        <asp:CheckBox ID="chkIsNewStudent" Checked="false" Enabled="true" AutoPostBack="true" runat="server" OnCheckedChanged="chkIsNewStudent_CheckedChanged" />
                                        New student
                                    </label>
                                </div>
                                <div class="checkbox">
                                    <label>
                                        <asp:CheckBox ID="ChkNewSenior" runat="server" AutoPostBack="true" Checked="false" OnCheckedChanged="ChkNewSenior_CheckedChanged" />
                                        New senior student
                                    </label>
                                </div>
                            </div>

                        </div>


                        <div class="line line-dashed line-lg pull-in"></div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">School ID</label>
                            <div class="col-sm-10">

                                <asp:TextBox ID="SchoolId" type="text" runat="server" CssClass="form-control" Enabled="False" placeholder="input school id" />

                            </div>
                        </div>
                        <div class="line line-dashed line-lg pull-in"></div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Student Roll Number</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="StudentRollNum" runat="server" CssClass="form-control" OnTextChanged="StudentRollNum_TextChanged" AutoPostBack="True" placeholder="input Roll Number" />
                                <asp:RequiredFieldValidator ID="rollReq" runat="server" ControlToValidate="StudentRollNum" ForeColor="Red" ErrorMessage="Roll number Required" Text="Field Required" ValidationGroup="feesP" />
                            </div>
                        </div>
                        <div class="line line-dashed line-lg pull-in"></div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Student Name</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="StudentName" runat="server" CssClass="form-control" ReadOnly="true" placeholder="Student Name" />
                                <asp:RequiredFieldValidator ID="studNa" runat="server" ControlToValidate="StudentName" ErrorMessage="Student Name Required" Text="Field Required" ForeColor="Red" ValidationGroup="feesP" />
                            </div>
                        </div>
                        <div class="line line-dashed line-lg pull-in"></div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Payment date</label>
                            <div class="col-sm-10">

                                <asp:TextBox ID="date" runat="server" CssClass="form-control" Enabled="False" placeholder="Payment date" />
                                <asp:RequiredFieldValidator ID="DateVal" runat="server" ControlToValidate="date" ErrorMessage="Date required" Text="Firld required" ForeColor="Red" ValidationGroup="feesP" />

                            </div>
                        </div>
                        <div class="line line-dashed line-lg pull-in"></div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Student Class</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="clas" runat="server" CssClass="form-control" Enabled="False" placeholder="Student Class" />
                            </div>
                        </div>
                        <div class="line line-dashed line-lg pull-in"></div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label">Amount To Pay</label>
                            <div class="col-sm-10">

                                <asp:TextBox ID="AmountPaied" runat="server" placeholder="amount To Pay" AutoPostBack="True" OnTextChanged="AmountPaied_TextChanged" CssClass="form-control" ReadOnly="true" />
                                <asp:RequiredFieldValidator ID="AmtReq" runat="server" ControlToValidate="AmountPaied" ForeColor="Red" Text="Amount Required " ErrorMessage="Amount to Pay Required" ValidationGroup="feesP" />
                            </div>
                        </div>
                        <div class="line line-dashed line-lg pull-in"></div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label">Actual Fees</label>
                            <div class="col-sm-10">

                                <asp:TextBox ID="FullFees" placeholder="fees" runat="server" CssClass="form-control" Enabled="False" />
                                &nbsp;
                                <asp:Label ID="lblFees" runat="server" Text="" />

                            </div>
                        </div>
                        <div class="line line-dashed line-lg pull-in"></div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Balance</label>
                            <div class="col-sm-10">

                                <asp:TextBox ID="Balance" runat="server" placeholder="balance" Enabled="False" CssClass="form-control" Width="69%" />
                                <asp:Button ID="btnBalance" runat="server" Text="Load Balance" OnClick="btnBalance_Click" Style="margin-bottom: 3px;" CssClass="btn btn-primary" />

                            </div>
                        </div>
                        <div class="line line-dashed line-lg pull-in"></div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Term</label>
                            <div class="col-sm-10">

                                <asp:TextBox ID="Term" runat="server" placeholder="term" required type="number" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="TermReq" runat="server" ControlToValidate="Term" ValidationGroup="feesP" Text="Term Required" ForeColor="Red" ErrorMessage="Term required" />

                            </div>
                        </div>
                        <div class="line line-dashed line-lg pull-in"></div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label">Status</label>
                            <div class="col-sm-10">

                                <asp:TextBox ID="Status" runat="server" placeholder="status" ReadOnly="true" CssClass="form-control" />

                            </div>
                        </div>
                        <div class="line line-dashed line-lg pull-in"></div>
                        <div class="form-group">
                            <div class="col-sm-4 col-sm-offset-2">

                                <asp:Button ID="Pay" type="submit" ValidationGroup="feesP" runat="server" Text="Pay Fees" CssClass="btn btn-success btn-block" OnClientClick="return confirm('Are you sure you want to pay fees?');" OnClick="Pay_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div aria-hidden="true" style="display: none;" class="modal" id="ajaxModal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    
                    <h4 class="modal-title">Modal title</h4>
                </div>
                <div class="modal-body">... </div>
                <div class="modal-footer"><a href="#" class="btn btn-default" data-dismiss="modal">Close</a> <a href="#" class="btn btn-primary">Save</a> </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

</asp:Content>
