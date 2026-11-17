namespace MVCIntroductionApp.Settings
{
    // appsettings.json içindeki "SiteSettings" bölümünün karşılığı.
    // Property isimleri JSON anahtarlarıyla birebir eşleşmeli (büyük/küçük harf duyarsız).
    public class SiteSettings
    {
        // Bölüm adı tek yerde tutulur; hem Program.cs'te hem başka yerde kullanılabilir.
        public const string SectionName = "SiteSettings";

        public string SiteName { get; set; } = string.Empty;

        public int MaxItemsPerPage { get; set; }

        // İç içe (nested) bölüm
        public ContactSettings Contact { get; set; } = new();

        // Dizi (array) değerler
        public List<string> Features { get; set; } = new();
    }

    public class ContactSettings
    {
        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
    }
}
