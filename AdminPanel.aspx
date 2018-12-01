<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="TeamTalk.AdminPanel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <!-- meta -->
	    <meta charset="utf-8"/>
	    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

	    <!-- icon -->
	    <link rel="icon" href="Content/data/icons/TT.png"/>
		
	    <!-- CSS -->																			<!-- BootStrap -->
	    <link rel = "stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"/>
	    <link rel = "stylesheet" type = "text/css" href = "Content/style/loginStyle.css"/>				<!-- Style -->
	    <link rel = "stylesheet" type = "text/css" href = "Content/style/sideBar.css"/>				<!-- SideBar -->
		
        <title>Company Manager</title>
    </head>
    <body>

         <script src="https://code.jquery.com/jquery-3.3.1.js"></script>		<!-- JQuerry -->
	    <!--script src="js/JQslider.js" type="text/javascript"></script-->							<!-- Slider -->
																									<!-- Bootstrap -->
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
	    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
        <script src='Scripts/main.js'></script>									<!-- Main -->

        <div class="container-fluid">       
            <div class ="row bgWhite vertical">
                <a href="AdminCompanies.aspx"> <h1 class="aligncenter"> Manage Companies </h1> </a>
                <a href="AdminUsers.aspx"> <h1 class="aligncenter"> Manage Users </h1> </a>
                <a href="Login.aspx"><h1>Logout</h1></a>
            </div>
        </div>
    </body>
</html>
