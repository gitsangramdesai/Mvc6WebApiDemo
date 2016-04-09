using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.AppConfig
{
    public class AppSettings
    {
        public string SiteTitle { get; set; }
        public int MaxListCount { get; set; } = 15;
        public ThemeOptions ThemeOptions { get; set; } = new ThemeOptions();

        public LogSettings LogSettings { get; set; } = new LogSettings();
    }
    public class ThemeOptions
    {
        public string ThemeName { get; set; } = "Default";
        public string Font { get; set; } = "'Trebuchet MS','Trebuchet','sans serif'";
    }

    public class LogSettings
    {
        public string AppLogPath { get; set; }
    }
}
