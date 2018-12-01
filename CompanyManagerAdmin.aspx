<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyManagerAdmin.aspx.cs" Inherits="TeamTalk.CompanyManagerAdmin" %>

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
	    <link rel = "stylesheet" type = "text/css" href = "Content/style/loginStyle.css"/>						<!-- Style -->
	    <link rel = "stylesheet" type = "text/css" href = "Content/style/sideBar.css"/>						<!-- SideBar -->
		
        <title>Company Manager</title>
    </head>
    <body>

         <script src="https://code.jquery.com/jquery-3.3.1.js"></script>		<!-- JQuerry -->
	    <!--script src="js/JQslider.js" type="text/javascript"></script-->								<!-- Slider -->
																													    <!-- Bootstrap -->
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
	    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
        <script src='Scripts/main.js'></script>									<!-- Main -->

        <div class="container-fluid">       
            <div class ="row bgWhite vertical">
                <div class="well outerwell">
                    <form runat="server" class="loginForm" target="_self">
                        <h1 runat="server" id="title">Company: </h1>
                        <h4>Active:</h4><input type="checkbox" id="check" runat="server"/>
                        <h4>Manager:</h4><input type="text" id="mnger" runat="server"/>
                        <div id="errorMsg" runat="server" style="color:red"></div><input type="submit" runat="server"/>
                    </form>
                    <h2><a href="AdminCompanies.aspx">Back</a></h2>
                </div>
            </div>
        </div>
    </body>
</html>
