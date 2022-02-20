using CacheRefresherProject.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CacheRefresherProject.Services
{
    public class CacheRefresherService : ICacheRefresherService
    {
        IRefreshCollectionService _refreshCollectionService;
        public CacheRefresherService(IRefreshCollectionService irefreshCollectionService)
        {
            _refreshCollectionService = irefreshCollectionService;
        }
        public async Task RefreshCache(List<string> identifierList)
        {
            //Validate identifierList
            PerformValidation(identifierList);

            //Loop Over each identifier and call RefreshCaheCollection service
            foreach (var identifier in identifierList)
            {
                await _refreshCollectionService.RefreshCaheCollection(identifier);
            } 
        }
        private void PerformValidation(List<string> identifierList)
        {
            //If there is any duplicate identifier => throw Exception
            var duplicateIdentifiers = identifierList.GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x.Key);
            if (duplicateIdentifiers.Count() > 0)
            {
                string errorMessage = string.Format("{0} {1} being repeated in the list", string.Join(",", duplicateIdentifiers.ToArray()), duplicateIdentifiers.Count() == 1 ? "is" : "are");
                throw new Exception(errorMessage);
            }
        }
    }
}
