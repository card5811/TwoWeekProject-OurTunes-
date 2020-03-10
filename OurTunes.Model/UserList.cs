using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurTunes.Model
{
   public class UserList
    {
        public Guid UserId { get; set; }
        public int OwnerId { get; set; }
        public string UserName { get; set; }
    }
}
