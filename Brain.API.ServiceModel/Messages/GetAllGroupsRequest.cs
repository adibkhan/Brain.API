using ServiceStack;
using Brain.API.ServiceModel.DTOs;

namespace Brain.API.ServiceModel.Messages
{
    [Route("/Group/GetAllGroups", Verbs = "GET", Notes = "GetAllGroups")]
    public class GetAllGroupsRequest : IReturn<GetAllGroupsResponse>
    {
    }
}
