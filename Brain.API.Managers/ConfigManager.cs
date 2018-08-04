using System;
using System.Configuration;
using Brain.API.Managers.Interfaces;

namespace Brain.API.Managers
{
    public class ConfigManager : IConfigManager
    {

        public string GetGroupFileFullPath()
        {
            return ReadConfig("GroupFileName");
        }

        public string GetPasswordFileFullPath()
        {
            return ReadConfig("PasswordfileName");
        }


        public string ReadConfig(string configName)
        {
            try
            {
                return ConfigurationManager.AppSettings[configName];

            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }


    }
}
