using CacheRefresherProject.Contracts;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CacheApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[action]")]
    public class CacheManagerController : ControllerBase
    {
        private ICacheRefresherService _cacheRefresherService;

        public CacheManagerController(ICacheRefresherService cacheRefresherService)
        {
            _cacheRefresherService = cacheRefresherService;
        } 

        [HttpPost]
        public async Task<IActionResult> RefreshCache(List<string> request)
        {
            await _cacheRefresherService.RefreshCache(request); 
            return Ok();
        }
    }
}
