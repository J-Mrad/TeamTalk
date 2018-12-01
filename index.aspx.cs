using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TeamTalk;

namespace TeamTalk
{
    //user1: current person using the system
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int urgentflag = 0, receivedflag = 0;

            OfficeChatDBEntities context = new OfficeChatDBEntities();
            
            //getting user1 from session
            int u1 = (int)Session["curUserID"];
            myUser user1 = context.myUsers.Find(u1);

            //setting up profile photo:
            Image pf = new Image();
            pf.ImageUrl = getProfilePhotoPath(user1);
            pf.CssClass = "profileImage rounded-circle float-right";
            profilePhoto.Controls.Add(pf);
            
            //get messages that are directed to user1 and unread then add them to the list (for no repetition)
            List<myUser> usersSending = new List<myUser>();
            List<myUser> usersSendingUrgent = new List<myUser>();

            List<M_essage> msgs = context.M_essage.ToList();

            foreach (M_essage m in msgs)
            {
                if (m.ReceiverID.Equals(user1.UserID))
                {
                    myUser sendingUser = context.myUsers.Find(m.SenderID);
                    if (!usersSending.Contains(sendingUser) && !usersSendingUrgent.Contains(sendingUser))
                    {
                        if (m.isUrgent == 1 && m.isRead == 0)
                        {
                            usersSendingUrgent.Add(sendingUser);
                        }
                        else
                        {
                            usersSending.Add(sendingUser);
                        }
                    }

                }
            }
            //Go through the lists and add the users to the sidebar
            foreach (myUser sendingUser in usersSendingUrgent)
            {
                urgentflag = 1;
                receivedflag = 1;
                string imagePath = getProfilePhotoPath(sendingUser);

                ImageButton but = new ImageButton();
                but.ImageUrl = imagePath;
                but.Width = Unit.Pixel(50);
                but.Height = Unit.Pixel(50);
                but.Click += new ImageClickEventHandler(Button_Click);
                but.ID = "b" + sendingUser.UserID;

                HtmlGenericControl div1 = new HtmlGenericControl("div");
                div1.Controls.Add(but);
                div1.Controls.Add(new LiteralControl(" " + sendingUser.N_ame + " [" + sendingUser.Title + "]"));

                div1.Attributes["class"] = "sidenavbardivUrgent";

                newChatHolder.Controls.Add(div1);
            }
            foreach (myUser sendingUser in usersSending){
                receivedflag = 1;
                string imagePath = getProfilePhotoPath(sendingUser);

                ImageButton but = new ImageButton();
                but.ImageUrl = imagePath;
                but.Width = Unit.Pixel(50);
                but.Height = Unit.Pixel(50);
                but.OnClientClick = "Button_Click";
                but.Click += new ImageClickEventHandler(Button_Click);
                but.ID = "b" + sendingUser.UserID;
                    
                HtmlGenericControl div1 = new HtmlGenericControl("div");
                div1.Controls.Add(but);
                div1.Controls.Add(new LiteralControl(" " + sendingUser.N_ame + " [" + sendingUser.Title + "]"));
                    
                div1.Attributes["class"] = "sidenavbardiv";
                    
                newChatHolder.Controls.Add(div1);
            }
            //update message icon in top bar if needed
            if (receivedflag == 1)
            {
                msgLogo.Src = "Content/data/icons/msg.png";
            }
            if (urgentflag == 1)
            {
                msgLogo.Src = "Content/data/icons/msgUrg.png";
            }
            
            //row to hold them all
            HtmlGenericControl divRow = new HtmlGenericControl("div");
            divRow.Attributes["class"] = "row";

            //fill in users in same company
            List<myUser> users = context.myUsers.ToList();
            foreach (myUser u in users){
                if (u.Company.Equals(user1.Company) && !u.Equals(user1))
                {
                    string imagePath = getProfilePhotoPath(u);

                    ImageButton but = new ImageButton();
                    but.ImageUrl = imagePath;
                    but.Width = Unit.Pixel(100);
                    but.Height = Unit.Pixel(100);
                    but.Click += new ImageClickEventHandler(Button_Click);
                    but.ID = "" + u.UserID;


                    HtmlGenericControl div1 = new HtmlGenericControl("div");
                    div1.Attributes["class"] = "col-xl-1 col-md-3 col-sm-4 vertical";
                    div1.Controls.Add(but);
                    div1.Controls.Add(new LiteralControl("<h4>" + u.N_ame + "</h4><h6>" + u.Title + "</h6>"));

                    divRow.Controls.Add(div1);

                }
            }
            //and new row of contacts into chatfield
            contactsField.Controls.Add(divRow);
            context.SaveChanges();            
        }

        protected void Button_Click(object sender, EventArgs e)//clicked on a user to begin chatting with them
        {
            ImageButton b = (ImageButton)sender;
            if (b.ID.StartsWith("b"))
            {
                Session["user2"] = b.ID.Substring(1);
            }
            else
            {
                Session["user2"] = b.ID;

            }
            Response.Redirect("indexChat.aspx?sending=0");
        }

        protected void logoutButton(object sender, EventArgs e)
        {
            OfficeChatDBEntities context = new OfficeChatDBEntities();
            int u1 = (int)Session["curUserID"];
            myUser user1 = context.myUsers.Find(u1);
            user1.isOnline = 0;
            context.SaveChanges();
            Response.Redirect("Login.aspx");
        }

        public string getProfilePhotoPath(myUser u)
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