using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeamTalk
{
    public partial class manageUser : System.Web.UI.Page
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

                HttpPostedFile postedFile = Request.Files["FileUpload"];
                if(postedFile != null && postedFile.ContentLength > 0)
                {
                    
                    string filePath = Server.MapPath("tmpFiles/") + Path.GetFileName(postedFile.FileName);

                    postedFile.SaveAs(filePath);
                    

                    FileHolder fh = new FileHolder();
                    fh.FName = "~/tmpFiles/" + Path.GetFileName(postedFile.FileName);
                    
                    context.FileHolders.Add(fh);
                    user1.PhotoRef = fh.FID;

                }

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
            else
            {
                Text1.Value = user1.N_ame;
                Text2.Value = user1.Gender;
                Text3.Value = user1.Email;
                Text4.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(' ', 'T');
                Text5.Value = user1.Title;
                string cname = context.Companies.Find((int)user1.Company).N_ame;
                Text6.Value = cname;

                Image img = new Image();
                img.ImageUrl = getfilepath(user1);
                img.Height = Unit.Pixel(100);
                img.Width = Unit.Pixel(100);

                imageHere.Controls.Add(img);

            }
        }

        public string getfilepath(myUser u)
        {
            string imagePath = "Content/data/images/defM.png";

            if (u.PhotoRef == null) //no photo added
            {
                if (u.Gender.Equals("F"))
                {
                    imagePath = "Content/data/images/defF.png";
                }
            }
            else
            {
                OfficeChatDBEntities context = new OfficeChatDBEntities();

                FileHolder fh = new FileHolder();
                fh = context.FileHolders.Find(u.PhotoRef);
                imagePath = fh.FName;

            }

            return imagePath;
        }

    }
}