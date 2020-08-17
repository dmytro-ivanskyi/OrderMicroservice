using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcAuthService;
using System.Threading.Tasks;

namespace Service.ServiceInterfaces
{
    public interface IUserService
    {
        UserReply RegisterUser(UserRequest request, CallOptions options);

        AllUsersReply GetAllUsers(Empty request, CallOptions options);
    }
}
