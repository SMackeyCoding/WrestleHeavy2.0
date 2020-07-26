using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PromotionEdit
    {
        public int PromotionId { get; set; }

        [Display (Name = "Promotion Name")]
        public string PromotionName { get; set; }
        public bool IsStarred { get; set; }
        public DateTime DateFounded { get; set; }
        public string Website { get; set; }
    }
}
