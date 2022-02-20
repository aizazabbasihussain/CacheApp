using Infrastructure.Cache;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CacheRefresherProject.Util
{
    public class ComponentLoader
    { 
        private static string CacheComponents = "CacheComponents";
        private static string RefreshCache = "RefreshCache";
        public static Assembly LoadAssembly(string key)
        {
            string projectName = CacheIdentifierMapper.GetTargetProject(key);
            string dllPath = string.Format("{0}\\{1}.dll", CacheComponents, projectName);
            FileInfo f = new FileInfo(dllPath);
            Assembly assembly = Assembly.LoadFrom(f.FullName);
            return assembly;
        }
        public static async Task LoadDataFromAssembly(Assembly assembly, string key)
        {
            // Get the type from the assembly
            var iType = typeof(ICacheable);
            var type = AssemblyExtensions.GetLoadableTypes(assembly).Where(p => iType.IsAssignableFrom(p)).FirstOrDefault();

            //Create a new instance of the service and call RefreshCache()
            object o = Activator.CreateInstance(type);
            MethodInfo mth = type.GetMethod(RefreshCache);
            var task = (Task)mth.Invoke(o, new object[] { key });
            await task.ConfigureAwait(false);
        }
    }
}
