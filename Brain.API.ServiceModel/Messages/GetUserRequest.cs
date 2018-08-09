using ServiceStack;
using Brain.API.ServiceModel.DTOs;

namespace Brain.API.ServiceModel.Messages
{
    [Route("/User/{uid}", Verbs = "GET", Notes = "GetAUser")]
    public class GetUserRequest : IReturn<GetUserResponse>
    {
        public string Uid { get; set; }
    }
}
