using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Connections;
using Microsoft.Data.Sqlite;
using testMvcProject.Models.Users;

namespace testMvcProject.DAOs.UsersDAO
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

        public bool ContainAccount(string Login, string Password)
        {
            return UsersLoginsPasswordsDAO.ContainAccount(Login, Password, connection);
        }

        public List<Person> getAllPersons()
        {
            List<Person> persons = new List<Person>();
            connection.Open();
            string sqlExpression = String.Format("SELECT * FROM Users");
            SqliteCommand command = new SqliteCommand(sqlExpression);
            command.Connection = connection;
            
            SqliteDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
                while (reader.Read())
                {
                    int ID = Convert.ToInt16(reader.GetValue(0));
                    string Name = Convert.ToString(reader.GetValue(1));
                    string Adress = Convert.ToString(reader.GetValue(2));
                    string Telephone = Convert.ToString(reader.GetValue(3));

                    Person person = new Person();
                    person.Name = Name;
                    person.Adress = Adress;
                    person.Telephone = Telephone;
                    person.PersonID = ID;
                    
                    persons.Add(person);
                }
            
            reader.Close();
            return persons;
        }
        
        public void deleteUser(int id)
        {
            connection.Open();
            
            UsersLoginsPasswordsDAO.deleteUser(id, connection);
            
            string sqlExpression = String.Format("Delete FROM Users WHERE ID = '{0}' ", id);
            SqliteCommand command = new SqliteCommand(sqlExpression);
            command.Connection = connection;
            command.ExecuteNonQuery();

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

            internal static bool ContainAccount(string login, string password, SqliteConnection connection)
            {
                connection.Open();
            
                string sqlExpression = String.Format("SELECT User_ID as ID, Login as Telephone, Password FROM UsersLoginsPasswords WHERE Login = '{0}' AND Password = '{1}'", login, password);
                SqliteCommand command = new SqliteCommand(sqlExpression);
                command.Connection = connection;
            
                SqliteDataReader reader = command.ExecuteReader();
                bool readerHasRows = reader.HasRows;
            
                reader.Close();
            
                return readerHasRows;
            
            }

            public static void deleteUser(int id, SqliteConnection connection)
            {
                connection.Open();
            
                string sqlExpression = String.Format("Delete FROM UsersLoginsPasswords WHERE User_ID = '{0}' ", id);
                SqliteCommand command = new SqliteCommand(sqlExpression);
                command.Connection = connection;
                command.ExecuteNonQuery();
            }


        }
        
    }
}