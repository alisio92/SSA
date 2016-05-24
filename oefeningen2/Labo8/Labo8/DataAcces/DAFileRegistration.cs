using Labo8.Models;
using NMCT.DropBox.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Labo8.DataAcces
{
    public class DAFileRegistration
    {
        private const string CONNECTIONSTRING = "DefaultConnection";

        public static int SaveFileRegistration(string fileName, string description, string userName)
        {
            string sql = "INSERT INTO FileRegistration VALUES(@Description,@FileName,@UploadTime,@UserName)";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@Description", description);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@FileName", fileName);
            DbParameter par3 = Database.AddParameter(CONNECTIONSTRING, "@UploadTime", DateTime.Now);
            DbParameter par4 = Database.AddParameter(CONNECTIONSTRING, "@UserName", userName);

            return Database.InsertData(CONNECTIONSTRING, sql, par1, par2, par3, par4);
        }

        public static int SaveDownloaders(string userName, int id)
        {
            string sql = "INSERT INTO FileUser VALUES(@FileId,@UserName)";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@FileId", id);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@UserName", userName);
            
            return Database.InsertData(CONNECTIONSTRING, sql, par1, par2);
        }

        public static int UpdateDescription(int id, string description)
        {
            string sql = "UPDATE FileRegistration SET Description=@Description WHERE FileId=@FileId";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@FileId", id);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@Description", description);

            return Database.ModifyData(CONNECTIONSTRING, sql, par1, par2);
        }

        public static List<FileRegistration> GetFileRegistration()
        {
            string sql = "SELECT * FROM FileRegistration";
            DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql);
            List<FileRegistration> fileRegistrations = new List<FileRegistration>();
            while (reader.Read())
            {
                FileRegistration fileRegistration = new FileRegistration();
                fileRegistration.FileId = (int)reader["FileId"];
                fileRegistration.Description = reader["Description"].ToString();
                fileRegistration.FileName = reader["FileName"].ToString();
                fileRegistration.UploadTime = (DateTime)reader["UploadTime"];
                fileRegistration.UserName = reader["UserName"].ToString();
                fileRegistrations.Add(fileRegistration);
            }
            return fileRegistrations;
        }

        public static bool getFunctionUser(string id)
        {
            return false;
        }

        public static int DeleteItem(int id)
        {
            string sql = "Delete From FileRegistration WHERE FileId=@FileId";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@FileId", id);
            return Database.ModifyData(CONNECTIONSTRING, sql, par1);
        }

        public static FileRegistration GetFileRegistrationById(int id)
        {
            string sql = "SELECT * FROM FileRegistration WHERE FileId=@FileId";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@FileId", id);
            DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql, par1);
            FileRegistration fileRegistration = new FileRegistration();
            while (reader.Read())
            {
                fileRegistration.FileId = (int)reader["FileId"];
                fileRegistration.Description = reader["Description"].ToString();
                fileRegistration.FileName = reader["FileName"].ToString();
                fileRegistration.UploadTime = (DateTime)reader["UploadTime"];
                fileRegistration.UserName = reader["UserName"].ToString();
            }
            return fileRegistration;
        }

        public static List<int> GetUserAllowedFiles(string userName)
        {
            List<int> files = new List<int>();
            if (userName != null)
            {
                string sql = "SELECT * FROM FileUser WHERE UserName=@UserName";
                DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@UserName", userName);
                DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql, par1);
                while (reader.Read())
                {
                    files.Add((int)reader["FileId"]);
                }
            }
            return files;
        }

        public static int SaveUser(string userName, string password, bool blocked)
        {
            string sql = "INSERT INTO ExternalUsers VALUES(@UserName,@Password,@Blocked)";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@UserName", userName);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@Password", password);
            DbParameter par3 = Database.AddParameter(CONNECTIONSTRING, "@Blocked", blocked);
            return Database.InsertData(CONNECTIONSTRING, sql, par1, par2, par3);
        }
    }
}