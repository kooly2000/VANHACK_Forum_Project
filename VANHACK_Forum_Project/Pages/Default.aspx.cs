using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VANHACK_Forum_Project.Model;
using VANHACK_Forum_Project.UserControl;
 
namespace VANHACK_Forum_Project.Pages
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                List<Category_Model> list = Category.GetAllCategoriesHierarchy();
                ViewState["_All_Categories"] = list;
                var listSub = Category.GetSubCategoriesWithMainCategory(list, 6);
            }
        }

        protected void RDTREE_LST_DataBound(object sender, EventArgs e)
        {
        }

        protected void RDTREE_LST_Load(object sender, EventArgs e)
        {
            this.RDTREE_LST.ExpandAllItems();

        }

        protected void RDTREE_LST_ItemCreated(object sender, Telerik.Web.UI.TreeListItemCreatedEventArgs e)
        {
            if (e.Item is TreeListDataItem)
            {
                var dataItem = (TreeListDataItem)e.Item;
                var expandCell = dataItem.Cells[dataItem.HierarchyIndex.NestedLevel];
                if (expandCell.Controls.Count > 0)
                {
                    expandCell.Controls[0].Visible = false;
                }
            }

            
        }

        protected void RDTREE_LST_ItemDataBound(object sender, TreeListItemDataBoundEventArgs e)
        {


            if (e.Item.TabIndex ==1 )
            {
                HtmlTableRow tr = (HtmlTableRow)e.Item.FindControl("tr_header");
                tr.Visible = false;
            }
            if (e.Item.ItemType == TreeListItemType.Item || e.Item.ItemType == TreeListItemType.AlternatingItem)
 
            {

                 //UC_Posts UC_Posts0 = (UC_Posts)e.Item.FindControl("UC_Posts1");
                List<Category_Model> list = (List<Category_Model>)ViewState["_All_Categories"];
                Label lblCATEG_ID = (Label)e.Item.FindControl("lbl_CategID1");
                PlaceHolder PlcH = (PlaceHolder)e.Item.FindControl("PlaceHolder1");
                Label lbl_PostCount1 = (Label)e.Item.FindControl("lbl_PostCount");
                var listPost = Post.GetAllPostOfCategory(int.Parse(lblCATEG_ID.Text.Trim()));
               
                lbl_PostCount1.Text = listPost.Count().ToString() ;
                //if (listSub.Count > 0)
                //{
                //    UC_Posts UC_Posts0 = this.LoadControl("~/UserControl/UC_Posts.ascx") as UC_Posts;
                //    UC_Posts0.Category_Id = lblCATEG_ID.Text;
                //    PlcH.Controls.Add(UC_Posts0);
                //    //UC_Posts0.BindUC();
                //}
            }
        }

      

      
    }
}