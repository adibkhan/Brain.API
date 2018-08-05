using System;
using System.Linq;
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
                if (userParameter.Length != _configManager.GetUserParameterLength())
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


        public List<Group> GetGroups()
        {
            List<Group> groups = new List<Group>();
            string file = _configManager.GetGroupFileFullPath();

            if (string.IsNullOrEmpty(file))
            {
                return groups;
            }

            string[] lines = System.IO.File.ReadAllLines(@file);

            return MapStringsToGroups(lines);
        }

        public List<Group> MapStringsToGroups(string[] lines)
        {
            List<Group> groups = new List<Group>();
            foreach (var line in lines)
            {

                groups.Add(MapStringToGroup(line));
            }

            return groups;
        }

        public Group MapStringToGroup(string line)
        {
            try
            {
                string[] parameters = line.Split(':');
                if (parameters.Length != _configManager.GetUserParameterLength())
                {
                    throw new Exception("Error parsing group information");
                }

                Group user = new Group()
                {
                    Name = parameters[0],
                    Gid = parameters[1],
                    Members = GetGroupMemberNames(parameters[2])
                };

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Error parsing user information", ex);
            }
        }

        public List<string> GetGroupMemberNames(string line)
        {
            return line.Split(',').ToList();
        }

    }
}
