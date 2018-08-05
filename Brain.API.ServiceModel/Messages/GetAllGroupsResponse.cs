using System;
using System.Collections.Generic;
using Brain.API.ServiceModel.DTOs;

namespace Brain.API.ServiceModel.Messages
{
    public class GetAllGroupsResponse
    {
        public List<Group> Groups { get; set; }
    }
}
