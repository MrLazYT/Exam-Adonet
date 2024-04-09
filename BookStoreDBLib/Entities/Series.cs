﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreDBLib.Entities
{
    public class Series
    {
        public Series()
        {
            Books = new HashSet<Book>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required, MinLength(10), MaxLength(100)]
        public string Name { get; set; }

        [NotMapped]
        public virtual ICollection<Book> Books { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
