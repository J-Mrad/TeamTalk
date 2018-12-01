using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeamTalk
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e){
            if (IsPostBack)
            {
                OfficeChatDBEntities context = new OfficeChatDBEntities();
                string user = String.Format("{0}", Request.Form["Text1"]);
                string pass = String.Format("{0}", Request.Form["Password1"]);

                List<myUser> users = context.myUsers.ToList();
                foreach(myUser u in users){
                    if (u.N_ame.Equals(user))
                    {
                        if (u.P_assword.Equals(pass))
                        {
                            Session["curUserID"] = u.UserID;
                            if (u.Role.Equals("admin"))
                            {
                                Response.Redirect("AdminPanel.aspx");
                            }
                            else
                            {
                                u.isOnline = 1;
                                u.lastOnline = System.DateTime.Now;
                                context.SaveChanges();
                                Response.Redirect("index.aspx");
                            }
                        }
                        else
                        {
                            errorHolder.InnerHtml = "<h3 style='color:red'> Wrong password! </h3>";
                        }
                    }
                }
                errorHolder.InnerHtml = "<h3 style='color:red'> Username does not exist </h3>";
            }

        }
    }
}