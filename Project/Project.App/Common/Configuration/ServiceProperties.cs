namespace Project.App.Common.Configuration
{
    public class ServiceProperties
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string FullServiceName => $"{Name} - {Version}";
    }
}