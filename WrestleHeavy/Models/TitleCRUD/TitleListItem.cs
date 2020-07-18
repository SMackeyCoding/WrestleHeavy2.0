using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.TitleCRUD
{
    public class TitleListItem
    {
        [Display(Name = "Title Id")]
        public int TitleId { get; set; }

        [Display(Name = "Title Name")]
        public string TitleName { get; set; }

        [UIHint("Starred")]
        [Display(Name = "Favorite")]
        public bool IsStarred { get; set; }
        [Display(Name ="Date Established")]
        public DateTime DateEstablished { get; set; }

        [Display(Name = "Promotion")]
        public string PromotionName { get; set; }
        public virtual Promotion Promotion { get; set; }
        public IEnumerable<SelectListItem> Promotions { get; set; }

        [Display(Name = "Current Champion")]
        public string WrestlerName { get; set; }
        public virtual Wrestler Wrestler { get; set; }
        public IEnumerable<SelectListItem> Wrestlers { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
    }
}
