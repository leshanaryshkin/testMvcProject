using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace testMvcProject.DataBase
{
    public class UserLoginPassword
    {
        [Required]
        public int ID { get; set; }
        [ForeignKey(nameof(ID))]
        public virtual User User { get; set; }

        [StringLength(15)] public string Login { get; set; }
        [StringLength(50)] public string Password { get; set; }
        public bool Is_admin { get; set; } = false;

    }
}


