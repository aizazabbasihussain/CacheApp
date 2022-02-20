using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CacheApp.Model
{
    public class ErrorDetailModel
    { 
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
