using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace testMvcProject.DataBase
{
    public class AdditionalService
    {
        [Key]
        public int ServiceID { get; set; }

        [StringLength(30)]
        //UNIQUE
        public string ServiceName { get; set; }

        public int ServicePrice { get; set; }
        public bool isActual { get; set; } = true;
    }
}
