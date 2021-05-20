using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Book.API.Infrastructure.Model
{
    [Table("Book")]
    public class BookEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BookId { get; set; }

        [Required]
        [StringLength(500)]
        public string Title { get; set; }

        public DateTime? PublicationDate { get; set; }

        [Required]
        public Guid BookAuthorId { get; set; }
    }
}
