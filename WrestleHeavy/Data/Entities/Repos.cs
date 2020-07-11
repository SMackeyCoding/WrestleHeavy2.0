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

        public class WrestlerRepo
        {
            public IEnumerable<SelectListItem> GetWrestlers()
            {
                using (var ctx = new ApplicationDbContext())
                {
                    List<SelectListItem> wrestlers = ctx.Wrestlers.AsNoTracking()
                        .OrderBy(n => n.RingName)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.WrestlerId.ToString(),
                            Text = n.RingName
                        }).ToList();
                    var wrestlerTip = new SelectListItem()
                    {
                        Value = null,
                        Text = "Select a Wrestler"
                    };
                    wrestlers.Insert(0, wrestlerTip);
                    return new SelectList(wrestlers, "Value", "Text");
                }
            }
        }
    }
}
