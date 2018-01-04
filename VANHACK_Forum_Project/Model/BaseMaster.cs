using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace VANHACK_Forum_Project.Model
{
    public class BaseMaster : System.Web.UI.MasterPage
    {
        public void Alert(string Header, string Body)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.Page), Header, "alert('" + Body + "');", true);

        }


        public void AlertwithRedirect(string Header, string Body, string Page)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Header,
    "alert('" + Body + "');window.location ='" + Page + "';",
    true);

        }
    }
}