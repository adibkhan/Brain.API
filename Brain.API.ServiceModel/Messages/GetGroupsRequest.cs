using ServiceStack;
using Brain.API.ServiceModel.DTOs;

namespace Brain.API.ServiceModel.Messages
{
    [Route("/Group/Groups", Verbs = "GET", Notes = "SearchForGroups")]
    public class GetGroupsRequest : IReturn<GetGroupsResponse>
    {
        public Group Group { get; set; }
    }
}
