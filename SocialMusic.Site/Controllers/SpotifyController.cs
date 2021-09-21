using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using SpotifyAPI.Web;


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
            var loginRequest = new LoginRequest(
                  new Uri("https://localhost:44382/Spotify"),
                  "da0d88886265462db793916f1691f55e",
                  LoginRequest.ResponseType.Code
                 )
            {
                Scope = new[] { Scopes.PlaylistReadPrivate, Scopes.PlaylistReadCollaborative }
            };
            var uri = loginRequest.ToUri();
            return View();
        }

        public async Task GetCallback([FromQuery]string access_token)
        {
            Uri myUri = new Uri("https://localhost:44382/Spotify", UriKind.Absolute);
            var response = await new OAuthClient().RequestToken(
              new AuthorizationCodeTokenRequest("da0d88886265462db793916f1691f55e", "ead1f20269f24b9dafa9f71ad8a44593", access_token, myUri)
            );

            var spotify = new SpotifyClient(response.AccessToken);
        }
    }
}
