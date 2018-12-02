using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeamTalk
{
    public partial class CompanyManagerAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OfficeChatDBEntities context = new OfficeChatDBEntities();
            int id = int.Parse(Request.QueryString["cmp"]);
            Company c = context.Companies.Find(id);
            title.InnerHtml = "Company: " + c.N_ame;
            if (IsPostBack)
            {
                c.Active = 1;
                if (check.Checked == false)
                {
                    c.Active = 0;
                }
                string name = String.Format("{0}", Request.Form["mnger"]);
                int userID = 0;
                foreach(myUser u in context.myUsers)
                {
                    if(u.N_ame == name)
                    {
                        userID = u.UserID;
                        break;
                    }
                }
                if(userID != 0)
                {
                    c.RelatedUser = userID;
                    context.SaveChanges();
                }
                else
                {
                    errorMsg.InnerHtml = "User doesn't exist!";
                }
            }
            else
            {
                check.Checked = true;
                if(c.Active == 0)
                {
                    check.Checked = false;
                }
                mnger.Value = "N/A";
                if(c.RelatedUser != null){
                    mnger.Value = context.myUsers.Find(c.RelatedUser).N_ame;
                }
            }
        }
    }
}
