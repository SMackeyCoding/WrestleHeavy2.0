using Data.Entities;
using Models.TitleCRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrestleHeavy.Data;

namespace Services
{
    public class TitleService
    {
        private readonly Guid _userId;

        public TitleService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTitle(TitleCreate model)
        {
            var entity = new Title()
            {
                OwnerId = _userId,
                TitleName = model.TitleName,
                DateEstablished = model.DateEstablished,
                WrestlerId = model.WrestlerId,
                PromotionId = model.PromotionId,
                CreatedUtc = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Titles.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TitleListItem> GetTitles()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Titles
                    .Where(e => e.OwnerId == _userId)
                    .Select(e => new TitleListItem
                    {
                        TitleId = e.Id,
                        TitleName = e.TitleName,
                        IsStarred = e.IsStarred,
                        DateEstablished = e.DateEstablished,
                        PromotionName = e.Promotion.PromotionName,
                        WrestlerName = e.Wrestler.RingName,
                        CreatedUtc = e.CreatedUtc
                    });
                return query.ToArray();
            }
        }

        public TitleDetail GetTitleById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Titles
                    .Single(e => e.Id == id
                    && e.OwnerId == _userId);
                return new TitleDetail
                {
                    TitleId = entity.Id,
                    TitleName = entity.TitleName,
                    IsStarred = entity.IsStarred,
                    DateEstablished = entity.DateEstablished,
                    PromotionId = entity.PromotionId,
                    WrestlerId = entity.WrestlerId,
                    CreatedUtc = entity.CreatedUtc
                };
            }
        }

        public bool UpdateTitle(TitleEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Titles.Single(e =>
                e.Id == model.TitleId
                && e.OwnerId == _userId);

                entity.Id = model.TitleId;
                entity.TitleName = model.TitleName;
                entity.IsStarred = model.IsStarred;
                entity.DateEstablished = model.DateEstablished;
                entity.WrestlerId = model.WrestlerId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTitle(int titleId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Titles.Single(e =>
                e.Id == titleId
                && e.OwnerId == _userId);

                ctx.Titles.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
