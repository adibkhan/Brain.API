using System;
using System.Collections.Generic;
using Brain.API.ServiceModel.DTOs;

namespace Brain.API.ServiceModel.Messages
{
    public class GetUsersResponse
    {
        public List<User> Users { get; set; }
    }
}
