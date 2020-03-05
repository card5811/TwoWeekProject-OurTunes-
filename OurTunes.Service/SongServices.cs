using OurTunes.Data;
using OurTunes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurTunes.Service
{
    public class SongServices
    {
        public bool CreateSong(SongCreate model)
        {
            var entity =
                new Song()
                {
                    SongId = model.SongId,
                    SongName = model.SongName,
                    AlbumName = model.AlbumName,
                    SongLength = model.SongLength,
                    ArtistName = model.ArtistName
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Songs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

       /* public IEnumerable<NoteListItem> GetSongs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Songs
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

        public SongEdit GetSongById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Songs
                        .Single(e => e.SongId == id);
                return
                    new SongEdit
                    {
                        SongId = entity.SongId,
                        SongName = entity.SongName,
                        AlbumName = entity.AlbumName,
                        ArtistName = entity.ArtistName,
                        SongLength = entity.SongLength
                    };
            }
        }

        public SongEdit GetSongByTitle(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Songs
                        .Single(e => e.SongName == name);
                return
                    new SongEdit
                    {
                        SongId = entity.SongId,
                        SongName = entity.SongName,
                        AlbumName = entity.AlbumName,
                        ArtistName = entity.ArtistName,
                        SongLength = entity.SongLength
                    };
            }
        }

        public bool UpdateSong(SongEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Songs
                    .Single(e => e.SongId == model.SongId);

                entity.SongName = model.SongName;
                entity.ArtistName = model.ArtistName;
                entity.AlbumName = model.AlbumName;
                entity.SongLength = model.SongLength;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNote(int songId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Songs
                    .Single(e => e.SongId == songId);

                ctx.Songs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
