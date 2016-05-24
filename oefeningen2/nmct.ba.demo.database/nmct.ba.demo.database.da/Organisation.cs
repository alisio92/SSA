using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace nmct.ba.demo.database.da
{
    public class Organisation
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string DbName { get; set; }
        public string DbLogin { get; set; }
        public string DbPassword { get; set; }
        public string OrganisationName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public static Organisation GetOrganisationByLoginAndPassword(string username, string password)
        {
            string sql = "SELECT * FROM Organisation WHERE Login=@Login AND Password=@Password";
            DbParameter par1 = Database.AddParameter("AdminDB", "@Login", username);
            DbParameter par2 = Database.AddParameter("AdminDB", "@Password", password);

            try
            {
                DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql, par1, par2);
                reader.Read();
                return new Organisation()
                {
                    ID = Int32.Parse(reader["ID"].ToString()),
                    Login = reader["Login"].ToString(),
                    Password = reader["Password"].ToString(),
                    DbName = reader["DbName"].ToString(),
                    DbLogin = reader["DbLogin"].ToString(),
                    DbPassword = reader["DbPassword"].ToString(),
                    OrganisationName = reader["OrganisationName"].ToString(),
                    Address = reader["Address"].ToString(),
                    Email = reader["Email"].ToString(),
                    Phone = reader["Phone"].ToString()
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static int InsertOrganisation(Organisation o)
        {
            string sql = "INSERT INTO IT_Organisation VALUES(@Login,@Password,@DbName,@DbLogin,@DbPassword,@OrganisationName,@Address,@Email,@Phone)";
            DbParameter par1 = Database.AddParameter("AdminDB", "@Login", o.Login);
            DbParameter par2 = Database.AddParameter("AdminDB", "@Password", o.Password);
            DbParameter par3 = Database.AddParameter("AdminDB", "@DbName", o.DbName);
            DbParameter par4 = Database.AddParameter("AdminDB", "@DbLogin", o.DbLogin);
            DbParameter par5 = Database.AddParameter("AdminDB", "@DbPassword", o.DbPassword);
            DbParameter par6 = Database.AddParameter("AdminDB", "@OrganisationName", o.OrganisationName);
            DbParameter par7 = Database.AddParameter("AdminDB", "@Address", o.Address);
            DbParameter par8 = Database.AddParameter("AdminDB", "@Email", o.Email);
            DbParameter par9 = Database.AddParameter("AdminDB", "@Phone", o.Phone);
            int id = Database.InsertData(Database.GetConnection("AdminDB"), sql, par1, par2, par3, par4, par5, par6, par7, par8, par9);

            CreateDatabase(o);

            return id;
        }

        private static void CreateDatabase(Organisation o)
        {
            // create the actual database
            //string create = File.ReadAllText(HostingEnvironment.MapPath(@"~/App_Data/create.txt")); only for the web
            string create = File.ReadAllText(@"..\..\Data\create.txt"); // only for desktop
            string sql = create.Replace("@@DbName", o.DbName).Replace("@@DbLogin",o.DbLogin).Replace("@@DbPassword", o.DbPassword);
            foreach (string commandText in RemoveGo(sql))
            {
                Database.ModifyData(Database.GetConnection("AdminDB"), commandText);
            }

            // create login, user and tables
            DbTransaction trans = null;
            try
            {
                trans = Database.BeginTransaction("AdminDB");

                //string fill = File.ReadAllText(HostingEnvironment.MapPath(@"~/App_Data/fill.txt")); // only for the web
                string fill = File.ReadAllText(@"..\..\Data\fill.txt"); // only for desktop
                string sql2 = fill.Replace("@@DbName", o.DbName).Replace("@@DbLogin", o.DbLogin).Replace("@@DbPassword", o.DbPassword);

                foreach (string commandText in RemoveGo(sql2))
                {
                    Database.ModifyData(trans, commandText);
                }

                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Console.WriteLine(ex.Message);
            }
        }

        private static string[] RemoveGo(string input)
        {
            //split the script on "GO" commands
            string[] splitter = new string[] { "\r\nGO\r\n" };
            string[] commandTexts = input.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
            return commandTexts;
        }
    }
}
