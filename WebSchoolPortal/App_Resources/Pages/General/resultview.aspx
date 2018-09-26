<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resultview.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.General.resultview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<style>
		td {
			height: 2px;
			width: auto;
		}
		 .first {
			float: right;
			background-color: #2c7ad0;
			border: 1px solid #000000;
			color: #ffffff;
			position: relative;
			margin: 20px 0 0 20px;
		}
		.first.turn
	{

	}
		
	</style>
	 <link href="../../css/bootstrap.css" rel="stylesheet" />
	<link href="../../css/animate.css" rel="stylesheet" />
	<link href="../../css/font-awesome.min.css" rel="stylesheet" />
	<link href="../../css/font.css" rel="stylesheet" />
	<link href="../../css/app.css" rel="stylesheet" />


</head>
<body>
	<form id="form1" runat="server">
		
		<div class="col-md-8 col-md-offset-1" style="padding-bottom:10px; background-color:white">
			<asp:Label runat="server" Visible="true" ID="NoticeInfo">
	<div class="alert alert-info">
			<button type="button" class="close" data-dismiss="alert">×</button>
			<i class="fa fa-info-sign"></i><strong>Notice!</strong> <a href="#" class="alert-link"></a><b style="color:red; font-size:larger;">Note:If the results are not displaying well, it means your School grading have not been defined. Please fill the gradings in this page <a href="../School_Administrator/GradesRegulation.aspx" > Grade Regulation</a>.</b>
		</div>
			</asp:Label>
			<section class="center">
				<div class="panel panel-default">
					<div class="panel-body">
						<div class="col-md-2 img img-responsive" style="border: 1px solid black;">
							<asp:FormView ID="SchoolImage" runat="server" DataKeyNames="SchoolId" CssClass="img img-responsive">
								<ItemTemplate>
									<asp:Image CssClass="img img-full img-responsive" ID="Icon" runat="server"
										 ImageUrl='<%# String.Format("~/App_Resources/FileHandlers/ProfilePicture.ashx?SchoolId={0}", Eval("SchoolId")) %>' />
								</ItemTemplate>
							</asp:FormView>
						</div>
					<div class="col-sm-8" style="padding:2px">
						<center>
							<b><asp:Label ID="NameOfSchool" CssClass="sname1" runat="server" Text="" Font-Size="40px"  /><br /></b>
						<b>
							<asp:Label ID="SchoolAddress" runat="server" Text="" Font-Size="Smaller" /></b>
						<h5 style="text-decoration: underline;">CONTINOUS ASSESMENT RECORD FOR <asp:Label ID="schoolsname2" runat="server" ></asp:Label></h5>
						<h3 style="text-decoration: underline;"><b>TERMLY REPORT</b></h3>
						</center>
					</div>
						<div class="col-md-2 img img-responsive" style="border: 1px solid black; margin-right:0px">
							<asp:FormView ID="pixs2" runat="server" DataKeyNames="SchoolId" CssClass="img img-responsive">
								<ItemTemplate>
									<asp:Image CssClass="img img-full img-responsive" ID="Icon" runat="server"
										 ImageUrl='<%# String.Format("~/App_Resources/FileHandlers/ProfilePicture.ashx?SchoolId={0}", Eval("SchoolId")) %>' />
								</ItemTemplate>
							</asp:FormView>
						</div>
					</div>

					
				</div>
				<div class="panel panel-default">
					<div class="panel-body">

						<div class="col-md-12" style="padding:0px">
							<div class="col-sm-5">
								<table class="table table-responsive">
									<tr>
										<td style="text-align:right"><label style="font-size:smaller; font-weight:600">NAME OF STUDENT</label></td>
										<td>&nbsp;&nbsp;<asp:Label ID="StudentName" runat="server" Text="" /></td>
									</tr>
									<tr>
										<td style="text-align:right"><label style="font-size:smaller; font-weight:600">SEX</label></td>
										<td>&nbsp;&nbsp;<asp:Label ID="Sex" runat="server" /></td>
									</tr>
									
									<tr>
										<td style="text-align:right"><label style="font-size:smaller; font-weight:600">NEXT TERM BEGINS</label></td>
										<td><asp:Label runat="server" ID="NTB" style="font-size:smaller; font-weight:600">16-04-2018</asp:Label></td>
									</tr>
								</table>
							</div>
							<div class="col-sm-4">
								<table class="table table-responsive">
									<tr>
										<td style="text-align:right"><label style="font-size:smaller; font-weight:600">CLASS</label></td>
										<td>&nbsp;&nbsp;<asp:Label ID="Clas" runat="server" /></td>
									</tr>
									<tr>
										<td style="text-align:right"><label style="font-size:smaller; font-weight:600">POSITION</label></td>
										<td><asp:Label ID="lblposition" runat="server" /></td>
									</tr>
									<tr>
										<td style="text-align:right"><label  style="font-size:smaller; font-weight:600">STUDENTS AVERAGE</label></td>
										<td><asp:Label runat="server" ID="studAv" style="font-size:smaller; font-weight:600">STUDENTS AVERAGE</asp:Label></td>
									</tr>
								</table>
								
							</div>
							<div class="col-sm-3" style="padding:0px">
								<table class="table table-responsive" >
									<tr>
										<td style="text-align:right;"><label style="font-size:smaller; font-weight:600">NO.IN CLASS</label></td>
										<td><asp:Label ID="NumInClass" runat="server" Text="" /></td>
									</tr>
									<tr>
										<td style="text-align:right;"><label style="font-size:smaller; font-weight:600">TERM</label></td>
										<td><asp:Label ID="lblterm" runat="server" Text="" /></td>
									</tr>
									<tr>
										<td style="text-align:right;"><label style="font-size:smaller; font-weight:600">DATE</label></td>
										<td><asp:Label ID="Det" runat="server" /></td>
									</tr>
								</table>
							</div>
							
						</div>
					</div>
				</div>

				<div class="col-sm-12 " style="padding-top: -30px; background-color: white;">
					
					<asp:GridView ID="GridViewResult" runat="server" AutoGenerateColumns="false" CssClass="table table-responsive table-hover table-bordered"
						 EmptyDataText="No Examination Records  Found" GridLines="None" Width="100%" ToolTip="Headings">
						<Columns>
							<asp:BoundField DataField="SubjectName" HeaderText="Subjects">
								<HeaderStyle></HeaderStyle>
							</asp:BoundField>
							<asp:BoundField DataField="CAT1" HeaderText="CA 1" >
								<HeaderStyle></HeaderStyle>
							</asp:BoundField>
							<asp:BoundField DataField="CAT2" HeaderText="CA 2" >
								<HeaderStyle></HeaderStyle>
							</asp:BoundField>
							<asp:BoundField DataField="CAT3" HeaderText="PROJECT" >
								<HeaderStyle></HeaderStyle>
							</asp:BoundField>
						   <asp:TemplateField HeaderText="CA TOTAL" >
								<ItemTemplate>
									<asp:Label CssClass="test_Total" ID="testTotal" runat="server" Text='<%#Bind("TestTotal") %>' />
								</ItemTemplate>
								<HeaderStyle ></HeaderStyle>
							</asp:TemplateField>
							<asp:TemplateField  HeaderText="Exams Scores" >
								<ItemTemplate>
									<asp:Label CssClass="exams_score" ID="exams_Total" runat="server" Text='<%#Bind("ExamsScores") %>' />
								</ItemTemplate>
								<HeaderStyle></HeaderStyle>
							</asp:TemplateField>
							<asp:BoundField Visible="false">
								<HeaderStyle></HeaderStyle>
							</asp:BoundField>
							<asp:TemplateField HeaderText="Total" >
								<ItemTemplate>
									<asp:Label ID="Total" runat="server" Text='<%#Bind("Total") %>' />
								</ItemTemplate>
								<HeaderStyle></HeaderStyle>
							</asp:TemplateField>
							<asp:BoundField DataField="Grades" HeaderText="Grades" />
							<asp:BoundField DataField="Remark" HeaderText="Remark">
								
							</asp:BoundField>
							
						</Columns>
						
						<HeaderStyle VerticalAlign="Top"></HeaderStyle>
					</asp:GridView>
					<div  style="background-color: white; margin-top:10px; margin-bottom:10px; width:100%">
						
						<table style="width: 100%; text-align: center; font-weight: 700; border: solid thin">
							<tr id="Totalrow" style="text-align: center">
								<td style="width: 19.6%; border: solid thin"></td>
								<td style="width: 16.6%; border: solid thin"></td>
								<td style="width: 15.6%; border: solid thin"></td>
								<td style="width: 15.6%; border: solid thin"></td>
								<td style="width: 16.6%; border: solid thin">
									<asp:Label ID="TestTotal" runat="server" Text="" /></td>
								<td style="width: 16.6%; border: solid thin">
									<asp:Label ID="ExamasTotal" runat="server" Text="" /></td>
								<td style="width: 16.6%; border: solid thin">
									<asp:Label ID="TotalTotal" runat="server" Text="" /></td>
								<td style="width: 18.6%; border: solid thin"></td>
								<td style="border: solid thin"></td>
							</tr>
						</table>
					</div>

					<asp:GridView ID="keyToRating" CssClass="table table-responsive table-hover table-bordered" runat="server" AutoGenerateColumns="false" OnRowDataBound="keyToRating_RowDataBound" GridLines="None">
						<Columns>
							<asp:BoundField HeaderText="Grade" DataField="Grades"  />
							<asp:BoundField HeaderText="Remark" DataField="Remark" />
							<asp:TemplateField HeaderText="low Limit">
								<ItemTemplate>
									<asp:Label ID="Lower" runat="server" Text='<%#Eval("LowerLimit") %>' />
								</ItemTemplate>
							</asp:TemplateField>
							<asp:TemplateField HeaderText="High Limit">
								<ItemTemplate>
									<asp:Label ID="Upper" runat="server" Text='<%#Eval("UpperLimit") %>' />
								</ItemTemplate>
							</asp:TemplateField>
						</Columns>
					</asp:GridView>

					<div class="col-md-12">
						<table class="table table-responsive table-bordered" >
							<thead>
								
								<tr>
									<th>Events</th>
									<th>Indoor Games</th>
									<th>Ball Games</th>
									<th>Combative Games</th>
									<th>Tracks</th>
									<th>Jumps</th>
									<th>Throws</th>
									<th>Swiming</th>
									<th>Weight Lifting</th>
								</tr>
							</thead>
							<tbody>
								<tr>
									<td>Level Attained</td>
									<td>&nbsp;</td>
									<td>&nbsp;</td>
									<td>&nbsp;</td>
									<td>&nbsp;</td>
									<td>&nbsp;</td>
									<td>&nbsp;</td>
									<td>&nbsp;</td>
									<td>&nbsp;</td>
								</tr>
							</tbody>
						</table>
						<table class="table table-responsive table-bordered" >
							<caption><h5 style="text-align:center">CLUBS, YOUTH ORGANISATION ETC.</h5></caption>
							<thead>
								<tr>
									<th>Organisation</th>
									<th>Office Held</th>
									<th>Significant Contribution</th>
								</tr>
							</thead>
							<tbody>
								<tr>
									<td>&nbsp;</td>
									<td>&nbsp;</td>
									<td>&nbsp;</td>
								</tr>
							</tbody>
						</table>
					</div>
					<div style="margin-bottom:50px; padding:5px">
						<div class="clearfix"></div>
						<div class="col-sm-12">
							<label>CLASS TEACHER'S REMARK:_____________________________________________________</label>
						</div>
						<div class="col-sm-12">
							<label>PRINCIPAL'S COMMENTS: ______________________</label>

						</div>
						<div class="col-sm-6">
							<label>INTERPRETATION OF GRADES[COGNITIVE DOMAIN]: ____________________</label>
						</div>
						<div class="col-sm-6">
							<label>PRINCIPAL'S SIGNATURE: _______________________________</label>
						</div>
					</div>
				</div>

				<%--<div class="col-sm-5" style="margin-top: -30px; background-color: white;">
					<!--<div class="panel panel-default" style="margin: 0;">
					<div class="panel-heading"><b>AFFECTIVE DOMAIN</b>[VALUES,ATTITUDES,INTEREST,CHARACTER]</div>-->
					<!--<div class="panel-body table table-responsive">-->
					<table class="table table-bordered table-responsive" style="font-size: 10px;">
						<tr style="text-align: center;">
							<td><b>BEHAVIOUR</b></td>
							<td colspan="6" style="text-align: center;"><b>GRADINGS</b></td>

						</tr>
						<tr>
							<td></td>
							<td><b>A</b></td>
							<td><b>B</b></td>
							<td><b>C</b></td>
							<td><b>D</b></td>
							<td><b>E</b></td>
							<td></td>

						</tr>
						<tr>
							<td style="">Aesthetic Appreciation</td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
						</tr>
						<tr>
							<td>Class Attendance</td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
						</tr>
						<tr>
							<td>Creativity</td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
						</tr>
						<tr>
							<td>Honesty</td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
						</tr>
						<tr>
							<td>Initiative</td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
						</tr>
						<tr>
							<td>Leadership Role</td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
						</tr>
						<tr>
							<td>Neatness</td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
						</tr>
						<tr>
							<td>Obedience</td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
						</tr>
						<tr>
							<td>Politeness</td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
						</tr>
						<tr>
							<td>Punctuality</td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
						</tr>
						<tr>
							<td>Self-Control</td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
						</tr>
						<tr>
							<td>Sense Of Responsibility</td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>

						</tr>
						<tr>
							<td>Sociability</td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>

						</tr>
						<tr>
							<td>Organizational Ability</td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>

						</tr>
						<tr>
							<td>Perseverence</td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>

						</tr>
						<tr>
							<td>Spirit Of Co-operation</td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>

						</tr>
						<tr>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
						</tr>
						<tr>
							<td colspan="7" style="text-align: center;"><b>PSYCHOMOTOR DOMAIN</b>[Manual And Physical Skills]</td>

						</tr>
						<tr style="text-align: center;">
							<td><b>ACTIVITIES</b></td>
							<td colspan="6"><b>GRADINGS</b></td>

						</tr>
						<tr>
							<td></td>
							<td><b>A</b></td>
							<td><b>B</b></td>
							<td><b>C</b></td>
							<td><b>D</b></td>
							<td><b>E</b></td>
							<td></td>

						</tr>
						<tr>
							<td>Games</td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
						</tr>
						<tr>
							<td>Sports</td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>

						</tr>
						<tr>
							<td>Handling of Tools</td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>

						</tr>
						<tr>
							<td>Handwriting</td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>

						</tr>
						<tr>
							<td>Comunication Skills</td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>

						</tr>
						<tr>
							<td>Painting & Drawing</td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>

						</tr>
						<tr>
							<td>Musical Skills</td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>

						</tr>
						<tr>
							<td>Crafts</td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>

						</tr>
						<tr>
							<td>Gymnastic</td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>

						</tr>
						<tr>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td></td>

						</tr>

					</table>
					<!--</div>-->


					<!--</div>-->

				</div>--%>

				

			</section>

		</div>


		<script src="../../js/jquery.min.js"></script>
		<!-- Bootstrap -->

		<script src="../../js/bootstrap.js"></script>
		<!-- App -->
		<script src="../../js/app.js"></script>
		<script src="../../js/jquery.ui.touch-punch.min.js"></script>
		<script src="../../js/slimscroll/jquery.slimscroll.min.js"></script>
		<script src="../../js/libs/underscore-min.js"></script>
		<script src="../../js/libs/backbone-min.js"></script>
		<script src="../../js/libs/backbone.localStorage-min.js"></script>
		<script src="../../js/libs/moment.min.js"></script>

		<!-- Notes -->
		<script src="../../js/apps/notes.js"></script>
		<script src="../../js/app.plugin.js"></script>
		<script>
			var row = $('#Totalrow');
			$('#GridViewResult').children('tbody').first().append('<tr>' + row.html() + '</tr>');
			row.hide();
			//GridViewResult_examsTotal_1
			//var ETotal = $('#<%=GridViewResult.ClientID %>').find('span[id$="GridViewResult_exams_Total"]');

		    var label = $('.sname1').val();
		    $('.schoolsname').text() = label;
				
			//Create an array of elements that holds the scores
			var scores = $('.exams_score');
			$.each(scores, function (index, value) {
				if (value.innerHTML < 50) value.style.color = 'red';
			});

			var t_scores = $('.test_Total');
			$.each(t_scores, function (index, value) {
				if (value.innerHTML < 15) value.style.color = 'red';
			});
			
		</script>
	</form>
	
</body>
</html>
