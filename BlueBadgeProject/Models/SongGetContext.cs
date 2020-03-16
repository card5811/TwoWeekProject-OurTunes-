using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlueBadgeProject.Models
{
    public class SongGetContexts : DbContext
    {
        public DbSet<SongGet> SongModel { get; set; }
    }
}