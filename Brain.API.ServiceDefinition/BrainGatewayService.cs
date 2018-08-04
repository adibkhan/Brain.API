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


    }
}
