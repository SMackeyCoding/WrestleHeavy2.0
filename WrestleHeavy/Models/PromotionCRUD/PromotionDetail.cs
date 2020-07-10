using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PromotionDetail
    {
        [Display(Name = "Promotion ID")]
        public int PromotionId { get; set; }

        [Display(Name = "Promotion Name")]
        public string PromotionName { get; set; }

        [Display(Name = "Date Founded")]
        public DateTime DateFounded { get; set; }

        [Display(Name = "Website")]
        public string Website { get; set; }

        [Display(Name = "Date Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
