using Infrastructure;
using Infrastructure.Cache;
using System.Threading.Tasks;

namespace IdentityProject
{
    public class RoleService : ICacheable 
    { 
        public async Task RefreshCache(string cacheIdentifier)
        {
            await RoleCacheProvider.RefreshIdentityCache(cacheIdentifier);
        } 
    }
}