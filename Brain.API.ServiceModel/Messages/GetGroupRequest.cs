using ServiceStack;
using Brain.API.ServiceModel.DTOs;

namespace Brain.API.ServiceModel.Messages
{
    [Route("/GetGroup/{gid}", Verbs = "GET", Notes = "GetAGroup")]
    public class GetGroupRequest : IReturn<GetGroupResponse>
    {
        public int Gid { get; set; }
    }
}
