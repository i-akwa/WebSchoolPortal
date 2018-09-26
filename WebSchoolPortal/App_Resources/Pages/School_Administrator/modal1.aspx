<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modal1.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.School_Administrator.modal" %>

<!DOCTYPE html>

<


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
<link href="../../css/app.v1.css" rel="stylesheet" />
    <link href="../../css/font.css" rel="stylesheet" />
    <link href="../../js/fuelux/fuelux.css" rel="stylesheet" />

</head>
<body>
    
<div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">&times;</button>
            <h4 class="modal-title">Modal title</h4>
        </div>
        <div class="modal-body">
     <form id="form1" runat="server">

    <div>
    
    </div>
    </form> </div>
        <div class="modal-footer"><a href="#" class="btn btn-default" data-dismiss="modal">Close</a> <a href="#" class="btn btn-primary">Save</a> </div>
    </div>
    <!-- /.modal-content -->
</div><!-- /.modal-dialog -->

   <script type="text/javascript" src="<%= ResolveUrl("~/App_Resources/js/app.plugin.js") %>"></script>
 <script type="text/javascript" src="<%= ResolveUrl("~/App_Resources/js/fuelux/fuelux.js") %>"></script>
 <script type="text/javascript" src="<%= ResolveUrl("~/App_Resources/js/parsley/parsley.min.js") %>"></script>
 <script type="text/javascript" src="<%= ResolveUrl("~/App_Resources/js/app.plugin.js") %>"></script>
  
</body>
</html>
