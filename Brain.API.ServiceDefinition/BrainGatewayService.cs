using System.Collections.Generic;
using ServiceStack;
using Brain.API.ServiceModel.Messages;
using Brain.API.ServiceModel.DTOs;
using Brain.API.Managers.Interfaces;
using System;

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
            // Top level try catch to capture any error
            try
            {
                response.Users = _brainManager.GetUsers(request.User);
            }
            catch (Exception ex)
            {
                // Servicestack automatically adds the stacktrace in the response object
                throw ex;
            }
            return response;
        }

        public GetAllUsersResponse Get(GetAllUsersRequest request)
        {
            GetAllUsersResponse response = new GetAllUsersResponse();

            try
            {
                response.Users = _brainManager.GetUsers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

            try
            {
                if (!string.IsNullOrEmpty(request.Uid))
                {
                    response.Groups = _brainManager.GetGroupsForUsers(request.Uid);
                }
            }
            catch (Exception ex)
            {
                throw;
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

            Group result = _brainManager.GetGroup(gid);
            response.Group = result ?? throw HttpError.NotFound($"Group {gid} does not exist");
            return response;
        }
    }
}
