using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VANHACK_Forum_Project.Model;

namespace VANHACK_Forum_Project.UserControl
{
    public partial class UC_User_ADD : BaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {

                User_Model NewUser = new User_Model();
                NewUser.Email = inputEmail.Value.Trim();
                NewUser.Password = inputPassword.Value;
                NewUser.User_Name = inputName.Value.Trim();
                NewUser.UserType = User_Type.Member;
                NewUser.Birth_Date = (DateTime)DatePicker1.SelectedDate;
                bool Done = Users.AddUser(NewUser);
                if (Done == true)
                {
                    AlertwithRedirect("Welcome","Congrats! Now you are a member of our Forums","/Pages/Default.aspx");
                }
                else
                {
                    Alert("Error", "Some errors happened. Save failed!! ");
                }
            }
            else
            {
                Alert("Attention", "Some feilds are not validated! ");
            }
        }
    }
}