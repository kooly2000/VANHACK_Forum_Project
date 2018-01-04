using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace VANHACK_Forum_Project.Model
{
    public class Users
    {
        private static List<User_Model> ConvertToUserList(DataTable table)
        {
            var usertList = new List<User_Model>();
            foreach (DataRow row in table.Rows)
            {
                var user = new User_Model()
                {

                    ID = (int)row[0],
                    Email = (string)row[1],
                    Password = (string)(row[2] ?? ""),
                    User_Name = (string)(row[3] ?? ""),
                    Birth_Date = (DateTime)row[4],
                    UserType = (User_Type)User_Type.ToObject(typeof(User_Type), row[5]),
                    Creat_Date = (DateTime)row[6]
                };

                usertList.Add(user);
            }
            return usertList;
        }
        public static List<User_Model> GetUser(string Email, string password)
        {
            SqlCommand CMD = new SqlCommand();
            CMD.CommandText = "select * from [User]  where Email=@Email and Password=@Password";
            CMD.Parameters.AddWithValue("@Email", Email);
            CMD.Parameters.AddWithValue("@Password", password);


            DataTable DT = new DB().string_DataTable_fix(CMD);
            var List = ConvertToUserList(DT);

            return List;
        }
        public static List<User_Model> GetUserByIdOnly(string USER_ID)
        {
            SqlCommand CMD = new SqlCommand();
            CMD.CommandText = "select * from [User]  where ID=@ID";
            CMD.Parameters.AddWithValue("@ID", USER_ID);
 

            DataTable DT = new DB().string_DataTable_fix(CMD);
            var List = ConvertToUserList(DT);

            return List;
        }
        public static bool AddUser(User_Model NewUser)
        {
            SqlCommand CMD = new SqlCommand();
            CMD.CommandText = "INSERT INTO [dbo].[User] ( [Email], [Password], [Name], [Birth_Date], [User_Type]) VALUES (@Email, @Password, @Name, @Birth_Date, @User_Type)";
            CMD.Parameters.AddWithValue("@Email", NewUser.Email);
            CMD.Parameters.AddWithValue("@Name", NewUser.User_Name);
            CMD.Parameters.AddWithValue("@Birth_Date", NewUser.Birth_Date);
            CMD.Parameters.AddWithValue("@Password", NewUser.Password);
            CMD.Parameters.AddWithValue("@User_Type",(int) NewUser.UserType);
 


            int Res = new DB().int_ExecuteNonQuery_Odbc(CMD);


            return Res > 0 ? true : false;
        }
        public void En()
        {
            using (Aes myAes = Aes.Create())
            {
                string encSTR = "Ayman";
                // Encrypt the string to an array of bytes.
                byte[] encrypted = Encryption.EncryptStringToBytes_Aes(encSTR, myAes.Key, myAes.IV);

                // Decrypt the bytes to a string.
                string roundtrip = Encryption.DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);

                //Display the original data and the decrypted data.
                Console.WriteLine("Original:   {0}", encSTR);
                Console.WriteLine("Round Trip: {0}", roundtrip);
            }

        }



    }
    [Serializable()]
    public class User_Model
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string User_Name { get; set; }
        public DateTime Birth_Date { get; set; }
        public User_Type UserType { get; set; }
        public DateTime Creat_Date { get; set; }
    }

    public enum User_Type
    {
        SuperAdmin = 1,
        Admin = 2,
        Member = 3
    }
}
