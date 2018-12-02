<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyManager.aspx.cs" Inherits="TeamTalk.CompanyManager" %>

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
                <div class="well outerwell" id="wrapper" runat="server">
                    <form runat="server" class="loginForm" target="_self">
                        <table>
                            <tr>
                                <td>Name: </td>
                                <td>
                                    <input id="Text1" class="innerwell" type="text" runat="server"/>
                                </td>
                            </tr>
                            <tr>
                                <td>Desc: </td>
                                <td>
                                    <input id="Text2" class="innerwell" type="text" runat="server"/>
                                </td>
                            </tr>
                            <tr>
                                <td>Email: </td>
                                <td>
                                    <input id="Text3" class="innerwell" type="text" runat="server"/>
                                </td>
                            </tr>
                       
                            <tr></tr>

                            <tr>
                                <td>
                                    <input type="file" runat="server" id="fileUpload"/>
                                </td>
                                <td>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <div id="errorHolder" runat="server">

                                    </div>
                                </td>
                                <td>
                                <input id="Submit1" type="submit" value="Save Changes" runat="server"/>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <a href="index.aspx"><h2> Back to Main Page </h2></a>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <div id="imageHere" runat="server">

                                    </div>
                                </td>
                            </tr>
                        </table>                    
                    </form>
                </div>
            </div>
        </div>
    </body>
</html>
