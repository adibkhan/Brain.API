using System;
using System.Configuration;
using Brain.API.Managers.Interfaces;
using System.IO;
using System.Reflection;

namespace Brain.API.Managers
{
    /// <summary>
    /// Manager containing all configuration logic
    /// </summary>
    public class ConfigManager : IConfigManager
    {
        private const string groupFileName = "GroupFileName";
        private const string groupFilePath = "GroupFilePath";
        private const string passwordfileName = "passwordfileName";
        private const string passwordfilePath = "passwordfilePath";
        private const int userPropertiesLength = 6;
        private const int groupPropertiesLength = 3;

        public string GetFileFullPath(string fName, string fPath)
        {
            string fileName = ReadConfig(fName);

            if(string.IsNullOrEmpty(fileName))
            { 
                throw new Exception($"{fName} was not found in the app config");
            }

            string filePath = ReadConfig(fPath);

            if (string.IsNullOrEmpty(filePath))
            {
                throw new Exception($"{fName} could not be found.");
            }

            string fullPath = Path.Combine(filePath, fileName);

            if(!File.Exists(fullPath))
            {
                // If not available check the application default directory
                filePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) + @"\UnixFiles\";
                fullPath = Path.Combine(filePath, fileName);
                if (!File.Exists(fullPath))
                {
                    throw new Exception($"{fName} could not be found.");
                }
            }

            return fullPath;
        }

        public string GetGroupFileFullPath()
        {
            return GetFileFullPath(groupFileName, groupFilePath);
        }

        public string GetPasswordFileFullPath()
        {
            return GetFileFullPath(passwordfileName, passwordfilePath);
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

        public int GetUserPropertiesLength()
        {
            return userPropertiesLength;
        }

        public int GetGroupPropertiesLength()
        {
            return groupPropertiesLength;
        }
    }
}
