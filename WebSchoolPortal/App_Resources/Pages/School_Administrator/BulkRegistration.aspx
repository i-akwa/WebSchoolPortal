<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="BulkRegistration.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.School_Administrator.BulkRegistration" %>

<%@ MasterType VirtualPath="~/App_Resources/MasterPage/AppMaster.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">

    <div class="alert alert-info">
            <button type="button" class="close" data-dismiss="alert">×</button>
            <i class="fa fa-info-sign"></i><strong>Heads up!</strong> NOTE THAT:<a href="#" class="alert-link"></a> Excel Sheets Should First Be Downloaded And Student or Teachers Information Filled In Respectively Before Uploading Back To The Portal,Thanks... </div>

    <div class="panel panel-default">
        <header class="panel-heading font-bold">Add Student In Bulk <ul class="nav nav-pills pull-right"> <li> <asp:LinkButton ID="lnkdownload"  runat="server" Text="Download blank excel file" CssClass="btn btn-xs btn-success   btn-editProfile" OnClick="lnkdownload_Click1" ><i class="fa fa-download"></i>&nbsp;Download excel</asp:LinkButton>
                        
                    </li> </ul><i title="" data-original-title="" class="fa fa-info-sign text-muted" data-toggle="tooltip" data-placement="bottom" data-title="ajax to load the data."></i></header>
        <div class="table-responsive">
            <table id="MyStretchGrid" class="table table-striped datagrid m-b-sm">
                <thead>
                </thead>
                <tbody>
                    <tr>
                        <td style="text-align: center; padding: 20px; border-bottom: none;" colspan="5">
                            <div class="form-group">
						
                                <label class="col-lg-2 control-label">Select Excel File</label>
                        
						<div class="col-sm-5">
                        	<asp:FileUpload ID="UploadXcel" runat="server"   />
                            </div>
					</div>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center; padding: 20px; border-bottom: none;" colspan="5">
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Class</label>
                                <div class="col-sm-5">
                                    <select name="class_id" class="form-control" data-validate="required" data-message-required="Value Required">
                                        <option value="">Select</option>
                                        <option value="1">One</option>
                                        <option value="2">Two</option>
                                        <option value="3">Three</option>
                                        <option value="4">Four</option>
                                    </select>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td >
                            <div class="form-group">
                                <!--<asp:button ID="Upload" runat="server" Text="Upload Excel"  CssClass="btn btn-primary" />-->

                                <asp:LinkButton ID="Upload2" runat="server" CssClass="btn btn-primary pull-right" OnClick="Upload_Click"><i class="fa fa-upload"></i>&nbsp;Upload excel</asp:LinkButton>
                            </div>
                        </td>
                    </tr>

                </tbody>

            </table>
        </div>
    </div>

</asp:Content>
