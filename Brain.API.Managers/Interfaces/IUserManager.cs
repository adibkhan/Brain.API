using Brain.API.ServiceModel.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brain.API.Managers.Interfaces
{
    public interface IUserManager
    {
        List<User> GetUsers();
        List<User> AddToExistingUsers(List<User> currentUsers, List<User> newUsers);
    }
}
