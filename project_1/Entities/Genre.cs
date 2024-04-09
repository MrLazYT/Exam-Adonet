using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_1.Entities
{
    public class Genre
    {
        public Genre()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        [Required, MinLength(5), MaxLength(30)]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
