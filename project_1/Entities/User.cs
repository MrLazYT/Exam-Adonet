using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_1.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required, MinLength(2), MaxLength(30)]
        public string Name { get; set; }
        [Required, MinLength(15), MaxLength(30)]
        public string Surname { get; set; }
        [Required, MinLength(10), MaxLength(50)]
        public string Email { get; set; }
        [Required, MinLength(16), MaxLength(50)]
        public string Password { get; set; }

        public virtual ICollection<Book> ReservedBooks { get; set; }
        public virtual ICollection<Seller> Sellers { get; set; }
    }
}