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

            UserServices ourUser = new UserServices();
            ourUser.CreateUser(user);
            return Ok();
        }
       

       public IHttpActionResult Get(string userName)
        {
            UserServices userService = new UserServices();
            var user = userService.GetUserByUserName(userName);
            return Ok(user);
        } 

       public IHttpActionResult Put(UserEdit userName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            UserServices userService = new UserServices();
            var user = userService.UpdateUser(userName);
            return Ok();
        } 

        public IHttpActionResult Delete(string userName)
        {
            UserServices ourUser = new UserServices();
            ourUser.DeleteUser(userName);
            return Ok();
        }
    }
}

