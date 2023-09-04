using CandidateManagemente.Infra.Data.Context;
using CandidateManagemente.Web.ViewModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using CandidateManagemente.Application.Commands.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CandidateManagemente.Application.Commands.Users;
using CandidateManagemente.Domain.Entities;

namespace CandidateManagemente.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
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
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, model.Email),
                    new Claim(ClaimTypes.Name, result.Name),
                    new Claim("IdUser", result.IdUser.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

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

            if (!result.IsSuccess)
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
