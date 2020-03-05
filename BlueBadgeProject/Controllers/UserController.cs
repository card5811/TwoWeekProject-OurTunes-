using Microsoft.AspNet.Identity;
using OurTunes.Model;
using OurTunes.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlueBadgeProject.Controllers
{
    public class UserController : ApiController
    {
        public IHttpActionResult Post(UserCreate user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserService();

            if (!service.CreateUser(user))
                return InternalServerError();

            return Ok();
        }
        private UserServices CreateUserService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var userService = new UserServices(userId);
            return userService;
        }

      /*  public IHttpActionResult Get(Guid id)
        {
            UserServices userService = CreateUserService();
            var user = userService.GetUserById(id);
            return Ok(user);
        } */

      /*  public IHttpActionResult Put(NoteEdit note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateNoteService();

            if (!service.UpdateNote(note))
                return InternalServerError();

            return Ok();
        } */

        public IHttpActionResult Delete(string userName)
        {
            var service = CreateUserService();

            if (!service.UserDelete(userName))
                return InternalServerError();

            return Ok();
        }
    }
}

