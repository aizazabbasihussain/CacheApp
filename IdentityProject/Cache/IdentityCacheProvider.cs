using Infrastructure.Cache;
using System;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class IdentityCacheProvider
    { 
        public static async Task RefreshIdentityCache(string key)
        {
            //get data from db and set in to cache
        }     
    }
}
