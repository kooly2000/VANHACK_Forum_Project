using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VANHACK_Forum_Project.Model;

namespace VANHACK_Forum_Project.Pages.New_User
{
    public partial class Post_View_NRU : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdn_PostID.Value = Request.QueryString["ID"];
                List<Post_Model> PostObj = Post.GetPost(int.Parse(hdn_PostID.Value ?? "0")); 
                
                if (PostObj[0].Status != true)
                {
                    AlertwithRedirect("Attention", "You are trying to open either removed or hidden post", "/Pages/New_User/Login_Default.aspx");
                    return;
                }
                Fill_Post(PostObj);
                Fill_Reply(PostObj);

         
            }
        }
        private void Fill_Reply(List<Post_Model> PostObj)
        {

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            pds.AllowPaging = true;
            pds.PageSize = 20;

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
                linkPrev.NavigateUrl = Request.CurrentExecutionFilePath + "?Pageindex=" + (currentPage - 1) + "&ID=" + hdn_PostID.Value;
            }

            if (!pds.IsLastPage)
            {
                linkNext.NavigateUrl = Request.CurrentExecutionFilePath + "?Pageindex=" + (currentPage + 1) + "&ID=" + hdn_PostID.Value;
            }

            Repeater1.DataSource = pds;
            Repeater1.DataBind();
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
                    Reply_Date.InnerText = PostContent_lst[0].Create_Date.ToString() + " || " + "Written by: " + Users.GetUserByIdOnly(PostContent_lst[0].User_Id.ToString())[0].User_Name;

                }

            }
        }
    }
}