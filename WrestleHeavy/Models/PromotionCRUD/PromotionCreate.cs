using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PromotionCreate
    {
        [Required]
        [MinLength(3, ErrorMessage = "Please enter at least 3 characters.")]
        [MaxLength(50, ErrorMessage = "Please enter a shorter name for the promotion.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Date Founded")]
        public DateTime DateFounded { get; set; }
   
        [Required]
        [MinLength(9, ErrorMessage = "Please enter a full web address.")]
        public string Website { get; set; }
    }
}
