using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeamTalk
{
    public partial class AdminUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OfficeChatDBEntities context = new OfficeChatDBEntities();
            int u1 = (int)Session["curUserID"];
            myUser user1 = context.myUsers.Find(u1);

            if (IsPostBack)
            {
                string name = String.Format("{0}", Request.Form["Text1"]);
                string gend = String.Format("{0}", Request.Form["Text2"]);
                string email = String.Format("{0}", Request.Form["Text3"]);
                DateTime start = DateTime.Parse(Request.Form["Text4"]);
                string title = String.Format("{0}", Request.Form["Text5"]);
                string comp = String.Format("{0}", Request.Form["Text6"]);
                string pass = String.Format("{0}", Request.Form["Text7"]);
                string role = String.Format("{0}", Request.Form["Text8"]);

                Company c = null;
                foreach (Company cmp in context.Companies)
                {
                    if (cmp.N_ame.Equals(comp))
                    {
                        c = cmp;
                        break;
                    }
                }

                user1.N_ame = name;
                user1.Gender = gend;
                user1.Email = email;
                user1.Title = title;
                user1.StartedWorking = start;
                user1.Role = role;
                user1.P_assword = pass;
                
                if (c != null)
                {
                    user1.Company = c.CID;
                    context.SaveChanges();
                }
                else
                {
                    errorHolder.InnerHtml = "<h4 style='color:red'> Company does not exist </h4>";
                }
            }
            /* Removed admin ability to edit/delete users
            foreach (myUser u in context.myUsers.ToList())
            {
                TableRow row = new TableRow();
                TableCell cell0 = new TableCell();
                cell0.Text = "<img src=" + getfilepath(u) + " class='image'/>";
                row.Cells.Add(cell0);
                TableCell cell1 = new TableCell();
                cell1.Text = u.N_ame;
                row.Cells.Add(cell1);
                TableCell cell2 = new TableCell();
                cell2.Text = "<a href='UserManagerAdmin.aspx?id='"+u.UserID+"'&>Manage</a>";
                row.Cells.Add(cell2);
                companyList.Rows.Add(row);
            }
            */
        }
    }
}