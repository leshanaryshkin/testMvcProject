using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace testMvcProject.DataBase
{
    public class Window
    {
        public int ID { get; set; }

        public int height { get; set; }
        public int width { get; set; }

        public int FurnitureID { get; set; }
        [ForeignKey(nameof(FurnitureID))]
        public virtual Furniture Furniture { get; set;}

        public int ProfileID { get; set; }
        [ForeignKey(nameof(ProfileID))]
        public virtual Profile Profile { get; set; }

        public int howManyCameras { get; set; }
        public int howManySashes { get; set; }

        public int price { get; set; }
    }
}
