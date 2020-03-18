using Microsoft.AspNet.Identity;
using OurTunes.Service;
using OurTunes.Model;
using OurTunes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BlueBadgeProject.Controllers
{
    [Authorize]
    public class SongController : ApiController
    {
        public IHttpActionResult Get()
        {
            SongServices songService = CreateSongService();
            var songs = songService.GetAllSongs();
            return Ok(songs);
        }

        public IHttpActionResult Post(SongCreate song)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSongService();

            if (!service.CreateSong(song))
                return InternalServerError();

            return Ok();
        }

        private SongServices CreateSongService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var songServices = new SongServices();
            return songServices;
        }

        public IHttpActionResult GetSongByName(string SongName)
        {
            SongServices songServices = new SongServices();
            var song = songServices.GetSongByTitle(SongName);
            return Ok(song);
        }

        public IHttpActionResult Get(int SongId)
        {
            SongServices songServices = new SongServices();
            var song = songServices.GetSongById(SongId);
            return Ok(song);
        }

        public IHttpActionResult GetArtist(string ArtistName)
        {
            SongServices songServices = new SongServices();
            var song = songServices.GetSongByArtistName(ArtistName);
            return Ok(song);
        }

        public IHttpActionResult GetByGenre(string SongGenre)
        {
            SongServices songServices = new SongServices();
            var song = songServices.GetSongByGenre(SongGenre);
            return Ok(song);
        }


        public IHttpActionResult Put(SongEdit song)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSongService();

            if (!service.UpdateSong(song))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateSongService();

            if (!service.DeleteSong(id))
                return InternalServerError();

            return Ok();
        }
        //-------------Rating-------------//

    }
}