using System;
using System.Collections.Generic;
using System.Linq;
using Brain.API.ServiceModel.DTOs;

namespace Brain.API.Managers.Interfaces
{
    public interface IBrainManager
    {
        List<User> GetUsers();
        List<User> GetUsers(User user);
        User GetUser(string uid);
        List<Group> GetGroups();
        Group GetGroup(string gid);
        List<Group> GetGroups(Group group);
        List<Group> GetGroupsForUsers(string uid);
    }
}
