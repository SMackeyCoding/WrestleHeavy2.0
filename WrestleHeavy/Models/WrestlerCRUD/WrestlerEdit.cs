using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data.Entities.Enums;

namespace Models.WrestlerCRUD
{
    public class WrestlerEdit
    {
        public int WrestlerId { get; set; }
        public string RingName { get; set; }
        public bool IsStarred { get; set; }
        public Gender Gender { get; set; }
        public int? PromotionId { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public bool IsChampion { get; set; }
        public int? TitleId { get; set; }
    }
}
