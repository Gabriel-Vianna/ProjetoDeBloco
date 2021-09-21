using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SocialMusic.Site.Models.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SocialMusic.Site.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(IHttpClientFactory httpClientFactory)
        {
            postman = httpClientFactory.CreateClient();
        }

        HttpClient postman;
        public async Task<IActionResult> Index()
        {
            var usersViewModel = new UsersViewModel();

            var email = User.Identity.Name;

            var result = await postman.GetAsync("https://localhost:44335/api/users?email="+email);

            var content = await result.Content.ReadAsStringAsync();

            UsersModel user = JsonConvert.DeserializeObject<UsersModel>(content);

            if(user == null)
            {
                user = new UsersModel();
            }

            usersViewModel.User = user;

            return View(usersViewModel);
        }

        public async Task<IActionResult> EditInformation(string name, string age, string gender, string country, string state, string city, string favoriteArtist, string favoriteSong, string musicStyle, string about, IFormFile profileImage)
        {
            var imagePath = "";

            if (profileImage != null)
            {
                imagePath = makeUpload(profileImage);
            };

            var newAccountInformation = new
            {
                Name = name,
                Email = User.Identity.Name,
                Age = age,
                Gender = gender,
                Country = country,
                State = state,
                City = city,
                FavoriteArtist = favoriteArtist,
                FavoriteSong = favoriteSong,
                MusicStyle = musicStyle,
                About = about,
                ProfileImage = imagePath
            };

            var postAsJason = JsonConvert.SerializeObject(newAccountInformation);

            var content = new StringContent(postAsJason, System.Text.Encoding.UTF8, "application/json");

            await postman.PostAsync("https://localhost:44335/api/users", content);

            return RedirectToAction("Index");
        }

        private string makeUpload(IFormFile image)
        {
            string azureBlobStorageConnection =
                "DefaultEndpointsProtocol=https;AccountName=infnetarmazenamento;AccountKey=Ch9317EiDDBnzv0vlx3bpDGmi2hop3U6d2ymI+W6eXl0QfYz4Ug8w7B+gTL4PTHD/sUWXqQnozPYflfBRZ8OYQ==;EndpointSuffix=core.windows.net";

            BlobServiceClient blobServiceClient = new BlobServiceClient(azureBlobStorageConnection);

            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("images");

            string localPath = "./data/";
            string fileName = $"{Guid.NewGuid()}.{image.FileName.Split('.')[1]}";
            string localFilePath = Path.Combine(localPath, image.FileName);

            if (!Directory.Exists(localPath))
                Directory.CreateDirectory(localPath);

            BlobClient client = containerClient.GetBlobClient(fileName);

            client.Upload(localFilePath);

            fileName = "https://infnetarmazenamento.blob.core.windows.net/images/" + fileName;

            return fileName;
        }
    }
}
