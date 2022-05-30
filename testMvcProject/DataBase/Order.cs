using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;


namespace testMvcProject.DataBase
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [ForeignKey(nameof(UserID))]
        public int UserID { get; set; }
        public virtual User User { get; set; }

    }
}
