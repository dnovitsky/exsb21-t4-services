using System;

namespace SAPexAuthService.Models
{
    public class AppSettingsModel
    {
        public string Secret { get; set; }

        public int ExpDate { get; set; }

        public int ExpMonth { get; set; }
    }
}
