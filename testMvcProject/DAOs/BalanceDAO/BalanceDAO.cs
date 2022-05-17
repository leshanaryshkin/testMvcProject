using Microsoft.Data.Sqlite;
using System;
using testMvcProject.Models.Resources.ImplementedResources;

using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;
using testMvcProject.Models.Currency;


namespace testMvcProject.DAOs.BalanceDAO
{
    public class BalanceDAO
    {
        private SqliteConnection connection = new SqliteConnection("Data Source=DB");

        public BalanceDAO()
        {
        }

        public void ChangeCurrencyBalance(string CurrencyName, int Number)
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand();
            command.Connection = connection;

            command.CommandText = String.Format("UPDATE Balance SET CurrencyBalance = CurrencyBalance + '{0}' WHERE CurrencyName = '{1}'", Number, CurrencyName);
            command.ExecuteNonQuery();
        }

        public int GetCurrencyNumber(string CurrencyName)
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand();
            command.Connection = connection;

            command.CommandText = String.Format("Select CurrencyBalance FROM Balance WHERE CurrencyName = '{0}'",  CurrencyName);
            SqliteDataReader reader = command.ExecuteReader();

            reader.Read();
            int CurrencyBalance = Convert.ToInt32(reader.GetValue(0));
            Console.WriteLine(CurrencyBalance);
            return CurrencyBalance;
        }

        public List<Currency> GetBalanceList()
        {

            List<Currency> currencies = new List<Currency>();
            
            connection.Open();
            
            string sqlExpression = String.Format("SELECT * FROM Balance");
            SqliteCommand command = new SqliteCommand(sqlExpression);
            command.Connection = connection;
            
            SqliteDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
                while (reader.Read())
                {
                    string CurrencyName = Convert.ToString(reader.GetValue(1));
                    int CurrencyBalance = Convert.ToInt16(reader.GetValue(2));

                    Currency currency = new Currency();
                    currency.CurrencyName = CurrencyName;
                    currency.CurrencyBalance = CurrencyBalance;
                }
            
            reader.Close();

            return currencies;

        }
    }
}