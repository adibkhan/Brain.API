using ServiceStack;
using Brain.API.ServiceModel.DTOs;

namespace Brain.API.ServiceModel.Messages
{
    [Route("/User/AllUsers", Verbs = "GET", Notes = "Return a list of all users.")]
    public class GetAllUsersRequest : IReturn<GetAllUsersResponse>
    {
    }
}
