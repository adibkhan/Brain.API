using ServiceStack;
using Brain.API.ServiceModel.DTOs;

namespace Brain.API.ServiceModel.Messages
{
    [Route("/User/{uid}/Groups", Verbs = "GET", Notes = "GetGroupsForAUser")]
    public class GetGroupsForAUserRequest : IReturn<GetGroupsForAUserResponse>
    {
        public string Uid { get; set; }
    }
}
