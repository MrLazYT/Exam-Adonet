using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_1.Entities
{
    public class Seller
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
