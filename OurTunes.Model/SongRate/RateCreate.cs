using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurTunes.Model.SongRate
{
    //May not be the best way to name the file, but it sure dose sound awsome when i say it.
    public class RateCreate
    {
        [Required]
        [Range(0d, 5d)]
        public double MyRating { get; set; }

        public int SongId { get; set; }
    }
}
