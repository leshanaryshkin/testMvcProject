using System;
using Microsoft.AspNetCore.Connections;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using testMvcProject.Models.Users;

namespace testMvcProject.Models.DAOs.UsersDAO
{
    public class UsersDAO
    {
        private SqliteConnection connection = new SqliteConnection("Data Source=DB");

        public UsersDAO()
        {
        }

        public void AddUser(Person person)
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand();
            command.Connection = connection;

            command.CommandText = String.Format("INSERT INTO Users (Name, Adress, Telephone) VALUES ('{0}', '{1}', '{2}')", person.Name, person.Adress, person.Telephone);
            command.ExecuteNonQuery();

            UsersLoginsPasswordsDAO.AddUserLogPass(person, connection);
        }

        public bool ContainTelephone(String telephone)
        {
            connection.Open();
            string sqlExpression = String.Format("SELECT Telephone FROM Users WHERE Telephone = '{0}'", telephone);
            SqliteCommand command = new SqliteCommand(sqlExpression);
            command.Connection = connection;
            
            SqliteDataReader reader = command.ExecuteReader();
            bool readerHasRows = reader.HasRows;
            
            reader.Close();
            
            return readerHasRows;
        }

        //That static class works with UsersLoginsPasswords DB and do
        //CRUD operations automatically at the end of some base class function>
        private static class UsersLoginsPasswordsDAO
        {
            internal static void AddUserLogPass(Person person, SqliteConnection connection)
            {
                connection.Open();
            
                string sqlExpression = String.Format("SELECT ID FROM Users WHERE Telephone = '{0}'", person.Telephone);
                SqliteCommand command = new SqliteCommand(sqlExpression);
                command.Connection = connection;
            
                SqliteDataReader reader = command.ExecuteReader();
                reader.Read();
            
                int ID = Convert.ToInt16(reader.GetValue(0));
                reader.Close();

                command.CommandText = String.Format("INSERT INTO UsersLoginsPasswords (User_ID, Login, Password) VALUES ('{0}', '{1}', '{2}')", ID, person.Telephone, person.Name);
                command.ExecuteNonQuery();
            }
        }
        
    }
}