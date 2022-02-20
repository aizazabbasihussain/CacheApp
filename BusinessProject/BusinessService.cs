using Infrastructure;
using Infrastructure.Cache;
using System.Threading.Tasks;

namespace IdentityProject
{
    public class BusinessService : ICacheable 
    { 
        public async Task RefreshCache(string cacheIdentifier)
        {
            await BusinessCacheProvider.RefreshIdentityCache(cacheIdentifier);
        } 
    }
}