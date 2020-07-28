﻿using Data;
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
                PromotionName = model.PromotionName,
                DateFounded = model.DateFounded.Date,
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
                var query = ctx.Promotions
                    .Where(e => e.OwnerId == _userId)
                    .Select(e => new PromotionListItem
                {
                    PromotionId = e.PromotionId,
                    PromotionName = e.PromotionName,
                    //IsStarred = e.IsStarred,
                    DateFounded = e.DateFounded,
                    Website = e.Website,
                    CreatedUtc = e.CreatedUtc
                });

                

                return query.ToArray();
            }
        }

        public PromotionDetail GetPromotionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Promotions
                    .Single(e => e.PromotionId == id 
                    && e.OwnerId == _userId);
                return new PromotionDetail
                {
                    PromotionId = entity.PromotionId,
                    PromotionName = entity.PromotionName,
                    DateFounded = entity.DateFounded.Date,
                    Website = entity.Website,
                    CreatedUtc = entity.CreatedUtc
                };
            }
        }

        public bool UpdatePromotion(PromotionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Promotions.Single(e => 
                e.PromotionId == model.PromotionId 
                && e.OwnerId == _userId);

                entity.PromotionName = model.PromotionName;
                //entity.IsStarred = model.IsStarred;
                entity.DateFounded = model.DateFounded.Date;
                entity.Website = model.Website;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePromotion(int promotionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Promotions.Single(e => 
                e.PromotionId == promotionId 
                && e.OwnerId == _userId);

                ctx.Promotions.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
