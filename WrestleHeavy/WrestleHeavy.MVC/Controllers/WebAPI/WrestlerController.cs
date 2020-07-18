using Microsoft.AspNet.Identity;
using Models.WrestlerCRUD;
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
    [RoutePrefix("api/Wrestler")]
    public class WrestlerController : ApiController
    {
        private bool SetStarState(int wrestlerId, bool newState)
        {
            //Create the Service
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WrestlerService(userId);

            //Get the Wrestler
            var detail = service.GetWrestlerById(wrestlerId);

            //Create the WrestlerEdit model instance with the new star state
            var updatedWrestler = new WrestlerEdit
            {
                WrestlerId = detail.WrestlerId,
                RingName = detail.RingName,
                IsStarred = newState,
                Gender = detail.Gender,
                PromotionId = detail.PromotionId,
                Wins = detail.Wins,
                Losses = detail.Losses
            };

            //Return a value indicating whether the update succeeded or not
            return service.UpdateWrestler(updatedWrestler);
        }

        [Route("{id}/Star")]
        [HttpPut]
        public bool ToggleStarOn(int id) => SetStarState(id, true);

        [Route("{id}/Star")]
        [HttpDelete]
        public bool ToggleStarOff(int id) => SetStarState(id, false);
    }
}
