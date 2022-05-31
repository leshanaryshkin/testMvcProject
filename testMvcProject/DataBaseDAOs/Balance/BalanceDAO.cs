using System;
using testMvcProject.DataBase;
using System.Collections.Generic;
using System.Linq;

namespace testMvcProject.DataBaseDAOs.Balance
{
    public class BalanceDAO : IBalanceManager
    {
        private readonly DBContext2 dBContext;

        public BalanceDAO(DBContext2 dBContext)
        {
            this.dBContext = dBContext;
        }

        public void Create(DataBase.Balance currency)
        {
            dBContext.Balances.Add(currency);

            dBContext.SaveChanges();
        }

        public List<DataBase.Balance> GetAll() => dBContext.Balances.ToList();

        public DataBase.Balance Get(string currencyName) => dBContext.Balances.FirstOrDefault(p => p.currencyName == currencyName);

        public void changeCurrencyBalance(string currencyName, int Num)
        {
            DataBase.Balance balance = new DataBase.Balance();
            balance = Get(currencyName);
            if (balance != null)
            {
                balance.currencyBalance += Num;
                dBContext.Entry(balance).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dBContext.SaveChanges();
            }

        }

    }
}
