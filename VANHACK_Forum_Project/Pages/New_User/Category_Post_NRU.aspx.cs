using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VANHACK_Forum_Project.Model;

namespace VANHACK_Forum_Project.Pages.New_User
{
    public partial class Category_Post_NRU : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdn_Category_id.Value = Request.QueryString["ID"];
                List<Category_Model> CurrentCategory = Category.GetCategory(int.Parse(hdn_Category_id.Value ?? "0"));
                if (CurrentCategory != null)
                {
                    lblCategoryTitle.Text = CurrentCategory[0].Category_Title;
                }
                if (UserOBJ != null)
                {
                    if (UserOBJ.UserType == User_Type.Admin || UserOBJ.UserType == User_Type.Admin)
                    {
                        radgrid1.Visible = true;
                        radgrid2.Visible = false;
                    }

                    else
                    {
                   
                        radgrid1.Visible = false;
                        radgrid2.Visible = true;
                    }


                }

            }

        }


        protected void radgrid_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                CheckBox chk = (CheckBox)item["ShowHideCHCK"].Controls[0];
                chk.Enabled = true;
            }
        }




        protected void btnSave_Click(object sender, EventArgs e)
        {
            string items = string.Empty;
            foreach (GridDataItem item in radgrid1.MasterTableView.Items)
            {
                CheckBox chk = (CheckBox)item.FindControl("ShowHideCHCK");
                string value = item.GetDataKeyValue("id").ToString();

                if (chk.Checked)
                {

                    items += value + ",";

                }


            }
            var list = items.TrimEnd(',');
        }
        protected void RadGrid1_BatchEditCommand(object sender, GridBatchEditingEventArgs e)
        {
            foreach (GridBatchEditingCommand command in e.Commands)
            {

                Hashtable newValues = command.NewValues;
                Hashtable oldValues = command.OldValues;


                string New_status = newValues["status"].ToString();
                string Post_ID = oldValues["Id"].ToString();


                Post_Model P_ModelOBJ = new Post_Model();
                P_ModelOBJ.Status = Convert.ToBoolean(New_status);
                P_ModelOBJ.ID = Convert.ToInt32(Post_ID);
                bool _res = Post.UpdatePost_status(P_ModelOBJ);
                if (!_res)
                    Alert("Error", "Status has not been saved! Please try again");

            }

        }
 

    }
}