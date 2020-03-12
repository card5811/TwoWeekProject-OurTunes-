using IdentityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurTunes.Data
{
    public class Playlist
    {
        [Key]
        public int PlaylistId { get; set; }

        [Required]
        public string PlaylistName { get; set; }


       // [ForeignKey(nameof(User))]
        public int OwnerId { get; set; }
      //  public virtual Profile User { get; set; }
        public int TotalTimeOfPlaylist { get; set; }
        //come back and work with song length 
    }
}
