using CandidateManagemente.Application.Commands.Users;
using CandidateManagemente.Domain.Interface;
using MediatR;

namespace CandidateManagemente.Application.CommandHandlers.Users
{
    public class AuthenticationUserCommandHandler : IRequestHandler<AuthenticationUserCommand, Result>
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public AuthenticationUserCommandHandler(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository ?? throw new ArgumentNullException(nameof(authenticationRepository));
        }

        public async Task<Result> Handle(AuthenticationUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _authenticationRepository.GetUser(request.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Credentials.Password))
            {
                return new Result { IsSuccess = false, Message = "Email ou senha incorreto!" };
            }

            return new Result { IsSuccess = true, Message = "" };
        }
    }
}
