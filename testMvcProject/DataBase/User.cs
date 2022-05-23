using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace testMvcProject.DataBase
{
    public class User
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public string Adress { get; set; }
        public string telephone { get; set; }
        public bool Is_admin { get; set; } = false;
    }
}