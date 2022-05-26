using System;
using System.ComponentModel.DataAnnotations;
namespace testMvcProject.DataBase
{
    public class Furniture
    {
        [Key]
        public int ID { get; set; }

        //UNIQUE
        [StringLength(40)]
        public string Name { get; set; }

        public int costPrice { get; set; }
        public int pricePerOnce { get; set; }

        public int onStock { get; set; }
        public bool isActualPosition { get; set; } = true;
    }
}
