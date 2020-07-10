using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WrestleHeavy.Data;

namespace Data.Entities
{
    public class Repos
    {
        public class PromotionRepo
        {
            public IEnumerable<SelectListItem> GetPromotions()
            {
                using (var ctx = new ApplicationDbContext())
                {
                    List<SelectListItem> promotions = ctx.Promotions.AsNoTracking()
                        .OrderBy(n => n.PromotionName)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.PromotionId.ToString(),
                            Text = n.PromotionName
                        }).ToList();
                    var promotionTip = new SelectListItem()
                    {
                        Value = null,
                        Text = "Select a Promotion"
                    };
                    promotions.Insert(0, promotionTip);
                    return new SelectList(promotions, "Value", "Text");
                }
            }
        }
    }
}
