using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace project_1.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [Required, MinLength(10), MaxLength(150)]
        public string Title { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int PublishingHouseId { get; set; }
        public int? PageCount { get; set; }
        public int GenreId { get; set; }
        public int? Year { get; set; }
        [Required]
        public decimal CostPrice { get; set; }
        [Required]
        public decimal Price { get; set; }
        public bool? IsSequel { get; set; } = false;
        public int? SeriesId { get; set; }
        public int? Chapter { get; set; }
        [Required]
        public bool IsOnSale { get; set; } = false;
        [Required]
        public bool IsWriteOff { get; set; } = false;
        public int? SpecialOfferId { get; set; }
        public int? Views { get; set; } = 0;
        public int? ReservationId { get; set; }

        [NotMapped]
        public virtual Author Author { get; set; }
        [NotMapped]
        public virtual PublishingHouse PublishingHouse { get; set; }
        [NotMapped]
        public virtual Genre Genre { get; set; }
        [NotMapped]
        public virtual Series Series { get; set; }
        [NotMapped]
        public virtual SpecialOffer SpecialOffer { get; set; }
        [NotMapped]
        public virtual User ReservationUser { get; set; }
    }
}
