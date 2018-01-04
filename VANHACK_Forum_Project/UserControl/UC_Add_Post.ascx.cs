using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VANHACK_Forum_Project.Model;

namespace VANHACK_Forum_Project.UserControl
{
    public partial class UC_Add_Post : BaseControl
    {
        public string Category_Id
        {
            get
            {
                if (ViewState["_Category_IdAP"] == null) return string.Empty;
                return ViewState["_Category_IdAP"].ToString();
            }
            set
            {
                ViewState["_Category_IdAP"] = value;
                hdn__Category_IdAP.Value = value;


            }
        }
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
            
        }

        protected void btn_send_Click(object sender, EventArgs e)
        {
            //CMD.Parameters.AddWithValue("@Category_Id", P_Model.Category_Id);
            //CMD.Parameters.AddWithValue("@User_Id", P_Model.User_Id);
            //CMD.Parameters.AddWithValue("@Title", P_Model.Title);
            //CMD.Parameters.AddWithValue("@Description", P_Model.Description);

            //CMD.Parameters.AddWithValue("@User_id", P_Model.User_Id);
            //CMD.Parameters.AddWithValue("@Post_TXT", P_Model.Details_lst[0].Post_TXT);
            //CMD.Parameters.AddWithValue("@Post_TypeID", (int)Post_Type.Post);
            if(string.IsNullOrEmpty(Category_Id))
            {
                AlertwithRedirect("Error", "Try Again and if this error still hapen please contact Admin", "/Pages/Default.aspx");
                return;
            }
            Post_Model Post_M_Object = new Post_Model();
            Post_M_Object.Category_Id = int.Parse(Category_Id.Trim());
            Post_M_Object.User_Id = UserOBJ.ID;
            Post_M_Object.Title = inputTitle.Value;
            Post_M_Object.Description = "";
            
            List<Post_Details_Model> PD_List = new List<Post_Details_Model>();
            Post_Details_Model PD_Model = new Post_Details_Model();

            PD_Model.User_Id = UserOBJ.ID;
            PD_Model.Post_TXT = Editor1.Content;
            PD_Model.Post_TypeID = Post_Type.Post;

            PD_List.Add(PD_Model);

            Post_M_Object.Details_lst = PD_List;

            int Res = Post.InsertPost(Post_M_Object);

            if(Res>0)
            {
                AlertwithRedirect("Attention", "You have added new post successfully..", "/Pages/Post_View.aspx?pageindex=1&ID="+Res);
                return;
            }
            else
            {
                Alert("Error", "Try Again and if this error still hapen please contact Admin");
                return;
            }
        }
    }
}