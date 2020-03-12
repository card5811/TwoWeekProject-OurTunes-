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
                context.SaveChanges();
                var id = context.Playlists.Single(e => e.PlaylistId == joint.PlaylistId);
                id.TotalTimeOfPlaylist = GetPlaylistTime(GetPlaylistSongs(joint.PlaylistId));
                return context.SaveChanges() == 1;
            };
        }

        public string GetPlaylistTime(IEnumerable<JointSongList> playlist)
        {
            List<int> hourArray = new List<int>();
            List<int> minutesArray = new List<int>();
            List<int> secondsArray = new List<int>();
            double totalHours = 0;
            double totalMinutes = 0;
            double totalSeconds = 0;
            double secondsToMinutes;
            double minutesToHours;
            double remainderSeconds;
            double remainderMinutes;
            string total = "";

            foreach (var song in playlist)
            {

                string[] splitString = song.SongLength.Split(':');
                var hours = Convert.ToInt32(splitString[0]);
                var minutes = Convert.ToInt32(splitString[1]);
                var seconds = Convert.ToInt32(splitString[2]);
                secondsArray.Add(seconds);
                hourArray.Add(hours);
                minutesArray.Add(minutes);

                if (totalHours > 60 || totalMinutes > 60 || totalSeconds > 60)
                {
                    totalSeconds = secondsArray.Sum();
                    secondsToMinutes = Convert.ToInt32(Math.Floor(totalSeconds / 60));
                    remainderSeconds = totalSeconds % 60;
                    totalMinutes = minutesArray.Sum() + secondsToMinutes;
                    minutesToHours = Convert.ToInt32(Math.Floor(totalMinutes / 60));
                    remainderMinutes = totalMinutes % 60;
                    totalHours = hourArray.Sum() + minutesToHours;
                    total = $"{totalHours}:{remainderMinutes}:{remainderSeconds}";
                }
            }

            totalHours = hourArray.Sum();
            totalMinutes = minutesArray.Sum();
            totalSeconds = secondsArray.Sum();

            if (totalHours < 10 || totalMinutes < 10 || totalSeconds < 10)
            {
                //hours
                if (totalHours < 10 && totalMinutes > 10 && totalSeconds > 10)
                {
                    total = $"0{totalHours}:{totalMinutes}:{totalSeconds}";
                }

                if (totalHours < 10 && totalMinutes < 10 && totalSeconds > 10)
                {
                    total = $"0{totalHours}:0{totalMinutes}:{totalSeconds}";
                }

                if (totalHours < 10 && totalMinutes > 10 && totalSeconds < 10)
                {
                    total = $"0{totalHours}:{totalMinutes}:0{totalSeconds}";
                }

                if (totalHours < 10 && totalMinutes < 10 && totalSeconds < 10)
                {
                    total = $"0{totalHours}:0{totalMinutes}:0{totalSeconds}";
                }

                //minutes
                if (totalHours > 10 && totalMinutes < 10 && totalSeconds > 10)
                {
                    total = $"{totalHours}:0{totalMinutes}:{totalSeconds}";
                }

                if (totalHours > 10 && totalMinutes < 10 && totalSeconds < 10)
                {
                    total = $"{totalHours}:0{totalMinutes}:0{totalSeconds}";
                }

                //seconds
                if (totalHours > 10 && totalMinutes > 10 && totalSeconds < 10)
                {
                    total = $"{totalHours}:{totalMinutes}:0{totalSeconds}";
                }
            }

            else
                total = $"{totalHours}:{totalMinutes}:{totalSeconds}";

            return total;
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
                        );

                return query.ToArray();
            }
        }

        public bool DeleteSongFromPlaylist(int songId, int playlistId)
        {
            using (var context = new ApplicationDbContext())
            {

                var deleteSong = context.JointPlaylists.First(e => e.PlaylistId == playlistId && e.SongId == songId);
                context.JointPlaylists.Remove(deleteSong);
                context.SaveChanges();
                var time = context.Playlists.Single(e => e.PlaylistId == playlistId);
                time.TotalTimeOfPlaylist = GetPlaylistTime(GetPlaylistSongs(playlistId));
                return context.SaveChanges() == 1;
            }
        }
    }
}