<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="UploadMaterials.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.Teachers.UploadMaterials" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">
    <link href="../../js/select2/select2.css" rel="stylesheet" />
    <link href="../../js/select2/theme.css" rel="stylesheet" />
    <link href="../../js/fuelux/fuelux.css" rel="stylesheet" />
     <script src="../../js/select2/select2.min.js"></script>
        <script src="../../js/fuelux/fuelux.js"></script>

    
    <div class="alert alert-success">
            <button type="button" class="close" data-dismiss="alert">×</button>
            <i class="fa fa-info-sign"></i><strong>Heads up!</strong> <a href="#" class="alert-link">Upload File:</a> Please give a brief information of the uploaded file in the description textbox. Example: the date to be submitted<br /> file name auto-generate when you choose a class</div>

   <section class="panel panel-default">
       <header class="panel-heading">
           Assignment And Exercise Uploads
       </header>
       <div class="panel-body">

            
           <div class="col-md-3 col-sm-12">
                <div class="dataTables_length">
                    <asp:DropDownList ID="Subject"  CssClass="form-control input-group" runat="server" AutoPostBack="true" CausesValidation="true" OnSelectedIndexChanged="Subject_SelectedIndexChanged" Width="100%" data-toggle="tooltip" data-placement="top" title="" data-original-title="Choose Subject"  ></asp:DropDownList>
                </div>
            </div>
          
            <div class="col-md-3 col-sm-12">
                <div class="dataTables_length">
                   <asp:DropDownList ID="clas" runat="server" Width="100%" data-toggle="tooltip" data-placement="top" title="" data-original-title="Choose Class"   CssClass="form-control  input-group" AutoPostBack="true" OnSelectedIndexChanged="clas_SelectedIndexChanged">
                    <asp:ListItem Text="Choose Class" ></asp:ListItem>
                    <asp:ListItem Text="JSS1"></asp:ListItem>
                    <asp:ListItem Text="JSS2"></asp:ListItem>
                    <asp:ListItem Text="JSS3"></asp:ListItem>
                    <asp:ListItem Text="SSS1"></asp:ListItem>
                    <asp:ListItem Text="SSS2"></asp:ListItem>
                    <asp:ListItem Text="SSS3"></asp:ListItem>
                </asp:DropDownList>
                </div>
            </div>
           
            <div class="col-md-3 col-sm-12">

               <div class="dataTables_length">
                    <asp:TextBox ID="FileName" Width="100%" data-toggle="tooltip" data-placement="top" title="" data-original-title="Assignment File Name"   CssClass="form-control  input-group" runat="server" ReadOnly="true" ValidationGroup="Upload"></asp:TextBox>
                </div>
                
            </div>
            <div class="col-md-3 col-sm-12">
                <div class="dataTables_length">
                     <asp:FileUpload data-toggle="tooltip" data-placement="top" title="" data-original-title="Choose Assignment File"   CssClass="form-control  input-group" ID="Upload1" runat="server" />
                </div>
            </div>
           
            
           <div class="col-md-12 col-sm-12" style="margin-top:10px">
               <div class="dataTables_length">
                   <asp:TextBox ID="Description" placeholder="Add Description Here" runat="server" CssClass="form-control" TextMode="MultiLine" data-toggle="tooltip" data-placement="top" title="" data-original-title="Add Description of Assignment or submission dates here" ValidationGroup="Upload" />
               </div>
           </div>
          
            <div class="col-md-6 col-sm-12" style="margin-top:10px; color:red; font-family:'Adobe Hebrew'; ">
               <asp:RequiredFieldValidator ID="FilenameValidator" runat="server" ControlToValidate="FileName" Text="Fill in File name" ErrorMessage="File name required" ValidationGroup="Upload" /><br />
               <asp:RequiredFieldValidator ID="DescriptionValidate" runat="server" ControlToValidate="Description" Text="Fill in description" ErrorMessage="Description Required" ValidationGroup="Upload" /><br />
               <asp:RequiredFieldValidator ID="uploadReq" runat="server" ControlToValidate="Upload1" ValidationGroup="Upload" Text="Choose a file to upload" ErrorMessage="Upload required" />
               <asp:RegularExpressionValidator ID="reg1" runat="server" ControlToValidate="Upload1" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.doc|.docx|.pdf|.jpeg|.jpg|.txt|.ppt|.pptx|.png|.gif)$" Text="Please upload a vailid format" ErrorMessage="valid format required" />
           </div>

            <div class="col-md-6 col-sm-6" style="margin-top:10px">
                    <asp:Button  ID="UploadFile" runat="server" class="btn btn-primary pull-right"  Text="Upload" OnClick="UploadFile_Click" ValidationGroup="Upload" />        
            </div>
          
        </div>       

   </section>
    <section class="panel panel-default">
        <div class="panel-body table table-responsive">
             <asp:GridView ID="MyUPloads" runat="server" AllowPaging="true" AutoGenerateColumns="false" CssClass="table table-responsive table-hover table-bordered" Width="100%" GridLines="None" OnRowCommand="MyUPloads_RowCommand" >
                    <Columns>
                        <asp:BoundField HeaderText="Upload Id" DataField="UploadId" />
                        <asp:BoundField HeaderText="File Name" DataField="Filename" />
                        <asp:BoundField HeaderText="Subject Name" DataField="SubjectName" />
                        <asp:BoundField HeaderText="Class" DataField="class" />
                        <asp:BoundField HeaderText="Upload Date" DataField="UploadDate" />
                         <asp:BoundField HeaderText="Description" DataField="Description" />

                        <asp:TemplateField HeaderText="Delete" >
                            <ItemTemplate>
                                <asp:LinkButton ID="dele" CssClass="btn btn-danger"  runat="server" Text="" CommandName="del" CommandArgument='<%#Bind("UploadId") %>' OnClientClick="return confirm('Are you sure you want to delete the record?');" ><i class="fa fa-cut "></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
        </div>
    </section> 
    
   
</asp:Content>
