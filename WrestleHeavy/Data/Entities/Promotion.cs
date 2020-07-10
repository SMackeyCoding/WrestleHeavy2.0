using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Promotion
    {
        [Key]
        public int PromotionId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string PromotionName { get; set; }
        [Required]
        public DateTime DateFounded { get; set; }
        [Required]
        public string Website { get; set; }
        [DefaultValue(false)]
        public bool IsStarred { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public List<Promotion> Promotions { get; set; }
    }
}
