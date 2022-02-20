using Domain;
using Infrastructure;
using Infrastructure.Cache;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityProject
{
    public class IdentityService : ICacheable 
    { 
        public async Task RefreshCache(string cacheIdentifier)
        {
            await IdentityCacheProvider.RefreshIdentityCache(cacheIdentifier);
        } 
    }
}