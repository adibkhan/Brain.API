using System.Collections.Generic;
using ServiceStack;
using Brain.API.ServiceModel.Messages;
using Brain.API.ServiceModel.DTOs;
using Brain.API.Managers.Interfaces;

namespace Brain.API.ServiceDefinition
{
    class BrainGatewayService : Service
    {
        IBrainManager _brainManager;

        public BrainGatewayService(IBrainManager brainManager)
        {
            _brainManager = brainManager;
        }
        public GetUsersResponse Get(GetUsersRequest request)
        {
            GetUsersResponse response = new GetUsersResponse();
            response.Users = new List<User>()
            {
                new User()
                {
                    Name = "Adib"
                }
            };

            _brainManager.GetUsers();

            return response;
        }

        public GetUserResponse Get(GetUserRequest request)
        {
            GetUserResponse response = new GetUserResponse();
            response.User = new User()
            {
                Name = "Adib"
            };
            return response;
        }

        public GetGroupsForAUserResponse Get(GetGroupsForAUserRequest request)
        {
            GetGroupsForAUserResponse response = new GetGroupsForAUserResponse();

            return response;
        }

        public GetAllGroupsResponse Get(GetAllGroupsRequest request)
        {
            GetAllGroupsResponse response = new GetAllGroupsResponse();

            return response;
        }

        public GetGroupsResponse Get(GetGroupsRequest request)
        {
            GetGroupsResponse response = new GetGroupsResponse();

            return response;
        }
        public GetGroupResponse Get(GetGroupRequest request)
        {
            GetGroupResponse response = new GetGroupResponse();

            return response;
        }
    }
}
