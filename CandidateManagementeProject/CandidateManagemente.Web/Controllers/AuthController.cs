using CandidateManagemente.Infra.Data.Context;
using CandidateManagemente.Web.ViewModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using CandidateManagemente.Application.Commands.Authentication;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using CandidateManagemente.Application.Commands.Users;

namespace CandidateManagemente.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;
        private readonly MyCustomDbContext _dbContext;

        public AuthController(MyCustomDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new AuthenticationUserCommand
            {
                Email = model.Email,
                Password = model.Password
            };

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Candidate");
            }

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterRequest model)
        {
            var command = new UserCommand
            {
                Email= model.Email,
                Password= model.Password,
                Name = model.Name,
                Surname = model.Surname,
            };

            var result = await _mediator.Send(command);

            TempData["Message"] = result.Message;

            return RedirectToAction("Index", "Home");
        }
    }
}
