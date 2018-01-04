using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VANHACK_Forum_Project.UserControl
{
    public partial class UC_Posts : System.Web.UI.UserControl
    {
        public string Category_Id
        {
            get
            {
                if (ViewState["_Category_Id"] == null) return string.Empty;
                return ViewState["_Category_Id"].ToString();
            }
            set
            {
                ViewState["_Category_Id"] = value;
                hdn_Category_Id.Value = value;
             
                
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void BindUC()
        {
            hdn_Category_Id.Value=Category_Id;
            RadGrid_Posts.DataBind();
        }
    }
}