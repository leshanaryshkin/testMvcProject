using System;
using testMvcProject.Models.Resources.ImplementedResources;
using testMvcProject.Models.Resources;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using testMvcProject.DAOs.BalanceDAO;

namespace testMvcProject.Models.DAOs.ResourcesDAOs
{
    public class resourceDAO
    {
        public FurnitureDAO FurnitureDao { get; set; } = new FurnitureDAO();
        public ProfilesDAO ProfilesDao { get; set; } = new ProfilesDAO();
        public BalanceDAO BalanceDao { get; set; } = new BalanceDAO();
        
        public resourceDAO()
        {
        }
        

        
    }
}
