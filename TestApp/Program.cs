using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GflSDK;


namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GflSDK.Context.Initialize(ContextInitializationOptions.Default);
            var version = GflSDK.Context.Version;
            var allFormats = GflSDK.Context.SupportedFormats;
            GflSDK.Context.DeInitialize();
        }
    }
}
