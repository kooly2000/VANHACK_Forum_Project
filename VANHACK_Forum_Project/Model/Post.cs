using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace VANHACK_Forum_Project.Model
{
    public class Post
    {
        private static List<Post_Model> ConvertToPostList(DataTable table)
        {
            var postList = new List<Post_Model>();
            foreach (DataRow row in table.Rows)
            {
                var post = new Post_Model()
                {

                    ID = (int)row[0],
                    Category_Id = (int)row[1],
                    User_Id = (int)row[2],
                    Title = (string)(row[3] ?? ""),
                    Description = (string)(row[4] == DBNull.Value ? "" : row[4] ),
                    Status = (bool)row[5],
                    Date_Created = (DateTime)row[6],
                    Update_Date = row[7] == DBNull.Value ? (DateTime?)null : (DateTime)row[7],
                    Details_lst =   GetPostOfDetails((int)row[0])
                    
                };

                postList.Add(post);
            }
            return postList;
        }
        private static List<Post_Details_Model> ConvertToPost_Details_List(DataTable table)
        {
            var post_dtl_List = new List<Post_Details_Model>();
            foreach (DataRow row in table.Rows)
            {
                var post = new Post_Details_Model()
                {
                    ID = (int)row[0],
                    Post_Id = (int)row[1],
                    User_Id=(int)row[2],
                    Post_TXT = (string)(row[3] ?? ""),
                    Post_TypeID = (Post_Type)(row[4]),
                    Create_Date = (DateTime)row[5],
                    update_Date = row[6] == DBNull.Value ? (DateTime?)null : (DateTime)row[6],
                    Status = (bool)row[7]                
                };

                post_dtl_List.Add(post);
            }
            return post_dtl_List;
        }

        public static List<Post_Model> GetAllPostOfCategory(int Categ_ID)
        {
            SqlCommand CMD = new SqlCommand();
            CMD.CommandText = "select * from Post where Category_Id=@Category_Id";
            CMD.Parameters.AddWithValue("@Category_Id", Categ_ID);

            DataTable DT = new DB().string_DataTable_fix(CMD);
            var List = ConvertToPostList(DT);

            return List;
        }
        public static List<Post_Model> GetPost(int post_ID)
        {
            SqlCommand CMD = new SqlCommand();
            CMD.CommandText = "select * from Post where id=@Id";
            CMD.Parameters.AddWithValue("@Id", post_ID);

            DataTable DT = new DB().string_DataTable_fix(CMD);
            var List = ConvertToPostList(DT);

            return List;
        }
        public static List<Post_Details_Model> GetPostOfDetails(int post_ID)
        {
            SqlCommand CMD = new SqlCommand();
            CMD.CommandText = "select * from Post_Details where Post_Id=@Post_Id";
            CMD.Parameters.AddWithValue("@Post_Id", post_ID);

            DataTable DT = new DB().string_DataTable_fix(CMD);
            var List = ConvertToPost_Details_List(DT);

            return List;
        }
        public static List<Post_Model> GetCountPostOfCategory(int post_ID)
        {
            SqlCommand CMD = new SqlCommand();
            CMD.CommandText = "select * from Post where Category_Id=@Category_Id";
            CMD.Parameters.AddWithValue("@Category_Id", post_ID);

            DataTable DT = new DB().string_DataTable_fix(CMD);
            var List = ConvertToPostList(DT);

            return List;
        }

        public static int InsertPost(Post_Model P_Model)
        {
            SqlCommand CMD = new SqlCommand();
            CMD.CommandText = @"DECLARE @vocno [int]; INSERT INTO [dbo].[Post] ( [Category_Id], [User_Id], [Title], [Description],  [Update_Date])  
                            VALUES ( @Category_Id ,  @User_Id ,  @Title ,  @Description ,   getdate() ) ; SELECT @vocno  = SCOPE_IDENTITY();
                INSERT INTO [dbo].[Post_Details] ([Post_Id], [User_id], [Post_TXT], [Post_TypeID] ) VALUES 
             (@vocno,@User_id,@Post_TXT,@Post_TypeID);SELECT @vocno ";
            CMD.Parameters.AddWithValue("@Category_Id", P_Model.Category_Id);
            CMD.Parameters.AddWithValue("@User_Id", P_Model.User_Id);
            CMD.Parameters.AddWithValue("@Title", P_Model.Title);
            CMD.Parameters.AddWithValue("@Description", P_Model.Description);

            CMD.Parameters.AddWithValue("@Post_TXT", P_Model.Details_lst[0].Post_TXT);
            CMD.Parameters.AddWithValue("@Post_TypeID", (int)Post_Type.Post);

            int Res = 0;
            Res = new DB().int_ExecuteScalar(CMD);

            return Res ;
        }
        public static bool UpdatePost_status(Post_Model P_Model)
        {
            SqlCommand CMD = new SqlCommand();
            CMD.CommandText = @"Update [dbo].[Post] set status =@status where id=@id";
            CMD.Parameters.AddWithValue("@status", P_Model.Status);
            CMD.Parameters.AddWithValue("@id", P_Model.ID);
       

            int Res = new DB().int_ExecuteNonQuery_Odbc(CMD);

            return Res > 0 ? true : false;
        }
        public static bool UpdatePostDetails_status(Post_Details_Model P_M_Model)
        {
            SqlCommand CMD = new SqlCommand();
            CMD.CommandText = @"Update [dbo].[Post_Details] set status =@status where id=@id";
            CMD.Parameters.AddWithValue("@status", P_M_Model.Status);
            CMD.Parameters.AddWithValue("@id", P_M_Model.ID);


            int Res = new DB().int_ExecuteNonQuery_Odbc(CMD);

            return Res > 0 ? true : false;
        }

        public static bool UpdatePost_UpdateDate(Post_Model P_Model)
        {
            SqlCommand CMD = new SqlCommand();
            CMD.CommandText = @"Update [dbo].[Post] set update_date =getdate() where id=@id";
            CMD.Parameters.AddWithValue("@id", P_Model.ID);


            int Res = new DB().int_ExecuteNonQuery_Odbc(CMD);

            return Res > 0 ? true : false;
        }
        public static bool   InsertPostDetails(Post_Details_Model PD_Model)
        {
            SqlCommand CMD = new SqlCommand();
            CMD.CommandText = @"INSERT INTO [dbo].[Post_Details] ([Post_Id], [User_id], [Post_TXT], [Post_TypeID] ) VALUES 
             (@Post_Id,@User_id,@Post_TXT,@Post_TypeID)";
            CMD.Parameters.AddWithValue("@Post_Id", PD_Model.Post_Id);
            CMD.Parameters.AddWithValue("@User_id", PD_Model.User_Id);
            CMD.Parameters.AddWithValue("@Post_TXT", PD_Model.Post_TXT);
            CMD.Parameters.AddWithValue("@Post_TypeID", (int)PD_Model.Post_TypeID);


            int Res = new DB().int_ExecuteNonQuery_Odbc(CMD);
            if (Res > 0)
            {
                Post_Model P_ModelOBJ = new Post_Model();
                P_ModelOBJ.ID = PD_Model.Post_Id;
                bool Done = UpdatePost_UpdateDate(P_ModelOBJ);
            }
            
            return Res > 0 ? true : false;
        }
    }

    public class Post_Model
    {
        public int ID { get; set; }
        public int Category_Id { get; set; }
        public int User_Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime Date_Created { get; set; }
        public DateTime? Update_Date { get; set; }
        public List<Post_Details_Model>  Details_lst { get; set; }
        
       

    }
    public class Post_Details_Model
    {
        public int ID { get; set; }
        public int Post_Id { get; set; }
        public int User_Id { get; set; }
        public string Post_TXT { get; set; }
        public Post_Type Post_TypeID { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime? update_Date { get; set; }
        public bool Status { get; set; }
    }
     public enum  Post_Type{
        Post=1 ,
        Reply=2
    }
}