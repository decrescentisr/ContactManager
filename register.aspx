<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="ContactManager.register" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <title>Contact Manager</title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport">
    <meta content="" name="keywords">
    <meta content="" name="description">
    <!-- Favicons -->
    <link href="img/contactmanagericonblue.ico" rel="icon">
    <!-- Google Fonts -->
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,400i,600,700|Raleway:300,400,400i,500,500i,700,800,900" rel="stylesheet">
    <!-- Bootstrap CSS File -->
    <link href="lib/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <!-- Libraries CSS Files -->
    <link href="lib/nivo-slider/css/nivo-slider.css" rel="stylesheet">
    <link href="lib/owlcarousel/owl.carousel.css" rel="stylesheet">
    <link href="lib/owlcarousel/owl.transitions.css" rel="stylesheet">
    <link href="lib/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <link href="lib/animate/animate.min.css" rel="stylesheet">
    <link href="lib/venobox/venobox.css" rel="stylesheet">
    <!-- Nivo Slider Theme -->
    <link href="css/nivo-slider-theme.css" rel="stylesheet">
    <!-- Main Stylesheet File -->
    <link href="css/style.css" rel="stylesheet">
    <!-- Responsive Stylesheet File -->
    <link href="css/responsive.css" rel="stylesheet">
    
</head>
<body data-spy="scroll" data-target="#navbar-example">
    <div id="preloader"></div>
    <header>
        <!-- header-area start -->
        <div id="sticker" class="header-area">
            <div class="container">
                <div class="row">
                    <div class="col-md-12 col-sm-12">
                        <!-- Navigation -->
                        <nav class="navbar navbar-default">
                            <!-- Brand and toggle get grouped for better mobile display -->
                            <div class="navbar-header">
                                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target=".bs-example-navbar-collapse-1" aria-expanded="false">
                                    <span class="sr-only">Toggle navigation</span>
                                    <span class="icon-bar"></span>
                                    <span class="icon-bar"></span>
                                    <span class="icon-bar"></span>
                                </button>
                                <!-- Brand -->
                                <a class="navbar-brand page-scroll sticky-logo" href="index.html">
                                    <h1><span>Contact</span>Manager</h1>
                                    <!-- Uncomment below if you prefer to use an image logo -->
                                    <!-- <img src="img/logo.png" alt="" title=""> -->
                                </a>
                            </div>
                            <!-- Collect the nav links, forms, and other content for toggling -->
                            <div class="collapse navbar-collapse main-menu bs-example-navbar-collapse-1" id="navbar-example">
                                <ul class="nav navbar-nav navbar-right">
                                    <li class="active">
                                        <a href="index.html">Home</a>
                                    </li>
                                    <li>
                                        <a href="index.html">About</a>
                                    </li>
                                    <li>
                                        <a href="index.html">Services</a>
                                    </li>
                                    <li>
                                        <a href="index.html">Team</a>
                                    </li>
                                   
                                    <li>
                                        <a href="contact.html">Contact</a>
                                    </li>
                                    <li>
                                        <a href="login.aspx">Sign In</a>
                                    </li>
                                </ul>
                            </div>
                            <!-- navbar-collapse -->
                        </nav>
                        <!-- END: Navigation -->
                    </div>
                </div>
            </div>
        </div>
        <!-- header-area end -->
    </header>
    <!-- header end -->

  <!--==========================
    Hero Section
  ============================-->
  <div class="hero">
        <img src="img/registrationhero.jpg" class="responsive" style="width: 100%; height: 600px;"/>
        <div class="hero-text">
            <h1 style="font-size:50px; text-align: left;">Register Portal</h1>
        </div>
    </div>
    <br />
    <br />

  <!--==========================
    Registration Form Section
  ============================-->
    <form id="form1" runat="server">
        <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="lblFirst" runat="server" Text="First Name: "></asp:Label>
&nbsp;<asp:TextBox ID="txtFirst" runat="server"></asp:TextBox>
    &nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="txtFirst" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Label ID="lblLast" runat="server" Text="Last Name: "></asp:Label>
&nbsp;<asp:TextBox ID="txtLast" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="txtLast" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Label ID="lblEmail" runat="server" Text="Email:  "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ControlToValidate="txtEmail" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Label ID="lblPhone" runat="server" Text="Phone:  "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPhone" runat="server" TextMode="Phone"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ControlToValidate="txtPhone" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Label ID="lblDOB" runat="server" Text="DOB:  "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtDOB" runat="server" TextMode="Month"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" ControlToValidate="txtDOB" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label>
&nbsp;
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" ControlToValidate="txtUsername" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
    </p>
    <p>
&nbsp;<asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
&nbsp;
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red" ControlToValidate="txtPassword" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Label ID="lblConfirm" runat="server" Text="Confirm Password: "></asp:Label>
&nbsp;<asp:TextBox ID="txtConfirm" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" ControlToValidate="txtConfirm" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
    </p>
        <p>
            &nbsp;</p>
    <p>
        <asp:DropDownList ID="ddlSecurity" runat="server" class="btn btn-primary dropdown-toggle"  >
            <asp:ListItem>I am a...</asp:ListItem>
            <asp:ListItem Value="E">Employee</asp:ListItem>
            <asp:ListItem Value="M">Manager</asp:ListItem>
            <asp:ListItem Value="N">Non-Employee</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ForeColor="Red" ControlToValidate="ddlSecurity" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="False" Text="You are Successfully Registered!...You Will be Redirected Within 10 Seconds..."></asp:Label>
    </p>
        <p>
            &nbsp;</p>
   
        

             <asp:Button ID="btnSubmit" runat="server" Text="Submit"  class ="btn btn-primary" OnClick="btnSubmit_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnClear" runat="server" Text="Clear Form" class ="btn btn-primary" OnClick="btnClear_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </form>
   <!--==========================
    Footer Section
  ============================-->
    <!-- Start Footer bottom Area -->
    <footer>
        <div class="footer-area">
            <div class="container">
                <div class="row">
                    <div class="col-md-4 col-sm-4 col-xs-12">
                        <div class="footer-content">
                            <div class="footer-head">
                                <div class="footer-logo">
                                    <h2>Contact Manager</h2>
                                </div>
                                <p>Contact Manager is a fully responsive company focusing on the needs of their clients while allowing users to search, add, edit, delete and modify client information.</p>
                                <div class="footer-icons">
                                    <ul>
                                        <li>
                                            <a href="https://www.facebook.com/zewebbie"><i class="fa fa-facebook"></i></a>
                                        </li>
                                        <li>
                                            <a href="http://www.twitter.com/zewebbie"><i class="fa fa-twitter"></i></a>
                                        </li>
                                        
                                        <li>
                                            <a href="https://www.pinterest.com/decrescentisr/"><i class="fa fa-pinterest"></i></a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- end single footer -->
                    <div class="col-md-4 col-sm-4 col-xs-12">
                        <div class="footer-content">
                            <div class="footer-head">
                                <h4>information</h4>
                                <p>
                                    Please contact us either through the <a href="contact.html" style="text-decoration: none"> contact form</a> or through the information below. We look forward to hearing from you!
                                </p>
                                <div class="footer-contacts">
                                    <p><span>Tel:</span> +1 720 217 3799</p>
                                    <p><span>Email:</span> robert@zewebbie.com</p>
                                    <p><span>Working Hours:</span> 9am-5pm</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- end single footer -->
                    <div class="col-md-4 col-sm-4 col-xs-12">
                        <div class="footer-content">
                            <div class="footer-head">
                                <h4>Instagram</h4>
                                <div class="flicker-img">
                                    <a href="#"><img src="img/portfolio/1.jpg" alt=""></a>
                                    <a href="#"><img src="img/portfolio/2.jpg" alt=""></a>
                                    <a href="#"><img src="img/portfolio/3.jpg" alt=""></a>
                                    <a href="#"><img src="img/portfolio/4.jpg" alt=""></a>
                                    <a href="#"><img src="img/portfolio/5.jpg" alt=""></a>
                                    <a href="#"><img src="img/portfolio/6.jpg" alt=""></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="footer-area-bottom">
            <div class="container">
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="copyright text-center">
                            <p>
                                &copy; Copyright <strong>Contact Manager</strong>. All Rights Reserved
                            </p>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </footer>
    <a href="#" class="back-to-top"><i class="fa fa-chevron-up"></i></a>
   <!-- JavaScript Libraries -->
    <script src="lib/jquery/jquery.min.js"></script>
    <script src="lib/bootstrap/js/bootstrap.min.js"></script>
    <script src="lib/owlcarousel/owl.carousel.min.js"></script>
    <script src="lib/venobox/venobox.min.js"></script>
    <script src="lib/knob/jquery.knob.js"></script>
    <script src="lib/wow/wow.min.js"></script>
    <script src="lib/parallax/parallax.js"></script>
    <script src="lib/easing/easing.min.js"></script>
    <script src="lib/nivo-slider/js/jquery.nivo.slider.js" type="text/javascript"></script>
    <script src="lib/appear/jquery.appear.js"></script>
    <script src="lib/isotope/isotope.pkgd.min.js"></script>
    <!-- Contact Form JavaScript File -->
    <script src="contactform/contactform.js"></script>
    <script src="js/main.js"></script>
</body>
</html>
