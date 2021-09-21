using Microsoft.AspNetCore.Mvc;
using SocialMusic.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using SocialMusic.Site.Models.Posts;
using Newtonsoft.Json;
using SocialMusic.Site.Models.Users;

namespace SocialMusic.Site.Controllers
{
    public class ImagesController : Controller
    {
        public ImagesController(IHttpClientFactory httpClientFactory)
        {
            postman = httpClientFactory.CreateClient();
        }

        HttpClient postman;
        public async Task<IActionResult> Index()
        {
            var viewModel = new IndexViewModel();

            var resultPosts = await postman.GetAsync("https://localhost:44335/api/posts");

            var contentPosts = await resultPosts.Content.ReadAsStringAsync();

            List<PostModel> posts = JsonConvert.DeserializeObject<List<PostModel>>(contentPosts);

            var email = User.Identity.Name;

            var result = await postman.GetAsync("https://localhost:44335/api/users?email=" + email);

            var content = await result.Content.ReadAsStringAsync();

            UsersModel user = JsonConvert.DeserializeObject<UsersModel>(content);

            if (user == null)
            {
                user = new UsersModel();
            }
            viewModel.User = user;

            viewModel.Posts = posts;

            return View(viewModel);
        }
    }

}
