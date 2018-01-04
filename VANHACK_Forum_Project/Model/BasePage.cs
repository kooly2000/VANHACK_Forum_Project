using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

using System.Web;

namespace VANHACK_Forum_Project.Model
{
    public class BasePage : System.Web.UI.Page
    {
        public void Alert(string Header, string Body)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.Page), Header, "alert('" + Body + "');", true);

        }
        public User_Model UserOBJ
        {
            get
            {
                if (Session["UserObject"] == null) return null;
                return (User_Model)Session["UserObject"];
            }

        }
         

        public void AlertwithRedirect(string Header, string Body, string Page)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Header,
    "alert('" + Body + "');window.location ='" + Page + "';",
    true);

        }
    
    }
 
}