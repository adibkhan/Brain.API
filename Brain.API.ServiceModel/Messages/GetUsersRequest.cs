using ServiceStack;
using Brain.API.ServiceModel.DTOs;

namespace Brain.API.ServiceModel.Messages
{
    [Route("/User/Users", Verbs = "GET", Notes = "Return a list of users matching all of the specified query fields.")]
    public class GetUsersRequest : IReturn<GetUsersResponse>
    {
        public User User { get; set; }
    }
}
