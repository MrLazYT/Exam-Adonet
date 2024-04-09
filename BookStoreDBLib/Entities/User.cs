using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreDBLib.Entities
{
    [Serializable]
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required, MinLength(2), MaxLength(30)]
        public string Name { get; set; }
        [Required, MinLength(15), MaxLength(30)]
        public string Surname { get; set; }
        [Required, MinLength(10), MaxLength(50)]
        public string Email { get; set; }
        [Required, MinLength(16), MaxLength(50)]
        public string Password { get; set; }
    }
}