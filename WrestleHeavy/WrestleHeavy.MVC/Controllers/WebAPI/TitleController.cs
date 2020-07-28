using Microsoft.AspNet.Identity;
using Models.TitleCRUD;
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
    [RoutePrefix("api/Title")]
    public class TitleController : ApiController
    {
        private bool SetStarState(int titleId, bool newState)
        {
            //Create the Service
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TitleService(userId);

            //Get the Title
            var detail = service.GetTitleById(titleId);

            //Creat the TitleEdit model instance with the new state
            var updatedTitle = new TitleEdit
            {
                TitleId = detail.TitleId,
                TitleName = detail.TitleName,
                //IsStarred = newState,
                DateEstablished = detail.DateEstablished,
                WrestlerId = detail.WrestlerId
            };

            //Return a value indicating whether the update succeeded or not
            return service.UpdateTitle(updatedTitle);
        }

        [Route("{id}/Star")]
        [HttpPut]
        public bool ToggleStarOn(int id) => SetStarState(id, true);

        [Route("{id}/Star")]
        [HttpDelete]
        public bool ToggleStarOff(int id) => SetStarState(id, false);
    }
}
