using System;
using System.ComponentModel.DataAnnotations;

namespace testMvcProject.DataBase
{
    public class Balance
    {
        [Key]
        public int ID { get; set; }

        [StringLength(20)]
        public string currencyName { get; set; }
        public int currencyBalance { get; set; }


    }
}
