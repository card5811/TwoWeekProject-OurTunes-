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
        [Display(Name = "Song ID")]
        public int SongId { get; set; }

        [Required]
        [Display(Name = "Artist Name")]
        public string ArtistName { get; set; }

        [Required]
        [Display(Name = "Song Name")]
        public string SongName { get; set; }

        [Required]
        [Display(Name = "Album Name")]
        public string AlbumName { get; set; }

        [Required]
        [Display(Name = "Song Length")]
        public string SongLength { get; set; }

        [Required]
        [Display(Name = "Song Genre")]
        public string SongGenre { get; set; }

        public string RateAverage { get; set; }
    }
}