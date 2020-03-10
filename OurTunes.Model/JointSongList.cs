using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurTunes.Model
{
    public class JointSongList
    {
        public string SongName { get; set; }
        public string AlbumName { get; set; }
        public string SongLength { get; set; }
        public string ArtistName { get; set; }

    }
}
