using Data;
using Data.Entities;
using Models.WrestlerCRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WrestleHeavy.Data;

namespace Services
{
    public class WrestlerService
    {
        private readonly Guid _userId;
        private ApplicationDbContext _ctx = new ApplicationDbContext();

        public WrestlerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateWrestler(WrestlerCreate model)
        {
            var entity = new Wrestler()
            {
                OwnerId = _userId,
                RingName = model.RingName,
                Gender = model.Gender,
                DateOfBirth = model.DateOfBirth,
                Nationality = model.Nationality,
                PromotionId = model.PromotionId,
                Wins = model.Wins,
                Losses = model.Losses,
                CreatedUtc = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Wrestlers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<WrestlerListItem> GetWrestlers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Wrestlers
                    .Where(e => e.OwnerId == _userId)
                    .Select(e => new WrestlerListItem
                    {
                        WrestlerId = e.WrestlerId,
                        RingName = e.RingName,
                        IsStarred = e.IsStarred,
                        PromotionName = e.Promotion.PromotionName,
                        Wins = e.Wins,
                        Losses = e.Losses,
                        CreatedUtc = e.CreatedUtc
                    });
                return query.ToArray();
            }
        }

        public WrestlerDetail GetWrestlerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Wrestlers
                    .Single(e => e.WrestlerId == id
                    && e.OwnerId == _userId);
                return new WrestlerDetail
                {
                    WrestlerId = entity.WrestlerId,
                    RingName = entity.RingName,
                    IsStarred = entity.IsStarred,
                    Gender = entity.Gender,
                    DateOfBirth = entity.DateOfBirth,
                    Nationality = entity.Nationality,
                    PromotionId = entity.PromotionId,
                    Wins = entity.Wins,
                    Losses = entity.Losses,
                    CreatedUtc = entity.CreatedUtc
                };
            }
        }

        public bool UpdateWrestler(WrestlerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Wrestlers.Single(e =>
                e.WrestlerId == model.WrestlerId
                && e.OwnerId == _userId);

                entity.RingName = model.RingName;
                entity.IsStarred = model.IsStarred;
                entity.Gender = model.Gender;
                entity.PromotionId = model.PromotionId;
                entity.Wins = model.Wins;
                entity.Losses = model.Losses;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteWrestler(int wrestlerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Wrestlers.Single(e =>
                e.WrestlerId == wrestlerId
                && e.OwnerId == _userId);

                ctx.Wrestlers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
