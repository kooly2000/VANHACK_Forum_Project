using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VANHACK_Forum_Project.Pages
{
    public partial class Add_Category_Post : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                UC_Add_Post1.Category_Id = Request.QueryString["ID"];
        }
    }
}