﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurTunes.Model
{
    public class PlaylistDelete
    {
        public int PlaylistId { get; set; }
        public string PlaylistName { get; set; }
        public int UserId { get; set; }
        public int OwnerId { get; set; }
    }
}