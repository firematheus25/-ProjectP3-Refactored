using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectP3.Services
{
    public class MyClient
    {        
        public string BaseAddress { get; set; } = "http://www.P3.somee.com";
        // string BaseAddress { get; set; } = "http://www.P3.somee.com";
        public MyClient()
        {

        }

        public Uri BuilderUri(string Uri)
        {
            return new Uri($"{BaseAddress}/{Uri}");
        }

        public Uri BuilderUri(string Uri, string Id)
        {
            return new Uri($"{BaseAddress}/{Uri}/{Id}");
        }
    }
}
