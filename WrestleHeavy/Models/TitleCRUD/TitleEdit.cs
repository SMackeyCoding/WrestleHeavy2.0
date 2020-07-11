using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.TitleCRUD
{
    public class TitleEdit
    {
        public int TitleId { get; set; }
        public string TitleName { get; set; }
        public bool IsStarred { get; set; }

        [Display(Name ="Date Established")]
        public DateTimeOffset DateEstablished { get; set; }

        [Display(Name = "Current Champion")]
        public int? WrestlerId { get; set; }
        public IEnumerable<SelectListItem> Wrestlers { get; set; }
    }
}
