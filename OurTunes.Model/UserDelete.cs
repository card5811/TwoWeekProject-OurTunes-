using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurTunes.Model
{
    public class UserDelete
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public string Email { get; set; }
    }
}
