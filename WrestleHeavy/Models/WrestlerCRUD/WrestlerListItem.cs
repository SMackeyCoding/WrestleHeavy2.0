using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.WrestlerCRUD
{
    public class WrestlerListItem
    {
        [Display(Name = "Wrestler ID")]
        public int WrestlerId { get; set; }

        [Display(Name = "Ring Name")]
        public string RingName { get; set; }
        
        [UIHint("Starred")]
        [Display(Name = "Favorite")]
        public bool IsStarred { get; set; }

        [Display(Name = "Promotion")]
        public string PromotionName { get; set; }
        public int PromotionId { get; set; }
        public virtual Promotion Promotion { get; set; }
        public IEnumerable<SelectListItem> Promotions { get; set; }

        // If too crowded, take away Win and Loss

        public int Wins { get; set; }
        public int Losses { get; set; }


        [Display(Name = "Date Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
