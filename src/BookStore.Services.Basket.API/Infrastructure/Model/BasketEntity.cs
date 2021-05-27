using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Basket.API.Infrastructure.Model
{
    [Table("Basket")]
    public class BasketEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BasketId { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}
