namespace SAPexAuthService.Models
{
    public class AppSettingsModel
    {
        public string Secret { get; set; }

        public int RefreshLength { get; set; }

        public int ExpMinute { get; set; }

        public int ExpMonth { get; set; }
    }
}
