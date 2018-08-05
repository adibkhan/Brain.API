using ServiceStack;
using Brain.API.ServiceModel.DTOs;

namespace Brain.API.ServiceModel.Messages
{
    [Route("/GetGroups", Verbs = "GET", Notes = "SearchForGroups")]
    public class GetGroupsRequest : IReturn<GetGroupsResponse>
    {
        public Group group { get; set; }
    }
}
