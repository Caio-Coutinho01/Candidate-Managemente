using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagemente.Application.Commands.Users
{
    public class AuthenticationUserCommand : IRequest<Result>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
