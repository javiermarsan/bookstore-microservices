using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Basket.API.Infrastructure.Model
{
    [Table("BasketItem")]
    public class BasketItemEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public Guid BasketId { get; set; }
    }
}
