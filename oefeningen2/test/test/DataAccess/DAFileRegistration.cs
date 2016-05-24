using NMCT.DropBox.DataAccess;
using Shared;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using test.Models;

namespace test.DataAccess
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

        public static int DeleteItem(int id)
        {
            string sql = "Delete From FileRegistration WHERE FileId=@FileId";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@FileId", id);
            return Database.ModifyData(CONNECTIONSTRING, sql, par1);
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

        public static int EditFileRegistrationById(int id, string description)
        {
            string sql = "UPDATE FileRegistration SET Description=@Description WHERE FileId=@FileId";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@FileId", id);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@Description", description);
            return Database.InsertData(CONNECTIONSTRING, sql, par1, par2);
        }
        
        public static int SaveDownloaders(string user, int id)
        {
            string sql = "INSERT INTO FileUser VALUES(@FileId,@UserName)";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@FileId", id);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@UserName", user);
            return Database.InsertData(CONNECTIONSTRING, sql, par1, par2);
        }

        public static List<FileRegistration> GetFileRegistrationByName(string userName)
        {
            string sql = "SELECT * FROM FileRegistration WHERE UserName=@UserName";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@UserName", userName);
            DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql, par1);
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

        public static List<FileRegistration> GetUserAllowedFiles(string userName)
        {
            List<int> index = new List<int>();
            string sql = "SELECT * FROM FileUser WHERE UserName=@UserName";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@UserName", userName);
            DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql, par1);
            while (reader.Read())
            {
                index.Add((int)reader["FileId"]);
            }
            List<FileRegistration> files = GetFileRegistrationById(index, userName);
            return files;
        }

        public static Boolean CheckIfAdmin(string id)
        {
            string idRole = GetAspNetUserRolesById(id);
            Boolean admin = GetAspNetRolesById(idRole);
            return admin;
        }

        private static Boolean GetAspNetRolesById(string idRole)
        {
            string sql = "SELECT * FROM AspNetRoles WHERE Id=@Id";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@Id", idRole);
            DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql, par1);
            Boolean admin = false;
            while (reader.Read())
            {
                if (reader["Name"].ToString() == "Administrator") admin = true;
                else admin = false;
            }
            return admin;
        }

        private static string GetAspNetUserRolesById(string id)
        {
            string sql = "SELECT * FROM AspNetUserRoles WHERE UserId=@UserId";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@UserId", id);
            DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql, par1);
            string idRole = "";
            while (reader.Read())
            {
                idRole = reader["RoleId"].ToString();
            }
            return idRole;
        }

        public static List<FileRegistration> GetFileRegistrationById(List<int> index, string userName)
        {
            List<FileRegistration> fileRegistrations = null;
            if (CheckIfAdmin(GetASPNetUsersByName(userName)))
            {
                string sql = "SELECT * FROM FileRegistration WHERE NOT UserName=@UserName";
                DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@UserName", userName);
                DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql, par1);
                fileRegistrations = new List<FileRegistration>();
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
            }
            else
            {
                string sql = "SELECT * FROM FileRegistration";
                DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql);
                fileRegistrations = new List<FileRegistration>();
                while (reader.Read())
                {
                    for (int i = 0; i < index.Count(); i++)
                    {
                        if (index[i] == (int)reader["FileId"])
                        {
                            FileRegistration fileRegistration = new FileRegistration();
                            fileRegistration.FileId = (int)reader["FileId"];
                            fileRegistration.Description = reader["Description"].ToString();
                            fileRegistration.FileName = reader["FileName"].ToString();
                            fileRegistration.UploadTime = (DateTime)reader["UploadTime"];
                            fileRegistration.UserName = reader["UserName"].ToString();
                            fileRegistrations.Add(fileRegistration);
                        }
                    }
                }
            }
            return fileRegistrations;
        }

        public static string GetASPNetUsersByName(string userName)
        {
            string sql = "SELECT * FROM ASPNetUsers WHERE UserName=@UserName";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@UserName", userName);
            DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql, par1);
            string id = "";
            while (reader.Read())
            {
                id = reader["Id"].ToString();
            }
            return id;
        }

        public static int SaveUser(string userName, string password, Boolean blocked)
        {
            string sql = "INSERT INTO Appusers VALUES(@UserName,@Password,@Blocked)";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@UserName", userName);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@Password", password);
            DbParameter par3 = Database.AddParameter(CONNECTIONSTRING, "@Blocked", blocked);
            return Database.InsertData(CONNECTIONSTRING, sql, par1, par2, par3);
        }

        public static AppUser GetAppUsers(string userName, string password)
        {
            string sql = "SELECT * FROM Appusers WHERE UserName=@UserName AND Password=@Password";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@UserName", userName);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@Password", password);
            DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql, par1, par2);
            AppUser appUser = null;
            while (reader.Read())
            {
                appUser = new AppUser();
                appUser.Id = (int)reader["Id"];
                appUser.UserName = reader["UserName"].ToString();
                appUser.Password = reader["Password"].ToString();
                appUser.Blocked = (Boolean)reader["Blocked"];
            }
            return appUser;
        }

        public static int SaveLog(string userName, string fileName, string creator)
        {
            string sql = "INSERT INTO Logs VALUES(@UserName,@DateTime,@FileName,@Creator)";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@UserName", userName);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@FileName", fileName);
            DbParameter par3 = Database.AddParameter(CONNECTIONSTRING, "@Creator", creator);
            DbParameter par4 = Database.AddParameter(CONNECTIONSTRING, "@DateTime", DateTime.Now);
            return Database.InsertData(CONNECTIONSTRING, sql, par1, par2, par3, par4);
        }

        public static List<FileLog> GetLogs()
        {
            string sql = "SELECT * FROM Logs";
            DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql);
            List<FileLog> fileLogs = new List<FileLog>();
            while (reader.Read())
            {
                FileLog fileLog = new FileLog();
                fileLog.Id = (int)reader["Id"];
                fileLog.FileName = reader["FileName"].ToString();
                fileLog.UserName = reader["UserName"].ToString();
                fileLog.DateTime = (DateTime)reader["DateTime"];
                fileLog.Creator = reader["Creator"].ToString();
                fileLogs.Add(fileLog);
            }
            return fileLogs;
        }
    }
}