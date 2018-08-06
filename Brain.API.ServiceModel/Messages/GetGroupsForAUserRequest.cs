using ServiceStack;
using Brain.API.ServiceModel.DTOs;

namespace Brain.API.ServiceModel.Messages
{
    [Route("/Group/GetGroups/{uid}", Verbs = "GET", Notes = "GetGroupsForAUser")]
    public class GetGroupsForAUserRequest : IReturn<GetGroupsForAUserResponse>
    {
        public string Uid { get; set; }
    }
}
