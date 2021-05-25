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
    public class PhotoController : Controller
    {
        private const string url = "https://jsonplaceholder.typicode.com/photos";
        [HttpGet]
        public async Task<IEnumerable<Photo>> GetPhotos()
        {
            HttpClient client = new HttpClient(); 
            HttpResponseMessage response = await client.GetAsync(new Uri(url));
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IEnumerable<Photo>>();

            }
            return null;
        }
        
        [HttpGet("{albumId:long}/all")]
        public async Task<IEnumerable<Photo>> GetPhotosByAlbum(long albumId)
        {
            HttpClient client = new HttpClient(); 
            HttpResponseMessage response = await client.GetAsync(new Uri(url + "?albumId=" + albumId));
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IEnumerable<Photo>>();

            }
            return null;
        }
        
        [HttpGet("{albumId:long}")]
        public async Task<IEnumerable<Photo>> GetFirstPhotoByAlbum(long albumId)
        {
            HttpClient client = new HttpClient(); 
            HttpResponseMessage response = await client.GetAsync(new Uri(url + "?albumId=" + albumId + "&_limit=1"));
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IEnumerable<Photo>>();

            }
            return null;
        }
        
    }
}