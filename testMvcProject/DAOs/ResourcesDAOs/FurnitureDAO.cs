using System;
using testMvcProject.Models.Resources.ImplementedResources;

using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;

namespace testMvcProject.Models.DAOs.ResourcesDAOs
{
    public class FurnitureDAO
    {

        private SqliteConnection connection = new SqliteConnection("Data Source=DB");

        public FurnitureDAO()
        {
        }

        public List<Furniture> getFurnitureList()
        {
            List<Furniture> FurnituresList = new List<Furniture>();
            
            connection.Open();
            
            string sqlExpression = String.Format("SELECT * FROM Furniture");
            SqliteCommand command = new SqliteCommand(sqlExpression);
            command.Connection = connection;
            
            SqliteDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
                while (reader.Read())
                {
                    string Name = Convert.ToString(reader.GetValue(1));
                    double FactoryCost = Convert.ToDouble(reader.GetValue(2));
                    double PricePerOnce = Convert.ToDouble(reader.GetValue(3));
                    int OnStock = Convert.ToInt16(reader.GetValue(4));

                    bool isActual = Convert.ToBoolean(reader.GetValue(5));
                    
                    Furniture furniture = new Furniture(Name, FactoryCost, PricePerOnce, OnStock, isActual);
                    FurnituresList.Add(furniture);
                }
            
            reader.Close();

            return FurnituresList;
        }

        public void AddFurniture(Furniture furniture)
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand();
            command.Connection = connection;

            command.CommandText = String.Format("INSERT INTO Furniture (Name, FactoryCost, PricePerOnce, OnStock) VALUES ('{0}', '{1}', '{2}', '{3}')", furniture.Name, furniture.CostPrice, furniture.storeMargin, furniture.onStock);
            command.ExecuteNonQuery();
            
        }

        /*
        public void DeleteFurniture(string _Name)
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand();
            command.Connection = connection;

            command.CommandText = String.Format("DELETE FROM Furniture WHERE Name = '{0}')", _Name);
            command.ExecuteNonQuery();

        }*/

        public void ChangeActual(string _Name)
        {
            connection.Open();
            string sqlExpression = String.Format("Select ActualPosition From Furniture WHERE Name = '{0}'", _Name);
            SqliteCommand command = new SqliteCommand(sqlExpression);
            command.Connection = connection;

            SqliteDataReader reader = command.ExecuteReader();
            reader.Read();

            if(Convert.ToBoolean(reader.GetValue(0)) == true)
                 sqlExpression = String.Format("UPDATE Furniture SET ActualPosition = 'false' WHERE Name = '{0}'", _Name);
            else
                 sqlExpression = String.Format("UPDATE Furniture SET ActualPosition = 'true' WHERE Name = '{0}'", _Name);

            command = new SqliteCommand(sqlExpression);
            command.Connection = connection;
            command.ExecuteNonQuery();
            reader.Close();

            
        }
        
        
        
    }
}