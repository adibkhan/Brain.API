using System.Collections.Generic;
using ServiceStack;
using Brain.API.ServiceModel.Messages;
using Brain.API.ServiceModel.DTOs;

namespace Brain.API.ServiceDefinition
{
    class BrainGatewayService : Service
    {
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

            return response;
        }


    }
}
