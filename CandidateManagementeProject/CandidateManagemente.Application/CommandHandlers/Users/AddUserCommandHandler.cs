using CandidateManagemente.Application.Commands.Authentication;
using CandidateManagemente.Domain.Entities;
using CandidateManagemente.Domain.Interface;
using MediatR;

namespace CandidateManagemente.Application.CommandHandlers.Authentication
{
    public class AddUserCommandHandler : IRequestHandler<UserCommand, Result>
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public AddUserCommandHandler(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository ?? throw new ArgumentNullException(nameof(authenticationRepository));
        }

        public async Task<Result> Handle(UserCommand request, CancellationToken cancellationToken)
        {
            // Verifique se o e-mail já existe
            if (await _authenticationRepository.EmailExists(request.Email))
            {
                return new Result { IsSuccess = false, Message = "Email já registrado" };
            }

            // Hash da senha (não armazenar em texto simples)
            var hashedPassword = HashPassword(request.Password);

            var user = new User
            {
                Name = request.Name,
                Surname = request.Surname,
                Credentials = new Credentials
                {
                    Email = request.Email,
                    Password = hashedPassword
                }
            };

            await _authenticationRepository.AddAsync(user);
            return new Result { IsSuccess = true, Message = "Registro bem-sucedido" };
        }
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

    }
}
