using OurTunes.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurTunes.Model
{
    public class PlaylistEdit
    {

        public int PlaylistId { get; set; }

        public int OwnerId { get; set; }

        [MinLength(1, ErrorMessage = "Gotta name it something.")]
        [MaxLength(30, ErrorMessage = "Make it something shorter please.")]
        public string PlaylistName { get; set; }
        public string TotalTime { get; set; }
    }
}