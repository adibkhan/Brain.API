using ServiceStack;
using Brain.API.ServiceModel.DTOs;

namespace Brain.API.ServiceModel.Messages
{
    [Route("/GetUser/{uid}", Verbs = "GET", Notes = "GetAUser")]
    public class GetUserRequest : IReturn<GetUserResponse>
    {
        public int Uid { get; set; }
    }
}
