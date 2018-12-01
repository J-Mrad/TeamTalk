<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminUsers.aspx.cs" Inherits="TeamTalk.AdminUsers" %>

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
		
        <title>User Manager</title>
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
                        <h1>Create New User:</h1>
                        <table>
                            <tr>
                                <td>Name: </td>
                                <td>
                                    <input id="Text1" type="text" class="innerwell" runat="server"/>
                                </td>
                            </tr>
                            <tr>
                                <td>Gender(M/F): </td>
                                <td>
                                    <input id="Text2" type="text" class="innerwell" runat="server"/>
                                </td>
                            </tr>
                            <tr>
                                <td>Email: </td>
                                <td>
                                    <input id="Text3" type="text" class="innerwell" runat="server"/>
                                </td>
                            </tr>
                            <tr>
                                <td>Started Working: </td>
                                <td>
                                    <input id="Text4" class="innerwell" type="datetime-local" runat="server"/>
                                </td>
                            </tr>
                            <tr>
                                <td>Title: </td>
                                <td>
                                    <input id="Text5" class="innerwell" type="text" runat="server"/>
                                </td>
                            </tr>
                            <tr>
                                <td>Company: </td>
                                <td>
                                    <input id="Text6" class="innerwell" type="text" runat="server"/>
                                </td>
                            </tr>
                            <tr>
                                <td>Password: </td>
                                <td>
                                    <input id="Text7" class="innerwell" type="text" runat="server"/>
                                </td>
                            </tr>
                            <tr>
                                <td>Role: </td>
                                <td>
                                    <input id="Text8" class="innerwell" type="text" runat="server"/>
                                </td>
                            </tr>
                            <tr></tr>

                            <tr>
                                <td>
                                    <div id="errorHolder" runat="server">

                                    </div>
                                </td>
                                <td>
                                <input id="Submit1" type="submit" value="Create" runat="server"/>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <a href="AdminPanel.aspx"><h2> Back to Main Page </h2></a>
                                </td>
                            </tr>
                        </table> 
                    </form>
                </div>
            </div>
        </div>
    </body>
</html>
