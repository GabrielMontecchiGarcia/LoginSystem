using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoginSystem.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required, MinLength(1), MaxLength(50)]
        public string Nome { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
