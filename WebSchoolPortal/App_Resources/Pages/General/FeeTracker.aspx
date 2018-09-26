﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="FeeTracker.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.School_Administrator.FeeTracker" %>
<%@ MasterType VirtualPath="~/App_Resources/MasterPage/AppMaster.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">
    


    <div class="alert alert-info">
            <button type="button" class="close" data-dismiss="alert">×</button>
            <i class="fa fa-info-sign"></i><span style="font-size:small; color:red; animation:ease-in;"><strong>Heads up!</strong>Track all student fees by either student Id or by the student class and update them if need be, Thanks..... <a href="#" class="alert-link"></a></span>

        </div>

    <section class="panel panel-default">
        <header class="panel-heading">Fee Tracker<i title="" data-original-title="" class="fa fa-info-sign text-muted" data-toggle="tooltip" data-placement="bottom" data-title="ajax to load the data."></i></header>

        <div class="panel-body">
            <div class="col-sm-2">
                <div class="dataTables_length">
                    <asp:TextBox ID="SchoolId" runat="server" Placeholder="School Id" ReadOnly="true" CssClass="input-control text form-control  input-group" />
                </div>
            </div>
            <div class="col-sm-2">
                <div class="dataTables_length">
                    <asp:TextBox ID="Year" runat="server" Placeholder="Year" CssClass="input-control text form-control  input-group" />
                    <asp:RequiredFieldValidator ID="req1" ForeColor="red" runat="server" ControlToValidate="Year" Text="Year Required" ErrorMessage="Year Required" ValidationGroup="Vg"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-sm-2">

               <div class="dataTables_length">
                    <asp:TextBox ID="Term" runat="server" Placeholder="Term" CssClass="input-control text form-control  input-group" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="red" runat="server" ControlToValidate="Term" Text="Term Required" ErrorMessage="Term Required" ValidationGroup="Vg"></asp:RequiredFieldValidator>
                </div>

            </div>
            <div class="col-sm-2">
                <div class="dataTables_length">
                    <asp:DropDownList ID="ddlClass" runat="server" CssClass="input-control text form-control  input-group" />

                </div>
            </div>
            <div class="col-sm-2">

               <div class="dataTables_length">
                    <asp:TextBox ID="StudentId" runat="server" Placeholder="Student Id" CssClass="form-control" />

                </div>
            </div>
            <div class="col-sm-2">
               

                    
                        <button aria-expanded="false" class="btn btn-success dropdown-toggle pull-right" data-toggle="dropdown"><i class="fa fa-print"></i>&nbsp;Search By <span class="caret"></span></button>
                        <ul class="dropdown-menu">
                            <li>
                                <asp:Button aria-expanded="false" ID="ButtonClassSearch" runat="server" class="btn btn-primary" Text="Class" OnClick="ButtonClassSearch_Click" ValidationGroup="Vg" /></li>
                            <li>
                                <asp:Button aria-expanded="false" ID="Button1" runat="server" class="btn btn-primary" OnClick="Button1_Click" Text="Student ID" ValidationGroup="Vg" /></li>
                        </ul>
                    </div>
               
         
            
            
            <div class="table table-responsive">

                <asp:GridView ID="Tracker" runat="server" AutoGenerateColumns="false" AutoGenerateEditButton="false" AutoGenerateDeleteButton="false" OnRowCommand="Tracker_RowCommand" CssClass="table table-responsive table-hover" Width="100%" GridLines="None">
                    <Columns>
                        <asp:BoundField HeaderText="Student Roll" DataField="studentRollnum"  />
                        <asp:BoundField HeaderText="Student Name" DataField="name"  />
                        <asp:BoundField HeaderText="Amount Paid" DataField="amountPaid"  />
                        <asp:BoundField HeaderText="Actual Fees" DataField="Fees"  />
                        <asp:BoundField HeaderText="Status" DataField="Status" />



                        <asp:TemplateField >
                            <ItemTemplate>
                                <asp:LinkButton CssClass="btn btn-success btn-sm pull-right shower" ID="Edt" runat="server" Text="Edit" CommandArgument='<%#Bind("studentRollnum") %>' CommandName="edt"><i class="fa fa-save"></i>&nbsp;Update</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>

            </div>
            <div style="display: none;" class="dataTables_processing" id="DataTables_Table_0_processing">Processing...</div>
        </div>

    </section>

    <section class="panel panel-default" >
        <%--<header class="panel-heading">Fee Tracker<i title="" data-original-title="" class="fa fa-info-sign text-muted" data-toggle="tooltip" data-placement="bottom" data-title="ajax to load the data."></i></header>
        --%>
        <div class="panel-body" >
            <div class="col-md-2">
                <asp:TextBox ID="Name" runat="server" ReadOnly="true" Placeholder="Student Name" CssClass="form-control"  />
            </div>
            <div class="col-md-2">
                <div class="dataTables_length">
                    <asp:TextBox ID="AmountPaied" runat="server" Placeholder="Amount Paid" ReadOnly="true" CssClass="form-control" />
                </div>
            </div>

            <div class="col-md-2">
                <div class="dataTables_length">
                    <asp:TextBox ID="balance" runat="server" Placeholder="Balance" CssClass="form-control" OnTextChanged="balance_TextChanged" />
                </div>
            </div>

            <div class="col-md-2">
                <div class="dataTables_length">
                    <asp:TextBox ID="ActualFees" runat="server" Placeholder="Actual Fees" CssClass="form-control" ReadOnly="true" />
                </div>
            </div>
            <div class="col-md-2">

                <div class="dataTables_length">
                    <asp:TextBox ID="Status" runat="server" Visible="true" Placeholder="Status" CssClass="form-control" />
                </div>
            </div>

            <div class="col-md-2">
                <asp:Button ID="ButtonUpdateFees" runat="server" OnClick="ButtonUpdateFees_Click" Text="Update" CssClass="btn btn-success btn-block pull-right" />
            </div>
        </div>
    </section>
</asp:Content>