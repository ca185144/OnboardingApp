using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;



namespace Backend.Controllers
{
    
    [Route("api/[controller]")]
    public class AlbumController : Controller
    {
        readonly HttpClient client = new HttpClient();
        private const string url = "https://jsonplaceholder.typicode.com/albums";
        [HttpGet]
        public async Task<IEnumerable<Album>> GetAlbums()
        {
            HttpResponseMessage response = await client.GetAsync(new Uri(url));
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IEnumerable<Album>>();

            }
            return null;
        }
        
        [HttpGet("{userId:long}")]
        public async Task<IEnumerable<Album>> getAlbumsByUser(long userId)
        {
            HttpResponseMessage response = await client.GetAsync(new Uri(url + "?userId=" + userId));
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IEnumerable<Album>>();

            }
            return null;
        }
    }
}