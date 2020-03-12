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
    [Authorize]
    [RoutePrefix("api/Playlist")]
    public class PlaylistController : ApiController
    {

       // private readonly int _
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

        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var services = CreatePlaylistService();

            if (!services.DeletePlaylist(id))
                return InternalServerError();
            return Ok();
        }
        //------------------Post/Get/Delete Songs For Playlist --------------//
        private PlaylistSongServices SongPlaylistService()
        {
            var playlistServices = new PlaylistSongServices();
            return playlistServices;
        }

        [HttpPost]
        [Route("PostSong")]
        public IHttpActionResult PostSong(JointModel playlist)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = SongPlaylistService();

            if (!service.PostSong(playlist))
                return InternalServerError();


            return Ok();

        }
        [HttpGet]
        [Route("GetPlaylistSongs")]
        public IHttpActionResult GetSongsInPlaylist(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = SongPlaylistService();

            var songList = service.GetPlaylistSongs(id);

            return Ok(songList);

        }
        [HttpDelete]
        [Route("DeleteSongFromPlaylist")]
        public IHttpActionResult DeleteSongFromPlaylist(int songId, int playlistId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = SongPlaylistService();

            if (!service.DeleteSongFromPlaylist(songId, playlistId))
                return InternalServerError();

            return Ok();

        }

    }
}
