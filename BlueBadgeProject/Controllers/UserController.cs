using Microsoft.AspNet.Identity;
using OurTunes.Model;
using OurTunes.Model.User;
using OurTunes.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlueBadgeProject.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {

        public IHttpActionResult Get()
        {
            UserServices userServices = CreateUserService();
            var user = userServices.GetUsers();
            return Ok(user);
        }

        public IHttpActionResult Post(UserCreate user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserService();
            user.ProfileId = User.Identity.GetUserId();
            user.Email = User.Identity.GetUserName();

            if (!service.CreateUser(user))
                return InternalServerError();

            return Ok();
        }

        //post
        private UserServices CreateUserService()
        {
            var userId = User.Identity.GetUserId();
            var userServices = new UserServices(userId);
            return userServices;
        }

        //get
        public IHttpActionResult Get(string userName)
        {
            UserServices userServices = CreateUserService();
            var user = userServices.GetUserByUserName(userName);
            return Ok(user);
        }

        //put
        public IHttpActionResult Put(UserEdit user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserService();

            if (!service.UpdateUser(user))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(UserDelete id)
        {
            var service = CreateUserService();

            if (!service.DeleteUser(id))
                return InternalServerError();

            return Ok();
        }
    }
}

