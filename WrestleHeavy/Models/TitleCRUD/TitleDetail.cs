using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.TitleCRUD
{
    public class TitleDetail
    {
        [Display(Name = "Title ID")]
        public int TitleId { get; set; }

        [Display(Name = "Title Name")]
        public string TitleName { get; set; }

        [Display(Name = "Date Established")]
        public DateTimeOffset DateEstablished { get; set; }

        [Display(Name ="Promotion")]
        public string PromotionName { get; set; }
        [Display(Name = "Current Champion")]
        public string WrestlerName { get; set; }
        [Display(Name = "Current Champion")]
        public int? WrestlerId { get; set; }

        [Display(Name = "Date Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
