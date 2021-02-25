using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdamBednorzZadanieDomowe6.Models.Entities
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
        [Required]
        public string Producer { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string PhotoPath { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
