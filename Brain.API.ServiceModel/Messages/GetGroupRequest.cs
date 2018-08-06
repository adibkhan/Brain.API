using ServiceStack;
using Brain.API.ServiceModel.DTOs;

namespace Brain.API.ServiceModel.Messages
{
    [Route("/Group/GetGroup/{gid}", Verbs = "GET", Notes = "GetAGroup")]
    public class GetGroupRequest : IReturn<GetGroupResponse>
    {
        public string Gid { get; set; }
    }
}
