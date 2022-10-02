using UITests.TestData;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace UITests.Utils
{
    public static class SettingsHelper
    {
        public static Settings GetSettings()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "\\FilesForTests")
                .AddJsonFile("appsettings.json")
                .Build();
            var settings = new Settings();
            config.GetSection("Settings").Bind(settings);
            return settings;
        }
    }
}