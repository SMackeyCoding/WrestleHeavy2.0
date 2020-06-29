using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrestleHeavy.Data;

namespace Services
{
    public class PromotionService
    {
        private readonly Guid _userId;

        public PromotionService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePromotion(PromotionCreate model)
        {
            var entity = new Promotion()
            {
                OwnerId = _userId,
                Name = model.Name,
                DateFounded = model.DateFounded,
                Website = model.Website,
                CreatedUtc = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Promotions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PromotionListItem> GetPromotions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Promotions.Where(e => e.OwnerId == _userId).Select(e => new PromotionListItem
                {
                    PromotionId = e.PromotionId,
                    Name = e.Name,
                    DateFounded = e.DateFounded,
                    Website = e.Website,
                    CreatedUtc = e.CreatedUtc
                });
                return query.ToArray();
            }
        }
    }
}
