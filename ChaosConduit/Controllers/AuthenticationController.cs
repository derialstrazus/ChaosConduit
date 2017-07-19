using ChaosConduit.Attributes;
using ChaosConduit.DataAccess;
using ChaosConduit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChaosConduit.Controllers
{
    public class AuthenticationController : ApiController
    {
        SingletonDB s1 = SingletonDB.Instance;

        //TODO: Need a route that allows an existing user to login
        //as opposed to currently where users always create a new account
        //this will useful when we integrate Google Sign-On
        [HttpGet, Route("api/authentication")]
        public IHttpActionResult Login()
        {
            throw new NotImplementedException();
        }

        [HttpPost, Route("api/authentication")]
        public IHttpActionResult Create([FromBody]string name)
        {
            try
            {
                Guid g = Guid.NewGuid();
                s1.Users.Add(new User { ID = g, Name = name, LastOnline = DateTime.Now });
                var returnThis = s1.Users.First(x => x.ID == g);
                return Ok(returnThis);
            }
            catch (Exception ex)
            {
                s1.Users.RemoveAll(x => x.Name == name);
                return InternalServerError(ex);
            }
        }

        [HttpGet, Route("api/authentication"), RequireLogin]
        public IHttpActionResult Check()
        {
            return Ok();
        }
    }
}
