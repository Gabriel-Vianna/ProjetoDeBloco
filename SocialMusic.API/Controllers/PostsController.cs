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
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        public Application App { get; }
        public PostsController(Application app)
        {
            App = app;
        }
        [HttpPost]
        public ActionResult Post([FromBody] PublicPostRequest postRequest)
        {
            App.PublicPost(postRequest.Title, postRequest.Text, postRequest.Image, postRequest.Author, postRequest.CreatedAt);

            return Ok();
        }


        [HttpGet]
        public ActionResult Get()
        {
            var posts = App.ListPosts();
            return Ok(posts);
        }
    }
}
