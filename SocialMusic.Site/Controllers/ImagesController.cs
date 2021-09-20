using Microsoft.AspNetCore.Mvc;
using SocialMusic.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using SocialMusic.Site.Models.Posts;
using Newtonsoft.Json;

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

            var result = await postman.GetAsync("https://localhost:44335/api/posts");

            var content = await result.Content.ReadAsStringAsync();

            List<PostModel> posts = JsonConvert.DeserializeObject<List<PostModel>>(content);

            viewModel.Posts = posts;

            return View(viewModel);
        }
    }
}
