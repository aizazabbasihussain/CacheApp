using CacheRefresherProject.Contracts;
using CacheRefresherProject.Util;
using Domain;
using Infrastructure.Cache;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CacheRefresherProject
{
    public class RefreshCollectionService : IRefreshCollectionService
    {
        private static readonly SemaphoreSlim CollectionSemaphore = new SemaphoreSlim(1, 1);

        public async Task RefreshCaheCollection(string key)
        {
            try
            {
                await CollectionSemaphore.WaitAsync();

                Assembly assembly = ComponentLoader.LoadAssembly(key);
                await ComponentLoader.LoadDataFromAssembly(assembly, key);
                //Loaded the refreshed data from cacheable component => pass dummy data to update collection
                UpdateCollection(key, new List<string>() { "dummyCacheData1" , "dummyCacheData2" });
            }
            catch (Exception)
            {
                string errorMessage = string.Format("Failed to refresh the cached collection {0}", key);
                throw new Exception(errorMessage);
            }
            finally
            {
                CollectionSemaphore.Release();
            }
        }
        public void UpdateCollection<T>(string key, List<T> data) where T : class
        {
            Type settingsType = typeof(CacheCollection);
            foreach (PropertyInfo propertyInformation in settingsType.GetProperties(BindingFlags.Public |
                                              BindingFlags.Static))
            {
                if (propertyInformation.Name.Equals(key, StringComparison.OrdinalIgnoreCase))
                {
                    if (propertyInformation.CanWrite)
                    {
                        //If type is List<string> 
                        if (propertyInformation.PropertyType.IsGenericType && propertyInformation.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                        {
                            propertyInformation.SetValue(this, Convert.ChangeType(data, propertyInformation.PropertyType, CultureInfo.CurrentCulture), null);
                        }
                        //If type is disctionary
                        else if (propertyInformation.PropertyType.IsGenericType && propertyInformation.PropertyType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
                        {
                            var dict = new Dictionary<string, string>();
                            foreach (var item in data)
                                dict.Add(item.ToString(), item.ToString());
                            propertyInformation.SetValue(this, Convert.ChangeType(dict, propertyInformation.PropertyType, CultureInfo.CurrentCulture), null);
                        }
                    }
                    break;
                }
            }
        }  
    }
}
