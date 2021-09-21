using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SocialMusic.Site.Controllers
{
    public class SpotifyController : Controller
    {
        public SpotifyController(IHttpClientFactory httpClientFactory)
        {
            postman = httpClientFactory.CreateClient();
        }

        HttpClient postman;
        public IActionResult Index()
        {

            return View();
        }
    }
}
