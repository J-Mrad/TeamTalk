using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeamTalk
{
    public partial class CompanyManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OfficeChatDBEntities context = new OfficeChatDBEntities();
            int u1 = (int)Session["curUserID"];

            myUser user1 = context.myUsers.Find(u1);
            if (user1.Role != "manager")
            {
                wrapper.InnerHtml = "<h1>Managers only</h1> <a href='index.aspx'>Back to main page</a>";
            }
            else
            {
                Company c = context.Companies.Find(user1.Company);

                if (IsPostBack)
                {
                    string name = String.Format("{0}", Request.Form["Text1"]);
                    string desc = String.Format("{0}", Request.Form["Text2"]);
                    string email = String.Format("{0}", Request.Form["Text3"]);

                    c.N_ame = name;
                    c.D_esc = desc;
                    c.Email = email;

                    HttpPostedFile postedFile = Request.Files["FileUpload"];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                        string filePath = Server.MapPath("tmpFiles/") + Path.GetFileName(postedFile.FileName);

                        postedFile.SaveAs(filePath);


                        FileHolder fh = new FileHolder();
                        fh.FName = "~/tmpFiles/" + Path.GetFileName(postedFile.FileName);

                        context.FileHolders.Add(fh);
                        c.LogoRef = fh.FID;

                    }

                    user1.Company = c.CID;
                    context.SaveChanges();

                }
                else
                {
                    Text1.Value = c.N_ame;
                    Text2.Value = c.D_esc;
                    Text3.Value = c.Email;

                    Image img = new Image();
                    img.ImageUrl = getfilepathComp(c);
                    img.Height = Unit.Pixel(100);
                    img.Width = Unit.Pixel(100);

                    imageHere.Controls.Add(img);

                }
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
        public string getfilepathComp(Company c)
        {
            string imagePath = "Content/data/images/defComp.png";

            if (c.LogoRef != null) {
                OfficeChatDBEntities context = new OfficeChatDBEntities();

                FileHolder fh = new FileHolder();
                fh = context.FileHolders.Find(c.LogoRef);
                imagePath = fh.FName;
            }            
            return imagePath;
        }

    }
}