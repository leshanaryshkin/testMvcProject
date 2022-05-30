using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace testMvcProject.DataBase
{
    public class ServisePosList
    {
        [Key]
        public int ID { get; set; }
        public int OrderID { get; set; }
        [ForeignKey(nameof(OrderID))]
        public virtual Order Orders { get; set; }

        public int ServiceID { get; set; }
        [ForeignKey(nameof(ServiceID))]
        public virtual AdditionalService Service { get; set; }

    }
}
