<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="searchresult.aspx.cs" Inherits="WebSchoolPortal.searchresult" %>

<!DOCTYPE html>


<html lang="en" class=" ">
<head id="Head1" runat="server">
  <meta charset="utf-8" />
   <title>Automated-schools management system | Home</title>
    <link rel="icon" href="images/icon.ico" />
  <meta name="description" content="Automated schools management system is a responsive web based application which will give you much power to take your school to greater height.It has admin dashboard, teacher dashboard, student dashboard" /> 
    <link href="../../../css/bootstrap.css" rel="stylesheet" />
    <link href="../../../css/animate.css" rel="stylesheet" />
    <link href="../../../css/font-awesome.min.css" rel="stylesheet" />
    <link href="../../../css/font.css" rel="stylesheet" />
    <link href="../../../css/landing.css" rel="stylesheet" />
    <link href="../../../css/app.css" rel="stylesheet" />


    <!--[if lt IE 9]>
    <script src="js/ie/html5shiv.js"></script>
    <script src="js/ie/respond.min.js"></script>
    <script src="js/ie/excanvas.js"></script>
  <![endif]-->
</head>
    <body>
    <form id="form1" runat="server">

         <!-- header -->
  <header id="header" class="navbar navbar-fixed-top bg-white box-shadow b-b b-light"  data-spy="affix" data-offset-top="1">
    <div class="container">
        <div class="col-md-3">
            <img src="../../images/logo.png" />
        </div>
        <div class=col-md-9>

            <div class="input-group">
                <asp:TextBox ID="SearchBox" runat="server" class="form-control input-lg" placeholder="Go on, Search!!! " />
                <span class="input-group-btn">
                    <asp:LinkButton ID="SearchButton" runat="server" type="button" class="btn btn-default btn-lg" OnClick="SearchButton_Click" Text="Search"><i class="fa fa-search"></i></asp:LinkButton>

                </span>
          </div>
        </div>

    </div>
  </header>
  <!-- / header -->
        <!--- Container---->
        <section id="content" >
        <div class="container">
           
               <div class="clearfix"></div>

                  <div class="bg-white b-t b-light" style="min-height:1000px; border-top:none;">
               
                    
				<div class="col-md-12 ">
					
					<h2 class=""><i class="fa fa-briefcase text-info "></i>  Student Academic Records</h2>
				</div>
				<div class="col-md-12 bg-white b-t b-light">
						<h3 class="text-warning">Personal Details</h3>
						<hr>
						<div class="col-md-2 ">
							<div class="col-md-12 ">
								Passport
							</div>
							<div class="col-md-12 ">
                                <asp:FormView ID="Studentpix" runat="server" DataKeyNames="StudentRollNumber" CssClass="img img-responsive">
                                    <ItemTemplate>
                                        <asp:Image CssClass="img-thumbnail  "  ID="ProfImage" runat="server" ImageAlign="Middle" ImageUrl='<%# String.Format("~/App_Resources/FileHandlers/StudentProfilepixs.ashx?StudentRollNumber={0}", Eval("StudentRollNumber")) %>' />
                                    </ItemTemplate>
                                </asp:FormView>
								School Logo
							</div>
							<div class="col-md-12 ">
                                <asp:FormView ID="SchoolImage" runat="server" DataKeyNames="StudentRollNumber" CssClass="img img-responsive">
                                    <ItemTemplate>
                                        <asp:Image CssClass=" img-thumbnail img img-responsive" ID="Icon" runat="server" ImageUrl='<%# String.Format("~/App_Resources/FileHandlers/ProfilePicture.ashx?SchoolId={0}", Eval("SchoolId")) %>'  />
                                    </ItemTemplate>
                                </asp:FormView>

							</div>
						</div>
                    <br />
                        <div class="col-md-10 col-sm-12 ">
                            <div class="table">
                                <asp:DetailsView ID="BasicProfile" runat="server" AutoGenerateRows="False" Visible="true" CssClass="table table-bordered table-striped table-hover" Width="100%">
                                    <Fields>
                                        <asp:BoundField DataField="SchoolName" HeaderText="School Name" />

                                        <asp:BoundField ReadOnly="true" HeaderText="First Name:" DataField="FirstName" />
                                        <asp:BoundField DataField="LastName" HeaderText="Last Name: " />
                                        <asp:BoundField DataField="StudentRollNumber" HeaderText="StudentId" />
                                        <asp:BoundField DataField="DateOfBirth" HeaderText="Date Of Birth" />
                                        <asp:BoundField DataField="Sex" HeaderText="Sex" />
                                        <asp:BoundField DataField="BloodGroup" HeaderText="Blood Group" />
                                        <asp:BoundField DataField="Genotype" HeaderText="Genotype" />
                                        <asp:BoundField DataField="PresentClass" HeaderText="Present Class" />
                                        <asp:BoundField DataField="COUNTRYS" HeaderText="Nationality" />
                                        <asp:BoundField DataField="state" HeaderText="State" />
                                        <asp:BoundField DataField="LGA" HeaderText="L.G.A" />
                                        <asp:BoundField DataField="AdmissionDate" HeaderText="Admission Date" />
                                        <asp:BoundField DataField="SchoolPostalCode" HeaderText="Postal Code" />
                                    </Fields>

                                </asp:DetailsView>
                            </div>
                        </div>
					
                      <div class="col-md-12 print-table">
                            <table>
                                <tbody>
                                    <tr>
                                        <td>
                                            <h3 class="text-warning">Payment Details</h3>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <hr>
                            <div class="table">
                                <asp:DetailsView runat="server" AllowPaging="true" ID="PaymentDetails" AutoGenerateRows="false" CssClass="table table-bordered table-striped table-hover" PagerStyle-CssClass="pagination-ys" OnPageIndexChanging="PaymentDetails_PageIndexChanging" Width="100%">
                                    <Fields>
                                        <asp:BoundField HeaderText="Fees Amount" DataField="Fees" />
                                        <asp:BoundField HeaderText="Amount Paied" DataField="amountPaid" />
                                        <asp:BoundField HeaderText="Payment Date" DataField="paymentDate" />
                                        <asp:BoundField HeaderText="Status" DataField="Status" />
                                    </Fields>
                                </asp:DetailsView>
                            </div>
                        </div>
                      
                    
                      <div class="col-md-12">
                            <h3 class="text-warning">Attendance Records</h3>
						<hr>
                            <div class="table  table-responsive">
                                <asp:GridView ID="ShowAttaindance" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-striped table-hover table-responsive " PagerStyle-CssClass="pagination-ys" Width="100%">
                                    <Columns>
                                        <asp:BoundField HeaderText="Class" DataField="Class" HeaderStyle-ForeColor="#006600"  />
                                        <asp:BoundField HeaderText="Date" DataField="DaysDate" HeaderStyle-ForeColor="#006600" />
                                        <asp:BoundField HeaderText="Day" DataField="Day" HeaderStyle-ForeColor="#006600" />
                                        <asp:BoundField HeaderText="Status" DataField="Status" HeaderStyle-ForeColor="#006600" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <hr />
                        </div>
                      
					
				<div class="col-md-12 bg-white b-t b-light">
						<table class="table">
							<tbody ">
								<tr>
									<td>
										<div class="">
											<h5 class="text-warning"><span class="fa  fa-lightbulb-o"></span > Student Information</h5>
										</div>
									</td>
								</tr>
								<tr>
									<td>
										<p style="text-align:right;"><a href="javascript:print()">Print</a> | <!--<a href="#">Close</a>--></p>
									</td>
								</tr>
							</tbody>
						</table>
					</div>
				
			</div>
                
  
            </div>

        </div>
          

            <footer class="footer navbar" >

                
                   
                    <button class="btn btn-link visible-xs pull-right" type="button" data-toggle="collapse" data-target=".navbar-collapse">
                        <i class="fa fa-bars"></i>
                    </button>
                
                <div class="collapse navbar-collapse">
                    <ul class="nav navbar-nav navbar-right ">
                        <li >
                            <a href="#">Home</a>
                        </li>
                        <li>
                            <a href="#">Features</a>
                        </li>

                        <li>
                            <a href="#">Search</a>
                        </li>
                        <li>
                            <a href="#">Search</a>
                        </li>

                        <li>
                            <a href="#" >Contact us</a>
                        </li>

                    </ul>
                </div>
                     </footer>
        </section>
            <!--- /Container---->


    </form>


               <!-- / footer -->


        <script src="../../../js/jquery.min.js"></script>
        <script src="../../../js/bootstrap.js"></script>
        <script src="../../../js/app.js"></script>
        <script src="../../../js/slimscroll/jquery.slimscroll.min.js"></script>
        <script src="../../../js/appear/jquery.appear.js"></script>
        <script src="../../../js/scroll/smoothscroll.js"></script>
        <script src="../../../js/landing.js"></script>
        <script src="../../../js/app.plugin.js"></script>

</body>
</html>
