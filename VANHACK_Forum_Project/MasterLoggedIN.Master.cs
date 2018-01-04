using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;
using System.Web.UI.WebControls;
using VANHACK_Forum_Project.Model;

namespace VANHACK_Forum_Project
{
     
    public partial class MasterLoggedIN :BaseMaster
    {
        public User_Model UserOBJ
        {
            get
            {
                if (Session["UserObject"] == null) return null;
                return (User_Model)Session["UserObject"];
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserOBJ==null)
            {
                //AlertwithRedirect("Attention", "Your session is over please login to continue surfing the forums","/Pages/New_User/Login_Default.aspx");
                Response.Redirect("~/Pages/New_User/Login_Default.aspx");
                return;
            }
            lbl_UserName.Text = UserOBJ.User_Name;
            //Alert("Alert", "Hello!!!!");
            lbl_Date.Text = DateTime.Now.ToShortDateString();
        }

        protected void LogOut_Click(object sender, EventArgs e)
        {
            
            Session.Clear();
            AlertwithRedirect("Attention", "You have successfully logged out, see you later", "/Pages/New_User/Login_Default.aspx");
        }
      
    }
}