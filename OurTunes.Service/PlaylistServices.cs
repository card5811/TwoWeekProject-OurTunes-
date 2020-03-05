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
                    UserId = model.UserId,
                    TotalTimeOfPlaylist = model.TotalTimeOfPlaylist
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Playlists.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

      /*  public IEnumerable<NoteListItem> GetNotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Notes
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new NoteListItem
                                {
                                    NoteId = e.NoteId,
                                    Title = e.Title,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        } */

        public PlaylistEdit GetPlaylistByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Playlists
                        .Single(e => e.PlaylistName == name)
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
                    PlaylistId = model.PlaylistId,
                    PlaylistName = model.PlaylistName,
                    UserId = model.UserId,
                    TotalTimeOfPlaylist = model.TotalTimeOfPlaylist
                ctx.Playlists.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
}
}
