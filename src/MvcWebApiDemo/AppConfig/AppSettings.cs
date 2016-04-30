using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.AppConfig
{
    public class AppSettings
    {
        public SiteSettings SiteSettings { get; set; } = new SiteSettings();

        public ThemeOptions ThemeOptions { get; set; } = new ThemeOptions();

        public LogSettings LogSettings { get; set; } = new LogSettings();

        public EmailSettings EmailSettings { get; set; } = new EmailSettings();
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

    public class SiteSettings
    {
        public string SiteTitle { get; set; }
        public int MaxListCount { get; set; } = 15;
    }

    public class EmailSettings
    {
        public string Server { get; set; }

        public int Port { get; set; }

        public string Sender { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
