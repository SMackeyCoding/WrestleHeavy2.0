using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.TitleCRUD
{
    public class TitleCreate
    {
        [Required]
        [Display(Name = "Title Name")]
        [MinLength(14, ErrorMessage = "Please enter at least 14 characters.")]
        [MaxLength(35, ErrorMessage = "Please enter 35 characters or less.")]
        public string TitleName { get; set; }

        [Required]
        [Display(Name = "Date Established")]
        public DateTimeOffset DateEstablished { get; set; }

        [Required]
        [Display(Name = "Promotion")]
        public int? PromotionId { get; set; }
        public IEnumerable<SelectListItem> Promotions { get; set; }

        [Display(Name = "Current Champion")]
        public int? WrestlerId { get; set; }
        public IEnumerable<SelectListItem> Wrestlers { get; set; }
    }
}
