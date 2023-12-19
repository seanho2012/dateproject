using System.Configuration;


namespace web1.Common
{
    public class ConfigTool
    {
        public static string GetDBConnectionString(string connName="Default")
        {
            return ConfigurationManager.ConnectionStrings[connName].ConnectionString.ToString();
        }
        public string GetWebSettingValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
