using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.TitleCRUD
{
    public class TitleEdit
    {
        public int TitleId { get; set; }
        public string TitleName { get; set; }
        public int? WrestlerId { get; set; }
    }
}
