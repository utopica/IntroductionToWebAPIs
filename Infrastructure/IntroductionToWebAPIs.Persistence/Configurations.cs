using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToWebAPIs.Persistence
{
    public static class Configurations
    {
        public static string GetStringFromJson(string key)
        {
            ConfigurationManager configurationManager = new();

            string path = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}\\Infrastructure\\IntroductionToWebAPIs.Persistence";
            
            configurationManager.SetBasePath(path);

            configurationManager.AddJsonFile("PrivateInformations.json");

            return configurationManager.GetSection(key).Value;
        
        }
    }
}
