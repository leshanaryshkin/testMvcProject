using System;
using System.ComponentModel.DataAnnotations;

namespace testMvcProject.DataBase
{
    public class Profile
    {
        [Key]
        public int ID { get; set; }

        //UNIQUE
        [StringLength(40)]
        public string Name { get; set; }

        public int costPrice { get; set; }
        public int pricePerMeter { get; set; }

        private int onStock1;

        public int GetonStock()
        {
            return onStock1;
        }

        public void SetonStock(int value)
        {
            onStock1 = value;
        }

        public bool isActualPosition { get; set; } = true;
    }
}
