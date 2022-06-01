using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace testMvcProject.DataBase
{
    public class OrderContain
    {
        public int order_ID { get; set; }

        public int WindowID { get; set; }
        [ForeignKey(nameof(WindowID))]
        public virtual Window Window { get; set; }



    }
}