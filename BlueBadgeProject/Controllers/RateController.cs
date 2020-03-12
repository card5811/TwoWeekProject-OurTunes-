using OurTunes.Model.SongRate;
using OurTunes.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlueBadgeProject.Controllers
{
    public class RateController : ApiController
    {
        public IHttpActionResult PostRating(SongRateCreate songId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            RateServices service = new RateServices();

            if(!service.RateASong(songId))
            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}
