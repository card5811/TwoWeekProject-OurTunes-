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
        private readonly Guid _userId;

        public UserServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateUser(UserCreate model)
        {
            var entity =
                new User()
                {
                    UserId = _userId,
                    FName = model.FName,
                    LName = model.LName,
                    UserName = model.UserName
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.User.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public UserCreate GetUserByUserName(string userName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .User
                        .Single(e => e.UserName == userName && e.UserId == _userId);
                return
                    new UserCreate
                    {
                        UserId = entity.UserId,
                        UserName = entity.UserName,
                        Email = entity.Email,
                        FName = entity.FName,
                        LName = entity.LName

                    };
            }
        }

        public bool UserDelete(string userName)
        {
            throw new NotImplementedException();
        }

        /*  public bool UpdateNote(NoteEdit model)
          {
              using (var ctx = new ApplicationDbContext())
              {
                  var entity =
                      ctx
                      .Notes
                      .Single(e => e.NoteId == model.NoteId && e.OwnerId == _userId);

                  entity.Title = model.Title;
                  entity.Content = model.Content;
                  entity.ModifiedUtc = DateTimeOffset.Now;

                  return ctx.SaveChanges() == 1;
              }
          } */

        public bool DeleteUser(string userName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .User
                    .Single(e => e.UserName == userName && e.UserId == _userId);

                ctx.User.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

