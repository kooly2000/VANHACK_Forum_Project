using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VANHACK_Forum_Project.Model;

namespace VANHACK_Forum_Project.Pages
{
    public partial class Post_View : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdn_PostID.Value = Request.QueryString["ID"];
                List<Post_Model> PostObj = Post.GetPost(int.Parse(hdn_PostID.Value ?? "0"));
                Fill_Post(PostObj);
               
                

                if (UserOBJ != null)
                {
                    if (UserOBJ.UserType == User_Type.Admin || UserOBJ.UserType == User_Type.Admin)
                    {
                        
                        AdminDiv.Visible = true;
                        UserDiv.Visible = false; 
                        Fill_Reply(PostObj,Repeater1);
                    }

                    else
                    {
                        if (PostObj[0].Status != true)
                        {
                            AlertwithRedirect("Attention", "You are trying to open either removed or hidden post", "/Pages/Default.aspx");
                            return;
                        }
                        AdminDiv.Visible = false;
                        UserDiv.Visible = true;
                        Fill_Reply(PostObj, Repeater2);

                    }


                }


                  
            }
        }

        private void Fill_Reply(List<Post_Model> PostObj,Repeater RPT)
        {
            
             PagedDataSource pds = new PagedDataSource(); 
             pds.DataSource = SqlDataSource1.Select(DataSourceSelectArguments.Empty);
             pds.AllowPaging = true; 
             pds.PageSize =20 ;

             int currentPage;

             if (Request.QueryString["Pageindex"] != null)
             {
                 currentPage = Int32.Parse(Request.QueryString["Pageindex"]);
             }
             else
             {
                 currentPage = 1;
             }

             pds.CurrentPageIndex = currentPage - 1;
             Label1.Text = "Page  " + currentPage + " of " + pds.PageCount;

             if (!pds.IsFirstPage)
             {
                 linkPrev.NavigateUrl = Request.CurrentExecutionFilePath + "?Pageindex=" + (currentPage - 1) + "&ID="+hdn_PostID.Value;
             }

             if (!pds.IsLastPage)
             {
                 linkNext.NavigateUrl = Request.CurrentExecutionFilePath + "?Pageindex=" + (currentPage + 1) + "&ID=" + hdn_PostID.Value;
             }

             RPT.DataSource = pds;
             RPT.DataBind(); 
         }

        private void Fill_Post(List<Post_Model> PostObj)
        {
            
            if (PostObj.Count > 0)
            {
                Post_Title_Div.InnerText = PostObj[0].Title;
                List<Post_Details_Model> PostContent_lst = PostObj[0].Details_lst.Where(x => x.Post_TypeID == Post_Type.Post).ToList();
                if (PostContent_lst.Count > 0)
                {
                    Post_Content_Div.InnerHtml = PostContent_lst[0].Post_TXT;
                    Reply_Date.InnerText = PostContent_lst[0].Create_Date.ToString() + " || "+ "Written by: "+   Users.GetUserByIdOnly( PostContent_lst[0].User_Id.ToString())[0].User_Name  ;
                }

            }
        }

        protected void btn_send_Click(object sender, EventArgs e)
        {
            try
            {


                //Editor1.Content;
                if (hdn_PostID.Value.Trim() == "")
                {
                    Alert("Attention", "There Migh be a mistake!! Please open this Post again . if this problem still happen, contact Admin");
                    return;
                }
                Post_Details_Model PD_MODEL_OBJ = new Post_Details_Model();
                PD_MODEL_OBJ.Post_Id = int.Parse(hdn_PostID.Value);
                PD_MODEL_OBJ.User_Id = UserOBJ.ID;
                PD_MODEL_OBJ.Post_TXT = Editor1.Content;
                PD_MODEL_OBJ.Post_TypeID = Post_Type.Reply;
                Post.InsertPostDetails(PD_MODEL_OBJ);
                Editor1.Content = "";
                List<Post_Model> PostObj = Post.GetPost(int.Parse(hdn_PostID.Value ?? "0"));
                Fill_Reply(PostObj,Repeater1);
                Fill_Reply(PostObj, Repeater2);

            }

            catch
            {
                Alert("Attention", "There Migh be a mistake!! Please open this Post again . if this problem still happen contact Admin");
                return;
            }
        }

        public void DoSend(object sender, EventArgs e)
        {
            foreach (RepeaterItem i in Repeater1.Items)
            {
                //Retrieve the state of the CheckBox
                CheckBox cb = (CheckBox)i.FindControl("selectPost");
                 
                    //Retrieve the value associated with that CheckBox
                    //HiddenField hiddenEmail = (HiddenField)i. ("hiddenEmail");

                    //Now we can use that value to do whatever we want
                    Post_Details_Model P_M_ModelOBJ = new Post_Details_Model();
                    HiddenField hidden = (HiddenField)i.FindControl("hdnID");

                    P_M_ModelOBJ.ID = Convert.ToInt32( hidden.Value);
                    P_M_ModelOBJ.Status = cb.Checked;
                    Post.UpdatePostDetails_status(P_M_ModelOBJ);
                
            }
        } 

      
    }
}