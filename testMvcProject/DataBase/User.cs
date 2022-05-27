using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace testMvcProject.DataBase
{
    public class User
    {
        [Required]
        public int ID { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Adress { get; set; }
        [StringLength(15)]
        public string telephone { get; set; }
    }
}

