﻿using System;
using System.Collections.Generic;
using Brain.API.ServiceModel.DTOs;

namespace Brain.API.ServiceModel.Messages
{
    public class GetGroupsForAUserResponse
    {
        public List<Group> Groups { get; set; }
    }
}
