using OurTunes.Data;
using OurTunes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurTunes.Service
{
    public class UserServices
    {
        public bool CreateUser(UserCreate model)
        {
            var entity =
                new User()
                {
                    FName = model.FName,
                    LName = model.LName,
                    UserName = model.UserName,
                    Email = model.Email

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Profiles.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public UserCreate GetUserByUserName(string userName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Profiles
                        .Single(e => e.UserName == userName);
                return
                    new UserCreate
                    {
                       
                        UserName = entity.UserName,
                        Email = entity.Email,
                        FName = entity.FName,
                        LName = entity.LName

                    };
            }
        }

        public bool UpdateUser(UserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Profiles
                    .Single(e => e.OwnerId == model.OwnerId);


                entity.UserName = model.UserName;
                entity.FName = model.FName;
                entity.LName = model.LName;
                entity.Email = model.Email;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteUser(string userName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Profiles
                    .Single(e => e.UserName == userName);

                ctx.Profiles.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

