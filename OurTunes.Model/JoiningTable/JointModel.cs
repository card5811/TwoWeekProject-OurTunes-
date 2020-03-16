using OurTunes.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurTunes.Model
{
    public class JointModel
    {
        public int SongId { get; set; }

        public int PlaylistId { get; set; }
    }
}