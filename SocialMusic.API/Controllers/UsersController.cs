using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMusic.API.Requests;
using SocialMusic.API.Responses;
using SocialMusic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMusic.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public Application App { get; }
        public UsersController(Application app)
        {
            App = app;
        }
        [HttpPost]
        public ActionResult Post([FromBody] UsersRequest usersRequest)
        {
            App.CreateOrUpdateUser(usersRequest.Name, usersRequest.Email,usersRequest.Age, usersRequest.Gender, usersRequest.Country, usersRequest.State, usersRequest.City, usersRequest.FavoriteArtist, usersRequest.FavoriteSong, usersRequest.MusicStyle, usersRequest.About, usersRequest.ProfileImage);

            return Ok();
        }

        [HttpGet]
        public ActionResult Get([FromQuery] string email)
        {
            var user = App.getUser(email);
            return Ok(user);
        }
    }
}
