namespace th_nhom01.Configurations
{
    public class MyAppSetting
    {
        public long MaxFileSize { get; set; }
        public List<string> BannedIPs { get; set; } = new List<string>();
    }
}
