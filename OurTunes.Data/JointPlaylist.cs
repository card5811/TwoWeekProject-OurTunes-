using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurTunes.Data
{
    public class JointPlaylist
    {
        [Key]
        public int JointId { get; set; }

        [ForeignKey(nameof(Song))]
        public int SongId { get; set; }
        public virtual Song Song { get; set; }

        [ForeignKey(nameof(Playlist))]
        public int PlaylistId { get; set; }
        public virtual Playlist Playlist { get; set; }
    }
}
