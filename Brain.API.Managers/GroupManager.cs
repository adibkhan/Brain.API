using Brain.API.Managers.Interfaces;
using Brain.API.ServiceModel.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brain.API.Managers
{
    /// <summary>
    /// Manager to handle group related functionalities
    /// </summary>
    public class GroupManager : IGroupManager
    {
        IConfigManager _configManager;
        public GroupManager(IConfigManager configManager)
        {
            _configManager = configManager;
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
                if (parameters.Length != _configManager.GetGroupPropertiesLength())
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

        public List<Group> AddToExistingGroups(ref List<Group> currentGroups, List<Group> newGroups)
        {
            foreach (var group in newGroups)
            {
                if (!currentGroups.Contains(group))
                {
                    currentGroups.Add(group);
                }
            }
            return currentGroups;
        }
    }
}
