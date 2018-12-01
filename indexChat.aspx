<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="indexChat.aspx.cs" Inherits="TeamTalk.indexChat" %>

<!DOCTYPE html>


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
		<link rel = "stylesheet" type = "text/css" href = "Content/style/mainStyle.css"/>						<!-- Style -->
		<link rel = "stylesheet" type = "text/css" href = "Content/style/sideBar.css"/>						<!-- SideBar -->
		

		<title>
			Team Talk
		</title>
	</head>
	<body>
		
	    <script src="https://code.jquery.com/jquery-3.3.1.js"></script>		<!-- JQuerry -->
	    <!--script src="js/JQslider.js" type="text/javascript"></script-->								<!-- Slider -->
																													    <!-- Bootstrap -->
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
	    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
        <script src='Scripts/main.js'></script>									<!-- Main -->


        <div id="wrapper">

            <form method='post' runat ='server' action='indexChat.aspx?sending=1'>

                <!-- Sidebar -->
                <div id="sidebar-wrapper">
                    <ul class="sidebar-nav">
                        <li class="sidebar-brand">
                            <a href="index.aspx">
                                <img src ="Content/data/images/TT.png" class = "image" />
                            </a>
                        </li>
                        <li>
                            <div id="newChatHolder" runat="server">
                                <a href="#">~~Active Chats~~</a>
                            </div>
                        
                        </li>

                    </ul>
                </div>
                <!-- /sidebar -->
                <!-- Page Content -->
                <div id="page-content-wrapper">
                    <div class="container-fluid">
                    
                        <div class ="row topnavbar">

                            <div class ="col-2" id ="tools">
                                <div class="fitMobile">
                                    <a href="#menu-toggle" id="menu-toggle"> <img src ="Content/data/icons/msgNo.png" class ="icon automargins" id="msgLogo" runat="server"/> </a>
                                    <a href="manageUser.aspx"> <img src ="Content/data/icons/settings.png" class ="icon automargins"/> </a>
                                </div>
                                <div class="fitMobile">
                                    <a href="index.aspx?sending=0"> <img src ="Content/data/icons/refresh.png" class ="icon logoutbutton"/> </a>
                                    <a href="CompanyManager.aspx"> <img id="company" src ="Content/data/images/defComp.png" class ="icon automargins"/> </a>
                                </div>
                            </div>
                            <div class ="col-1">
                            </div>
                            <div id="user2Dets" class="col-4 topnav" runat="server">

                            </div>
                            <div class ="col-5 topnav" id="profilePhoto" runat="server">

                            </div>
                        </div>

                    
                        <div class ="row userAdmin">
                            placeholder
                        </div>

                            <div id="chatField" class="chatfield" runat="server">
                                 <div class ="row userAdmin">
                                placeholder
                                </div>
                                <div class ="row userAdmin">
                                placeholder
                                </div>
                                <div class ="row userAdmin">
                                placeholder
                                </div>
                            </div>

                            <div class ="messageType" id="typeHere" runat="server">
                                <div class="row">
                                    <div class="col-sm-1 col-2">
                                    
                                        <label class="file-upload image">
                                            <img src="Content/data/icons/attIcon.png"  class="image roundBorder" />
                                            <input type="file" id="fileupload" runat="server" />
                                        </label>
                                        <div id="filestatus" runat="server">
                                                
                                        </div>
                                    </div>
                                    <div class ="col-sm-8 col-7">
                                        <input id="Text1" type="text" class="roundBorder" name="messageIn"/>
                                    </div>

                                    <div class ="vertical col-3">
                                        <input id="Submit1" type="submit" value="Send" class ="button roundBorder"/>
                                        <div class ="horizantal">
                                            <input id="Checkbox1" name="checkbox1" runat="server" type="checkbox" class="autoverticalmargins"/> Urgent
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- /#page-content-wrapper -->
                </form>   
            </div>
        <!-- /#wrapper -->
 

    <script>
        $("#menu-toggle").click(function (e) {
            e.preventDefault();
            $("#wrapper").toggleClass("toggled");
        });

        var i = 0;

        $("#menu-toggle").on("click", function () {

            if (i == 0) {
                $("#tools").css("display", "grid")
                i = 1;
            }
            else {
                $("#tools").css("display", "flex")
                i = 0;
            }
        });

        window.scrollTo(0, document.body.offsetHeight);

        
    </script>

    </body>
</html>
