using System;
using System.Collections.Generic;
using Brain.API.Managers.Interfaces;
using Brain.API.ServiceModel.DTOs;

namespace Brain.API.Managers
{
    public class BrainManager : IBrainManager
    {
        IConfigManager _configManager;

        public BrainManager(IConfigManager configManager)
        {
            _configManager = configManager;
        }

        public List<User> GetUsers()
        {
            string passWordFile = _configManager.GetGroupFileFullPath();
            List<User> users = new List<User>();
            return users;
        }
    }
}
