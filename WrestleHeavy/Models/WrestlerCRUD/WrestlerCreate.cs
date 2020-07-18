using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WrestleHeavy.Data;
using static Data.Entities.Enums;

namespace Models.WrestlerCRUD
{
    public class WrestlerCreate
    {
        [Required]
        [Display(Name = "Ring Name")]
        [MinLength(1, ErrorMessage = "Please enter at least one character.")]
        [MaxLength(25, ErrorMessage = "Please enter 25 characters or less.")]
        public string RingName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public Nationality Nationality { get; set; }

        [Display(Name = "Promotion")]
        public int PromotionId { get; set; }
        public IEnumerable<SelectListItem> Promotions { get; set; }

        [Required]
        public int Wins { get; set; }

        [Required]
        public int Losses { get; set; }

        //[Required]
        //[Display(Name = "Is this wrestler currently a champion?")]
        //public bool IsChampion { get; set; }
        //public int? TitleId { get; set; }
    }
}

