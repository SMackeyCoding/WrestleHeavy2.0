using Microsoft.AspNet.Identity;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WrestleHeavy.MVC.Controllers.WebAPI
{
    [Authorize]
    [RoutePrefix("api/Promotion")]
    public class PromotionController : ApiController
    {
        private bool SetStarState (int promotionId, bool newState)
        {
            //Create the service
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PromotionService(userId);

            //Get the promotion
            var detail = service.GetPromotionById(promotionId);

            //Create the PromotionEdit model instance with the new star state
            var updatedPromotion = new PromotionEdit
            {
                PromotionId = detail.PromotionId,
                IsStarred = newState,
                DateFounded = detail.DateFounded,
                Website = detail.Website
            };

            //Return a value indicating whether the update succeeded
            return service.UpdatePromotion(updatedPromotion);
        }

        [Route("{id}/Star")]
        [HttpPut]
        public bool ToggleStarOn(int id) => SetStarState(id, true);

        [Route("{id}/Star")]
        [HttpDelete]
        public bool ToggleStarOff(int id) => SetStarState(id, false);
    }
}
