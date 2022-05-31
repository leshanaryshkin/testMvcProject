using System;
using testMvcProject.DataBase;
using System.Collections.Generic;

namespace testMvcProject.DataBaseDAOs.Balance
{
    public interface IBalanceManager
    {

            void Create(DataBase.Balance balance);
            List<DataBase.Balance> GetAll();
            DataBase.Balance Get(string currencyName);
        void changeCurrencyBalance(string currencyName, int Num);
    }
}
