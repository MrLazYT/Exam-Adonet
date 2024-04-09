using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_1.Entities
{
    public class SpecialOffer
    {
        public SpecialOffer()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        [Required, MinLength(15), MaxLength(100)]
        public string Name { get; set; }
        [Required, Range(1, 100)]
        public int Discount { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
