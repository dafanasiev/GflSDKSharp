namespace GflSDK
{
    public class ContextInitializationOptions
    {
        static ContextInitializationOptions()
        {
            Default = new ContextInitializationOptions() { EnableLZW = false };
        }
        public static ContextInitializationOptions Default { get; private set; }

        public bool EnableLZW { get; set; }
        public string PluginPath { get; set; }
    }
}