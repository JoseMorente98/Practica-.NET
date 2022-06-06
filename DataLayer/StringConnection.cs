using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class StringConnection
    {
        private readonly static StringConnection instance = new StringConnection();

        public static StringConnection Instance { get { return instance; } }

        public string connectionString()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();

            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = builder.Build();
            return root.GetConnectionString("database"); 
        }
    }
}
