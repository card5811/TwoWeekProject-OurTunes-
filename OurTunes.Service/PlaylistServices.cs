using OurTunes.Data;
using OurTunes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurTunes.Service
{
    public class PlaylistServices
    {
        public bool CreatePlaylist(PlaylistCreate model)
        {
            var entity =
                new Playlist()
                {
                    PlaylistId = model.PlaylistId,
                    PlaylistName = model.PlaylistName,
                    OwnerId = model.OwnerId,
                    TotalTimeOfPlaylist = model.TotalTimeOfPlaylist
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Playlists.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

     public IEnumerable<PlaylistEdit> GetPlaylists()
          {
              using (var ctx = new ApplicationDbContext())
              {
                  var query =
                      ctx
                          .Playlists
                          .Where(e => e.PlaylistId == e.PlaylistId)
                          .Select(
                              e =>
                                  new PlaylistEdit
                                  {
                                      PlaylistId = e.PlaylistId,
                                      OwnerId = e.OwnerId,
                                      PlaylistName = e.PlaylistName,
                                      TotalTimeOfPlaylist = e.TotalTimeOfPlaylist
                                  }
                          );

                  return query.ToArray();
              }
          }

        public PlaylistEdit GetPlaylistByName(string name)
        {
            PlaylistSongServices theSong = new PlaylistSongServices();

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Playlists
                        .Single(e => e.PlaylistName == name);
                return
                    new PlaylistEdit
                    {
                        PlaylistName = entity.PlaylistName,
                        TotalTimeOfPlaylist = entity.TotalTimeOfPlaylist,
                    };

            }
        }

        public bool UpdatePlaylist(PlaylistEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Playlists
                    .Single(e => e.PlaylistId == model.PlaylistId);

                entity.PlaylistName = model.PlaylistName;
                entity.TotalTimeOfPlaylist = model.TotalTimeOfPlaylist;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePlaylist(int playlistId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Playlists
                    .Single(e => e.PlaylistId == playlistId);

                ctx.Playlists.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
    //-----------Get/Post/Delete Songs From a Playlist----------------//

    public class PlaylistSongServices
    {
        public bool PostSong(JointModel joint)
        {
            JointPlaylist addSong = new JointPlaylist();
            addSong.PlaylistId = joint.PlaylistId;
            addSong.SongId = joint.SongId;

            using (var context = new ApplicationDbContext())
            {
                context.JointPlaylists.Add(addSong);
                return context.SaveChanges()==1;
            };
            
        }

        public IEnumerable<JointSongList> GetPlaylistSongs(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .JointPlaylists
                        .Where(e => e.PlaylistId == id)
                        .Select(
                            e =>
                                new JointSongList
                                {
                                    SongName = e.Song.SongName,
                                    SongLength = e.Song.SongLength,
                                    AlbumName = e.Song.AlbumName,
                                    ArtistName = e.Song.ArtistName,
                                }
                        ) ;

                return query.ToArray();
            }
        }

        public bool DeleteSongFromPlaylist(int songId, int playlistId)
        {
            using (var context = new ApplicationDbContext())
            {
                var deleteSong = context.JointPlaylists.Single(e => e.PlaylistId == playlistId && e.SongId == songId);

                context.JointPlaylists.Remove(deleteSong);

                return context.SaveChanges() == 1;
            }
        }
    }
}

