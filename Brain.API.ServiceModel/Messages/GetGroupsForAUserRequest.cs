using ServiceStack;
using Brain.API.ServiceModel.DTOs;

namespace Brain.API.ServiceModel.Messages
{
    [Route("/GetGroups/{uid}", Verbs = "GET", Notes = "GetGroupsForAUser")]
    public class GetGroupsForAUserRequest : IReturn<GetGroupsForAUserResponse>
    {
        public int Uid { get; set; }
    }
}
