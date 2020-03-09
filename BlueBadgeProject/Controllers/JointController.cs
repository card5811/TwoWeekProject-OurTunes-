using Microsoft.AspNet.Identity;
using OurTunes.Data;
using OurTunes.Model;
using OurTunes.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BlueBadgeProject.Controllers
{
    public class JointController : ApiController
    {
        public IHttpActionResult PostSong(JointModel playlist)
        {
            PlaylistServices make = new PlaylistServices();
            make.PostSong(playlist);

            return Ok();

        }
    }
}