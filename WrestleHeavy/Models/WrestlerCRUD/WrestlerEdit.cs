using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using static Data.Entities.Enums;

namespace Models.WrestlerCRUD
{
    public class WrestlerEdit
    {
        public int WrestlerId { get; set; }
        [Display(Name = "Ring Name")]
        public string RingName { get; set; }
        [Display(Name = "Favorite")]
        public bool IsStarred { get; set; }
        public Gender Gender { get; set; }
        [Display(Name = "Promotion")]
        public int PromotionId { get; set; }
        public string PromotionName { get; set; }
        public IEnumerable<SelectListItem> Promotions { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}
