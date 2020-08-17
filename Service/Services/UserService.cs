using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcAuthService;
using Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : Register.RegisterClient, IUserService
    {
        private readonly Register.RegisterClient _client;
        public UserService(Register.RegisterClient client)
        {
            _client = client;
        }

        public override UserReply RegisterUser(UserRequest request, CallOptions options)
        {
            var reply = _client.RegisterUser(request);
            return reply;
        }

        public override AllUsersReply GetAllUsers(Empty request, CallOptions options)
        {
            return _client.GetAllUsers(request, options);
        }
    }
}
