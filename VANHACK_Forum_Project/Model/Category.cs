using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace VANHACK_Forum_Project.Model
{
    public class Category
    {
        public static List<Category_Model> GetAllCategoriesHierarchy()
        {
            SqlCommand CMD = new SqlCommand();
            CMD.CommandText = "select * from Category";

            DataTable DT = new DB().string_DataTable_fix(CMD);
            var List = ConvertToCategoryList(DT);
            
            return List;
        }
        public static List<Category_Model> GetCategory(int Category_ID)
        {
            SqlCommand CMD = new SqlCommand();
            CMD.CommandText = "select * from Category where ID=@ID";
            CMD.Parameters.AddWithValue("@ID", Category_ID);

            DataTable DT = new DB().string_DataTable_fix(CMD);
            var List = ConvertToCategoryList(DT);

            return List;
        }

        //public static List<Category_Model> GetALLSubCategories(List<Category_Model> lst, int Category_id)
        //{
        //    var list = lst.Where(x => x.Category_Main == Category_id).ToList();

        //    return list;
        //}
        public static List<Category_Model> GetSubCategories(List<Category_Model> lst, int Category_id)
        {
            List<Category_Model> list = new List<Category_Model>();

            //var subList = lst.Where(x => x.Category_Main == Category_id);//.Select(t => (GetSubCategories(lst, t.ID).Count == 0) ? new List<Category_Model> { t } : GetSubCategories(lst, t.ID)).ToList();
            foreach (var item in lst.Where(x => x.Category_Main == Category_id))
            {
              
                list.Add(item);
                list.AddRange(GetSubCategories(lst, item.ID));
            }

            return list;

        }
        public static List<Category_Model> GetSubCategoriesWithMainCategory(List<Category_Model> lst, int Category_id)
        {
            List<Category_Model> list = new List<Category_Model>();

            //var subList = lst.Where(x => x.Category_Main == Category_id);//.Select(t => (GetSubCategories(lst, t.ID).Count == 0) ? new List<Category_Model> { t } : GetSubCategories(lst, t.ID)).ToList();
            foreach (var item in lst.Where(x => x.Category_Main == Category_id || x.ID == Category_id))
            {
                if (item.ID == Category_id)
                {
                    list.Add(item);
                    continue;
                }
                list.Add(item);
                list.AddRange(GetSubCategories(lst, item.ID));
            }

            return list;

        }
        private static List<Category_Model> ConvertToCategoryList(DataTable table)
        {
            var categoryList = new List<Category_Model>();   
            foreach (DataRow row in table.Rows)
            {
                var category = new Category_Model()
                {

                    ID = (int)row[0],
                    Category_Main = row[1] == DBNull.Value ? (int?)null : (int)row[1],
                    Category_Title = (string)row[2],
                    Status = (bool)row[3]
                };
                categoryList.Add(category);
            }
            return categoryList;
        }
    }
    [Serializable()]
    public class  Category_Model
    {
        public int ID { get; set; }
        public int? Category_Main { get; set; }
        public string Category_Title { get; set; }
        public bool Status { get; set; }
    }
}