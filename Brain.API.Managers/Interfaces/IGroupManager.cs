using Brain.API.ServiceModel.DTOs;
using System.Collections.Generic;

namespace Brain.API.Managers.Interfaces
{
    public interface IGroupManager
    {
        List<Group> GetGroups();
        List<Group> AddToExistingGroups(ref List<Group> currentGroups, List<Group> newGroups);
    }
}
