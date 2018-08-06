using Brain.API.Managers.Interfaces;
using Brain.API.ServiceModel.DTOs;
using System;
using System.Collections.Generic;

namespace Brain.API.Managers
{
    public class UserManager : IUserManager
    {
        IConfigManager _configManager;
        public UserManager(IConfigManager configManager)
        {
            _configManager = configManager;
        }
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            string passWordFile = _configManager.GetPasswordFileFullPath();

            if (string.IsNullOrEmpty(passWordFile))
            {
                return users;
            }

            string[] lines = System.IO.File.ReadAllLines(@passWordFile);

            return MapStringsToUsers(lines);
        }

        public List<User> MapStringsToUsers(string[] lines)
        {
            List<User> users = new List<User>();
            foreach (var line in lines)
            {

                users.Add(MapStringToUser(line));
            }

            return users;
        }

        public User MapStringToUser(string line)
        {
            try
            {
                string[] userParameter = line.Split(':');
                if (userParameter.Length != _configManager.GetUserPropertiesLength())
                {
                    throw new Exception("Error parsing user information");
                }

                User user = new User()
                {
                    Name = userParameter[0],
                    Uid = userParameter[1],
                    Gid = userParameter[2],
                    Comment = userParameter[3],
                    Home = userParameter[4],
                    Shell = userParameter[5],
                };

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Error parsing user information", ex);
            }
        }
        public List<User> AddToExistingUsers(List<User> currentUsers, List<User> newUsers)
        {
            foreach (var user in newUsers)
            {
                if (!currentUsers.Contains(user))
                {
                    currentUsers.Add(user);
                }
            }
            return currentUsers;
        }

    }
}
