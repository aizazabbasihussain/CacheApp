using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CacheRefresherProject.Util
{
    public static class CacheIdentifierMapper
    {
        private static readonly IDictionary<string, string> _cacheIdentifierMappingList = new Dictionary<string, string>(new[]
        {
           new KeyValuePair<string,string>(CacheIdentifier.UserName, "IdentityProject"),
           new KeyValuePair<string,string>(CacheIdentifier.BusinessIdentifiers, "BusinessProject"),
           new KeyValuePair<string,string>(CacheIdentifier.RoleNames, "RoleProject")
        });   
        public static string GetTargetProject(string key)
        {
            string value = string.Empty;
            bool containsKey = _cacheIdentifierMappingList.TryGetValue(key.ToUpper(), out value);
            if (containsKey)
                return value;
            else
                throw new Exception("In Valid identifier and Porject mapping");
        }
    }
}
