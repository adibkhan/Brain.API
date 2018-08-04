using ServiceStack;
using Brain.API.ServiceModel.DTOs;

namespace Brain.API.ServiceModel.Messages
{
    [Route("/GetUsers", Verbs = "GET", Notes = "GetUsers")]
    public class GetUsersRequest : IReturn<GetUsersResponse>
    {
        public User User { get; set; }
    }
}
