using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using Brain.API.Managers.Interfaces;
using Brain.API.ServiceModel.DTOs;

namespace Brain.API.Managers
{
    public class BrainManager : IBrainManager
    {
        IGroupManager _groupManager;
        IUserManager _userManager;

        public BrainManager(IGroupManager groupManager, IUserManager userManager)
        {
            _groupManager = groupManager;
            _userManager = userManager;
        }

        public List<User> GetUsers()
        {
            return _userManager.GetUsers();
        }

        public List<User> GetUsers(User user)
        {
            List<User> allUsers = _userManager.GetUsers();
            List<User> result = new List<User>();

            // Could not use reflection due to compilation error
            List<User> usersByParameter = allUsers.Where(x => x.Name == user.Name).ToList();
            result = _userManager.AddToExistingUsers(result, usersByParameter);

            usersByParameter = allUsers.Where(x => x.Uid == user.Uid).ToList();
            result = _userManager.AddToExistingUsers(result, usersByParameter);

            usersByParameter = allUsers.Where(x => x.Gid == user.Gid).ToList();
            result = _userManager.AddToExistingUsers(result, usersByParameter);

            usersByParameter = allUsers.Where(x => x.Home == user.Home).ToList();
            result = _userManager.AddToExistingUsers(result, usersByParameter);

            usersByParameter = allUsers.Where(x => x.Shell == user.Shell).ToList();
            result = _userManager.AddToExistingUsers(result, usersByParameter);

            usersByParameter = allUsers.Where(x => x.Comment == user.Shell).ToList();
            result = _userManager.AddToExistingUsers(result, usersByParameter);

            return result.ToList();
        }

        public User GetUser(string uid)
        {
            List<User> allUsers = _userManager.GetUsers();
            return allUsers.FirstOrDefault(x => x.Uid == uid);
        }
      
        public Group GetGroup(string gid)
        {
            var allGroups = GetGroups();
            var result = allGroups.FirstOrDefault(x => x.Gid.Equals(gid));
            return result;
        }

        public List<Group> GetGroups()
        {
            return _groupManager.GetGroups();
        }

        public List<Group> GetGroups(Group group)
        {
            List<Group> result = new List<Group>();

            var allGroups = _groupManager.GetGroups();

            var groupsByName = allGroups.Where(x => x.Name.Equals(group.Name)).ToList();

            result = _groupManager.AddToExistingGroups(ref result, groupsByName);

            var groupsByGid = allGroups.Where(x => x.Gid.Equals(group.Gid)).ToList();

            result = _groupManager.AddToExistingGroups(ref result, groupsByGid);
            //Fix this
            var groupsByMembers = allGroups.Where(x => x.Members.Intersect(group.Members).Count() == group.Members.Count()).ToList();

            result = _groupManager.AddToExistingGroups(ref result, groupsByMembers);


            return result;
        }

        public List<Group> GetGroupsForUsers(string uid)
        {
            List<Group> result = new List<Group>();
            User user = GetUser(uid);
            List<Group> allGroups = _groupManager.GetGroups();

            if (user != null)
            {
                result = allGroups.Where(x => x.Members.Contains(user.Name)).ToList();

            }
            return result;
        }
    }
}
