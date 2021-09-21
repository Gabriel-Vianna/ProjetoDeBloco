using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SocialMusic.Site.Models;
using SocialMusic.Site.Models.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using SocialMusic.Site.Models.Users;

namespace SocialMusic.Site.Controllers
{   
    [Authorize]
    public class PostsController : Controller
    {
        public PostsController(IHttpClientFactory httpClientFactory)
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

            if(user == null)
            {
                user = new UsersModel();
            }
            viewModel.User = user;

            viewModel.Posts = posts;

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> PublicPost(string title, string text, IFormFile image)
        {
            var imagePath = "";

            if(image != null)
            {
                imagePath = makeUpload(image);
            };

            var newPost = new
            {
                Title = title,
                Text = text,
                Image = imagePath,
                Author = User.Identity.Name,
                CreatedAt = DateTime.UtcNow
            };

            var postAsJason = JsonConvert.SerializeObject(newPost);

            var content = new StringContent(postAsJason, System.Text.Encoding.UTF8, "application/json");

            await postman.PostAsync("https://localhost:44335/api/posts", content);

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
