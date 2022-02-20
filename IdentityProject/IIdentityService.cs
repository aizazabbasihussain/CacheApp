using Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityProject
{
    public interface IIdentityService
    {
        Task RefreshUserNames(string cacheIdentifier);
    }
}
