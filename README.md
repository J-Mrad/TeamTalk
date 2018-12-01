# TeamTalk
Office chat web application
<br />
Team Talk is an office chat application made on ASP.NET as per request of IDS as part of the internship program, catered to the needs of any company from small startups to large businesses. It offers a simplistic design coupled with a layered coding schema that makes best use of web development frameworks to give the user a great experience. Team Talk facilitates the communication between colleagues/team members through text messaging and even sharing images. Everything is managed on a database to prevent any data loss and any access to the system is done through a login system for added security.<br />
Equipped with different roles with the possibility of expansion and the ability to host multiple companies simultaneously, the system is very customizable. TT can also be fitted to host multiple teams within the same company with the possibility of having all cross-team communication on a secure, manageable system.
<br />
<br />
![Login](https://media.giphy.com/media/8UwRydyGvylQgh0Bi7/giphy.gif)
<br />
<br />
TeamTalk aims to provide a reliable alternative to time-consuming email conversations and pointless conference calls that still offers security and the ability to share images and documents both online and offline. The application can be used in any office setting with different assignable roles to allow managers more control. TeamTalk relies on simplicity and minimalism in design which allows us to reach out to a broader audience and in turn boost usability.<br />
<br />
![SideBar](https://media.giphy.com/media/uB0nvUwWUHnlsGPAep/giphy.gif)<br />
<br />
![SendMsg](https://media.giphy.com/media/9VANROYAPYWgTo6wyw/giphy.gif)<br />
<br />
![Messages](https://media.giphy.com/media/1BdqB26EAkRnUvlBQM/giphy.gif)<br />
<br />
TT is designed to be an ASP.NET C# template for an office chat application. To set up the project on your PC:<br />
<br />
1- Create a non-MVC ASP.NET solution<br />
2- Create the following web forms and pase in the given .aspx and .aspx.cx syntax: <br />
&nbsp;&nbsp;&nbsp; login: Login page<br />
&nbsp;&nbsp;&nbsp; index: contacts page<br />
&nbsp;&nbsp;&nbsp; indexChat: chat page<br />
&nbsp;&nbsp;&nbsp; AdminPanel: landing page for admin<br />
&nbsp;&nbsp;&nbsp; manageUser: edit user settings<br />
&nbsp;&nbsp;&nbsp; CompanyManager: edit company<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; optional: CompanyManagerAdmin and AdminUsers for admins to create companies/users<br />
3- Create a DB on your preferred DBMS with the provded syntax<br />
4- Set up the EntityFramework<br />
&nbsp;&nbsp;&nbsp; [suggested tutorial](https://www.c-sharpcorner.com/article/entity-framework-introduction-using-c-sharp-part-one/)<br />
<br />
This should get you a working prototype. This version has had some functionalities ommitted including MVC and ASP Membership provider. Use it as a reference or a base template to build upon for your own projects. MVC is always preffered for applications of this scale.
