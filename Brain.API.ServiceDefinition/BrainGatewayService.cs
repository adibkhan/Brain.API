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

            response.Users = _brainManager.GetUsers(request.User);

            return response;
        }

        public GetAllUsersResponse Get(GetAllUsersRequest request)
        {
            GetAllUsersResponse response = new GetAllUsersResponse();

            response.Users = _brainManager.GetUsers();

            return response;
        }

        public GetUserResponse Get(GetUserRequest request)
        {
            GetUserResponse response = new GetUserResponse();
            User result = _brainManager.GetUser(request.Uid);
            response.User = result ?? throw HttpError.NotFound($"User {request.Uid} does not exist");

            return response;
        }

        public GetGroupsForAUserResponse Get(GetGroupsForAUserRequest request)
        {
            GetGroupsForAUserResponse response = new GetGroupsForAUserResponse();

            if (!string.IsNullOrEmpty(request.Uid))
            {
                response.Groups = _brainManager.GetGroupsForUsers(request.Uid);
            }
            return response;
        }

        public GetAllGroupsResponse Get(GetAllGroupsRequest request)
        {
            GetAllGroupsResponse response = new GetAllGroupsResponse();
            response.Groups = _brainManager.GetGroups();
            return response;
        }

        public GetGroupsResponse Get(GetGroupsRequest request)
        {
            GetGroupsResponse response = new GetGroupsResponse();
            response.Groups = _brainManager.GetGroups(request.Group);
            return response;
        }

        public GetGroupResponse Get(GetGroupRequest request)
        {
            GetGroupResponse response = new GetGroupResponse();
            string gid = request.Gid;

            Group result =  _brainManager.GetGroup(gid);
            response.Group = result ?? throw HttpError.NotFound($"Group {gid} does not exist");
            return response;
        }
    }
}
