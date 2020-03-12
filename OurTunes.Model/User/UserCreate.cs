﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurTunes.Model
{
    public class UserCreate
    {
        public int OwnerId { get; set; }

        public string ProfileId { get; set; }

        public string UserName { get; set; }

        [MinLength(2, ErrorMessage = "Please enter at least two characters for this field.")]
        [MaxLength(20, ErrorMessage = "There's no way your first name is that long dude.")]
        public string FName { get; set; }

        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "That really sucks your name is this long... Get a shorter last name.")]
        public string LName { get; set; }

        public string Email { get; set; }
    }
}
