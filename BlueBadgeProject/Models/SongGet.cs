using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlueBadgeProject.Models
{
    public class SongGet
    {
        [Key]
        public int SongId { get; set; }

        public string ArtistName { get; set; }

        public string SongName { get; set; }

        public string AlbumName { get; set; }

        public string SongLength { get; set; }

        public string SongGenre { get; set; }
    }

    public class SongGetContext : DbContext
    {
        public DbSet<SongGet> SongModel { get; set; }
    }
}