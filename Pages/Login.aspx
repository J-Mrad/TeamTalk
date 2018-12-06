<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TeamTalk.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<!-- meta -->
		<meta charset="utf-8"/>
		<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

		<!-- icon -->
		<link rel="icon" href="Content/data/icons/TT.png"/>
		
		<!-- CSS -->																			<!-- BootStrap -->
		<link rel = "stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"/>
		<link rel = "stylesheet" type = "text/css" href = "Content/style/loginStyle.css"/>						<!-- Style -->
		

		<title>
			Team Talk 
		</title>
	</head>
	<body>
		
	    <script src="https://code.jquery.com/jquery-3.3.1.js"></script>		<!-- JQuerry -->
																													    <!-- Bootstrap -->
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
	    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
        <script src='Scripts/main.js'></script>									<!-- Main -->
        
        <div id="actual-content">
            <div class="content">
                <div class="container-fluid">

                    <div class ="row bgWhite vertical">
                        <h1 class ="bgBlack banner-low">
                            <span class ="banner-sm"> Welcome to </span><span class="banner-lg"> TeamTalk! </span>
                            <img src ="Content/data/images/TT.png" class = "image logo" />

                        </h1>  
                        <form runat="server" class="loginForm" target="_self">
                            <table>
                                <tr>
                                    <td>Name: </td>
                                    <td>
                                        <input id="Text1" type="text" runat="server"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Password: </td>
                                    <td>
                                        <input id="Password1" type="password" runat="server"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="errorHolder" runat="server">

                                        </div>
                                    </td>
                                    <td>
                                    <input id="Submit1" type="submit" value="Login" runat="server"/>
                                    </td>
                                </tr>
                            </table>                    
                        </form>
                    </div>
                </div>
            </div>
        </div>

        <div id="landing-content">
            <div class="content">
                <div class="container-fluid">
                    
                    <div class ="row bgWhite vertical">
                        <h1 class ="bgBlack banner">
                            <span class ="banner-sm"> Welcome to </span><span class="banner-lg"> TeamTalk! </span>
                            <img src ="Content/data/images/TT.png" class = "image logo" />

                        </h1>  
                        <h2 class="desc">
                            TeamTalk is a fast & secure office chat application built to replace chatter-filled conference calls 
                            and limit time-consuming email conversations. TT is fitted for use within companies as a reliable means of 
                            communication to make everyday work in the office easier and more efficient. To begin using TT contact your
                            supervisor(s) to receive your login credentials and do your part in connecting your workspace today!
                        </h2>

                        <h6 class="pullme">
                            < pull anywhere to login >
                        </h6>
                    </div>
                </div>
            </div>
        </div>
    </body>
</html>
