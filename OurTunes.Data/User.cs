﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurTunes.Data
{
    public class User
    {
        [Key]
        Guid UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string FName { get; set; }

        [Required]
        public string LName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}