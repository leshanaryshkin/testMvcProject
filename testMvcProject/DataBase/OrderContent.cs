using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace testMvcProject.DataBase
{
    public class OrderContent
    {
        [Key]
        public int ID { get; set; }


        public int WindowID { get; set; }
        [ForeignKey(nameof(WindowID))]
        public virtual Window Window { get; set; }

        public int ServicesListID { get; set; }
        [ForeignKey(nameof(ServicesListID))]
        public virtual ServicesToPos Services { get; set; }

        
    }
}
