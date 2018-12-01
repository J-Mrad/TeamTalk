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
    //user2: person being messaged
    public partial class indexChat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int urgentflag = 0, receivedflag = 0;

            OfficeChatDBEntities context = new OfficeChatDBEntities();
            List<M_essage> msgs = context.M_essage.ToList();


            //remove any spam messages
            foreach (M_essage ms in msgs)
            {
                if (ms.T_ext == null)
                {
                    context.M_essage.Remove(ms);
                    context.SaveChanges();
                }
            }

            //getting users
            int u1 = (int)Session["curUserID"];
            myUser user1 = context.myUsers.Find(u1);
            int u2 = int.Parse((string)Session["user2"]);
            myUser user2 = context.myUsers.Find(u2);
            
            //setting up profile photo:
            Image pf = new Image();
            pf.ImageUrl = getProfilePhotoPath(user1);
            pf.CssClass = "profileImage rounded-circle float-right";
            profilePhoto.Controls.Add(pf);

            List<myUser> users = context.myUsers.ToList();

            //add user2 image, name, and status at top:
            string imagepath = getProfilePhotoPath(user2);
            string status = "Offline";
            string color = "red";
            if (user2.isOnline == 1)
            {
                status = "Online";
                color = "green";
            }

            user2Dets.InnerHtml = "<img src='" + imagepath + "' class='profileImageTo rounded-circle'/>"
                                    + "<span style = 'font-size:20px' > " + user2.N_ame + " </span>"
                                    + "<span style = 'color:" + color + "'> " + status + " </span>"
                                    + "<a href=\"index.aspx?\"> X </a>";
            M_essage mes = new M_essage();
            if (Request.QueryString["sending"] == "1" && IsPostBack) //text message
            {
                //Add typed message to database
                mes.timeSent = System.DateTime.Now;
                mes.SenderID = user1.UserID;
                mes.ReceiverID = user2.UserID;
                mes.isRead = 0;
                mes.isUrgent = 0;
                mes.isDeleted = 0;
                mes.isText = 1;
                mes.isFile = 0;
                mes.T_ext = Request.Form["messageIn"];

                if (Checkbox1.Checked == true)
                {
                    mes.isUrgent = 1;
                }
                if (mes.T_ext != "") context.M_essage.Add(mes);
                context.SaveChanges();
            }
            HttpPostedFile postedFile = Request.Files["fileupload"];
            if (postedFile != null && postedFile.ContentLength > 0)//file was uploaded
            {
                mes.isFile = 1;

                string filePath = Server.MapPath("tmpFiles/") + Path.GetFileName(postedFile.FileName);

                postedFile.SaveAs(filePath);

                FileHolder fh = new FileHolder();
                fh.FName = "tmpFiles/" + Path.GetFileName(postedFile.FileName);
                mes.FileRef = fh.FID;
                context.FileHolders.Add(fh);
                context.SaveChanges();

            }

            msgs = context.M_essage.ToList(); //refreshing messages list

            chatField.InnerHtml = "~Beginning of chat with " + user2.N_ame;

            //get messages/fileRefs from database with right sender/receiver and add them in order
            foreach (M_essage m in msgs)
            {
                //setting up read string
                string readString = "Not read yet";
                if (m.isRead == 1)
                {
                    readString = m.timeRead.ToString();
                }
                //form user2 to user1
                if (m.SenderID.Equals(user1.UserID) && m.ReceiverID.Equals(user2.UserID))
                {
                    if (m.isText == 1)
                    {
                        if (m.isUrgent == 1)
                        {
                            chatField.InnerHtml = chatField.InnerHtml + "<div class =\"row user2 urgent\"> Sent: " + m.timeSent + " Read: " + readString + " <br/>" + m.T_ext + " </div>";
                        }
                        else //not urgent
                        {
                            chatField.InnerHtml = chatField.InnerHtml + "<div class =\"row user2\"> " + m.timeSent + " Read: " + readString + " <br/>" + m.T_ext + " </div>";
                        }
                    }
                    if (m.isFile == 1) //file/photo
                    {
                        FileHolder fh2 = context.FileHolders.Find(m.FileRef);
                        String filepath = fh2.FName;
                        String ext3 = filepath.Substring(filepath.Length - 4);// .png .jpg
                        String ext4 = filepath.Substring(filepath.Length - 5);// .jpeg
                        if (ext3.Equals(".png") || ext3.Equals(".jpg") || ext4.Equals(".jpeg"))
                        {
                            chatField.InnerHtml = chatField.InnerHtml + "<div class =\"row user2\"> <img src = '" + fh2.FName + "' class='imgupload'> </div>";
                        }
                        else //non image file
                        {
                            string filename = filepath.Split('/')[1];
                            chatField.InnerHtml = chatField.InnerHtml + "<div class =\"row user2\"> <a href='" + fh2.FName + "' download> <img src='Content/data/icons/download.png' class='btnIcon icon'/> Download " + filename + "</a></div>";
                        }
                    }
                }
                //user1 to user2
                else if (m.SenderID.Equals(user2.UserID) && m.ReceiverID.Equals(user1.UserID))
                {
                    if (m.isText == 1)
                    {
                        if (m.isUrgent == 1)
                        {
                            chatField.InnerHtml = chatField.InnerHtml + "<div class =\"row user1 urgent\"> " + m.timeSent + " Read: " + readString + " <br/>" + m.T_ext + " </div>";
                        }
                        else //not urgent
                        {
                            chatField.InnerHtml = chatField.InnerHtml + "<div class =\"row user1\"> " + m.timeSent + " Read: " + readString + " <br/>" + m.T_ext + " </div>";
                        }
                    }
                    if (m.isFile == 1) //file/photo
                    {
                        FileHolder fh2 = context.FileHolders.Find(m.FileRef);
                        String filepath = fh2.FName;
                        String ext3 = filepath.Substring(filepath.Length - 4);// .png .jpg
                        String ext4 = filepath.Substring(filepath.Length - 5);// .jpeg
                        if(ext3.Equals(".png") || ext3.Equals(".jpg") || ext4.Equals(".jpeg"))
                        {
                            chatField.InnerHtml = chatField.InnerHtml + "<div class =\"row user2\"> <img src = '" + fh2.FName + "' class='imgupload'> </div>";
                        }
                        else //non image file
                        {
                            string filename = filepath.Split('/')[1];
                            chatField.InnerHtml = chatField.InnerHtml + "<div class =\"row user2\"> <button onclick=\"javascript: window.location = '" + fh2.FName + "'\" class='ButtonDownload'> <img src='Content/data/icons/download.png' class='btnIcon icon'/> Download " + filename + "</button></div>";
                        }

                    }
                    if (m.isRead == 0)
                    {
                        m.isRead = 1;
                        m.timeRead = System.DateTime.Now;
                    }
                }
            }
            context.SaveChanges();

            //Filling sidebar
            //get messages that are directed to user1 and unread then add them to the list (for no repetition)
            List<myUser> usersSending = new List<myUser>();
            List<myUser> usersSendingUrgent = new List<myUser>();

            foreach (M_essage m in msgs)
            {
                //if directed to user1
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
                but.ID = "" + sendingUser.UserID;

                HtmlGenericControl div1 = new HtmlGenericControl("div");
                div1.Controls.Add(but);
                div1.Controls.Add(new LiteralControl(" " + sendingUser.N_ame + " [" + sendingUser.Title + "]"));

                div1.Attributes["class"] = "sidenavbardivurgent";

                newChatHolder.Controls.Add(div1);
            }
            foreach (myUser sendingUser in usersSending)
            {
                receivedflag = 1;
                string imagePath = getProfilePhotoPath(sendingUser);

                ImageButton but = new ImageButton();
                but.ImageUrl = imagePath;
                but.Width = Unit.Pixel(50);
                but.Height = Unit.Pixel(50);
                but.OnClientClick = "Button_Click";
                but.Click += new ImageClickEventHandler(Button_Click);
                but.ID = "" + sendingUser.UserID;

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
            //refresh entire page
            System.Threading.Thread.Sleep(1500);
            HttpContext.Current.RewritePath("indexChat.aspx/sending=0");
         
            context.SaveChanges();
        }

        protected void Button_Click(object sender, EventArgs e)//clicked on a user to begin chatting with them
        {
            ImageButton b = (ImageButton)sender;
            Session["user2"] = b.ID;

            HttpContext.Current.RewritePath("indexChat.aspx?sending=0");
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

                if (imagePath.ElementAt(0).Equals('~'))
                {
                    imagePath = imagePath.Substring(2);
                }

            }

            return imagePath;
        }
    }
}