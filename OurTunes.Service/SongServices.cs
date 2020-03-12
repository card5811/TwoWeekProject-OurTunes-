using OurTunes.Data;
using OurTunes.Model;
using OurTunes.Model.SongRate;
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
                    ArtistName = model.ArtistName,
                    SongGenre = model.SongGenre
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Songs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SongEdit> GetAllSongs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Songs
                        .Where(e => e.SongId == e.SongId)
                        .Select(
                            e =>
                                new SongEdit
                                {
                                    SongId = e.SongId,
                                    ArtistName = e.ArtistName,
                                    AlbumName = e.AlbumName,
                                    SongLength = e.SongLength,
                                    SongName = e.SongName,
                                    SongGenre = e.SongGenre,
                                    AverageRate = e.RateAdverage
                                }
                        );

                return query.ToArray();
            }
        }

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
                        SongLength = entity.SongLength,
                        SongGenre = entity.SongGenre,
                        AverageRate = entity.RateAdverage
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
                        SongLength = entity.SongLength,
                        SongGenre = entity.SongGenre,
                        AverageRate = entity.RateAdverage
                    };
            }
        }

        public SongEdit GetSongByArtistName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Songs
                        .Single(e => e.ArtistName == name);
                return
                    new SongEdit
                    {
                        SongId = entity.SongId,
                        SongName = entity.SongName,
                        AlbumName = entity.AlbumName,
                        ArtistName = entity.ArtistName,
                        SongLength = entity.SongLength,
                        SongGenre = entity.SongGenre,
                        AverageRate = entity.RateAdverage
                    };
            }
        }

        public SongEdit GetSongByGenre(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Songs
                    .Single(e => e.SongGenre == name);
                return
                    new SongEdit
                    {
                        SongId = entity.SongId,
                        SongName = entity.SongName,
                        AlbumName = entity.AlbumName,
                        ArtistName = entity.ArtistName,
                        SongLength = entity.SongLength,
                        SongGenre = entity.SongGenre,
                        AverageRate = entity.RateAdverage
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
                entity.SongGenre = model.SongGenre;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSong(int songId)
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
        //---------------Song Rating-------------//


        public bool AverageRating(int songId)
        {
            double avgRate = 0;
            using(var context = new ApplicationDbContext())
            {
                var songRateList = context.SongRatings.Where(j => j.SongId == songId).ToList();

                foreach(SongRating rate in songRateList)
                {
                    avgRate += rate.SongRate;
                }
                avgRate = avgRate / songRateList.Count();

                var theSong = context.Songs.Single(j => j.SongId == songId);
                theSong.RateAverage = avgRate.ToString().Substring(0, 3)   ;
                return context.SaveChanges() == 1;
            }
        }
    }
}
