using System;
using System.Collections.Generic;
using System.Linq;
using Brain.API.ServiceModel.DTOs;

namespace Brain.API.Managers.Interfaces
{
    public interface IBrainManager
    {
        List<User> GetUsers();

    }
}
