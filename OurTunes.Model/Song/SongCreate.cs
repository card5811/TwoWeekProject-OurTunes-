using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurTunes.Model
{
    public class SongCreate
    {
        public int SongId { get; set; }

        [MinLength(1, ErrorMessage ="Please enter at least one character.")]
        [MaxLength(30, ErrorMessage ="Song name too long, please shorten before continuing.")]
        public string SongName { get; set; }

        [MinLength(1, ErrorMessage = "Please enter at least one character.")]
        [MaxLength(30, ErrorMessage = "Song name too long, please shorten before continuing.")]
        public string AlbumName { get; set; }

        [MinLength(1, ErrorMessage = "Please enter the song length in the format of: 'X:XX'.")]
        public string SongLength { get; set; }

        public string ArtistName { get; set; }

        public string SongGenre { get; set; }
    }
}
