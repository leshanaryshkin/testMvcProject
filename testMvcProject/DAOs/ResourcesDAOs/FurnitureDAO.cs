using System;
using testMvcProject.Models.Resources.ImplementedResources;

using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace testMvcProject.Models.DAOs.ResourcesDAOs
{
    public class FurnitureDAO
    {
        private List<Furniture> FurnituresList { get; } = new List<Furniture>();

        private SqliteConnection connection = new SqliteConnection("Data Source=DB");

        public FurnitureDAO()
        {
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
                    double PricePerMeter = Convert.ToDouble(reader.GetValue(3));
                    int OnStock = Convert.ToInt16(reader.GetValue(4));

                    Furniture furniture = new Furniture(Name, FactoryCost, PricePerMeter, OnStock);
                    FurnituresList.Add(furniture);
                }
            
            reader.Close();
        }
        
        public void AddFurniture(Furniture furniture)
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand();
            command.Connection = connection;

            command.CommandText = String.Format("INSERT INTO Furniture (Name, FactoryCost, PricePerOncer, OnStock) VALUES ('{0}', '{1}', '{2}', '{3}')", furniture.Name, furniture.CostPrice, furniture.storeMargin, furniture.onStock);
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

        public void MakeNotActual(string _Name)
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand();
            command.Connection = connection;

            command.CommandText = String.Format("UPDATE Furniture SET ActualPosition = 'false' WHERE Name = '{0}')", _Name);
            command.ExecuteNonQuery();
        }
        
        
        
    }
}