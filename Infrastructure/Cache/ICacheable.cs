using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Cache
{
    public interface ICacheable
    {
        Task RefreshCache(string key);
    }
}
