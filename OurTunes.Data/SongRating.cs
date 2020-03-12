using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurTunes.Data
{
    public class SongRating
    {
        [Key]
        public int RateId { get; set; }

        public double SongRate { get; set; }

        [ForeignKey(nameof(Song))]
        public int SongId { get; set; }
        public Song Song { get; set; }

    }
}
