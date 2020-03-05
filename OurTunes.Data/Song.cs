using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurTunes.Data
{
    public class Song
    {
        [Key]
        public int SongId { get; set; }

        [Required]
        public string ArtistName { get; set; }

        [Required]
        public string SongName { get; set; }

        [Required]
        public string AlbumName { get; set; }

        [Required]
        public string SongLength { get; set; }

    }
}
