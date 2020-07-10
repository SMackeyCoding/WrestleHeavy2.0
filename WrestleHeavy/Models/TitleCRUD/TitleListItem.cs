using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.TitleCRUD
{
    public class TitleListItem
    {
        public int TitleId { get; set; }
        public string TitleName { get; set; }
        public DateTimeOffset DateEstablished { get; set; }
        public string PromotionName { get; set; }
        public string WrestlerName { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
