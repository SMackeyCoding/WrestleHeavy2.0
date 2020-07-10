using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using static Data.Entities.Enums;

namespace Data.Entities
{
    public class Wrestler
    {
        [Key]
        public int WrestlerId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string RingName { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public DateTimeOffset DateOfBirth { get; set; }
        [Required]
        public Nationality Nationality { get; set; }

        [Required, ForeignKey("Promotion")]
        public int? PromotionId { get; set; }
        public virtual Promotion Promotion { get; set; }
        public IEnumerable<SelectListItem> Promotions { get; set; }


        [Required]
        public int Wins { get; set; }
        [Required]
        public int Losses { get; set; }
        [Required]
        public decimal WinLossRatio { get; set; }
        [Required]
        public bool IsChampion { get; set; }
        //[ForeignKey("Title")]
        //public int? TitleId { get; set; }
        //public virtual Title Title { get; set; }

        [DefaultValue(false)]
        public bool IsStarred { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public List<Wrestler> Wrestlers { get; set; }
        //public List<Promotion> Promotions { get; set; }
    }
}
