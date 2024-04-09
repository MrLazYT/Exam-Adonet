using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_1.Entities
{
    public class Series
    {
        public Series()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        [Required, MinLength(10), MaxLength(100)]
        public string Name { get; set; }

        [NotMapped]
        public virtual ICollection<Book> Books { get; set; }
    }
}
