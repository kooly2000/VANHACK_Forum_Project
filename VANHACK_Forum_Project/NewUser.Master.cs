using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VANHACK_Forum_Project.Model;

namespace VANHACK_Forum_Project
{
    public partial class NewUser : BaseMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (inputEmail.Text.Trim() == "" || inputPassword.Text.Trim() == "")
            {
                Alert("Login failed!", "Please enter Email and password");
                return;
            }
            List<User_Model> lstUser = Users.GetUser(inputEmail.Text, inputPassword.Text);
            if(lstUser!=null)
            {
                if (lstUser.Count != 0)
                {
                    Session["UserObject"] = lstUser[0];
                    Response.Redirect("~/Pages/Default.aspx");
                }
                else
                {
                    Alert("Login failed!", "Sorry your Email or Password is wrong please make sure that you have entered them coorectly");
                    return;
                }
            }
            else
            {
                Alert("Login failed!", "Sorry your Email or Password is wrong please make sure that you have entered them coorectly");
                return;
            }


        }

      

  
    }
}