<<<<<<< HEAD
﻿using OurTunes.Data;
=======

﻿using Microsoft.AspNet.Identity;
using OurTunes.Data;
using OurTunes.Model;
>>>>>>> 937c3105502f023e1a4c29b50e8126572465cf1a
using OurTunes.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BlueBadgeProject.Controllers
{
    [Authorize]
    public class PlaylistController : ApiController
    {
<<<<<<< HEAD

=======
        //GET ALL
        public IHttpActionResult Get()
        {
            PlaylistServices playlistServices = new PlaylistServices();
            var playlists = playlistServices.GetPlaylists();
            return Ok(playlists);
        }

        //POST
        public IHttpActionResult Post(PlaylistCreate playlist)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePlaylistService();

            if (!service.CreatePlaylist(playlist))
                return InternalServerError();

            return Ok();

        }

        private PlaylistServices CreatePlaylistService()
        {
            var playlistServices = new PlaylistServices();
            return playlistServices;
        }

        //PUT
        public IHttpActionResult Put(PlaylistEdit playlist)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePlaylistService();

            if (!service.UpdatePlaylist(playlist))
                return InternalServerError();

            return Ok();
        }
>>>>>>> 937c3105502f023e1a4c29b50e8126572465cf1a
    }
}

