using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Title
    {
        [Key]
        public int TitleId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string TitleName { get; set; }
        [Required]
        public DateTimeOffset DateEstablished { get; set; }

        [Required]
        [ForeignKey("Promotion")]
        public int? PromotionId { get; set; }
        public virtual Promotion Promotion { get; set; }

        [Required]
        [ForeignKey("Wrestler")]
        public int? WrestlerId { get; set; }
        public virtual Wrestler Wrestler { get; set; }

        [DefaultValue(false)]
        public bool IsStarred { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
