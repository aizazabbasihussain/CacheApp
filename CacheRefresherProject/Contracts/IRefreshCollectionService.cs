using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CacheRefresherProject.Contracts
{ 
    public interface IRefreshCollectionService
    {
        Task RefreshCaheCollection(string key);
    }
}
