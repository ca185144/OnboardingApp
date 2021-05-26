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
    public class UserController : Controller
    {
        private const string url = "https://jsonplaceholder.typicode.com/users";
        readonly HttpClient client = new HttpClient();

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            HttpResponseMessage response = await client.GetAsync(new Uri(url));
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IEnumerable<User>>();

            }
            return null;
        }
        
    }
}