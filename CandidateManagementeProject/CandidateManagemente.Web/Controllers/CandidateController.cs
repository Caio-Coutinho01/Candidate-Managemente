using AutoMapper;
using CandidateManagemente.Application.Commands.Candidates;
using CandidateManagemente.Application.Queries.Candidates;
using CandidateManagemente.Web.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CandidateManagemente.Web.Controllers
{
    public class CandidateController : Controller
    {
        private readonly IMediator _mediator;
        IMapper _mapper;

        public CandidateController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var getStudentQuery = new GetCandidatesQuery();

                return View(await _mediator.Send(getStudentQuery));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        public async Task<IActionResult> Details([FromQuery] GetCandidateDetail getCandidateId, int Id)
        {
            getCandidateId.Id = Id;
            var result = _mapper.Map<List<CandidateCompleteVM>>(await _mediator.Send(getCandidateId)).FirstOrDefault();

            if (result != null)
            {
                return PartialView("_DetailsPartial", result);
            }

            return NotFound();
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddCandidateCommand command)
        {
            try
            {
                var idUser = HttpContext.User.FindFirst("IdUser").Value;
                command.IdUser = int.Parse(idUser);
                var request = await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit( int Id)
        {
            GetCandidateDetail getCandidateId = new GetCandidateDetail();
            getCandidateId.Id = Id;
            var convertListToVM =_mapper.Map<List<CandidateCompleteVM>>(await _mediator.Send(getCandidateId));
            return View(_mapper.Map<CandidateCompleteVM>(convertListToVM.FirstOrDefault()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateCandidateCommand command, int id)
        {
            try
            {
                command.IdCandidate = id;
                var request = await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Delete(int Id)
        {
            GetCandidateDetail getCandidateId = new GetCandidateDetail();
            getCandidateId.Id = Id;
            return View(_mapper.Map<List<CandidateCompleteVM>>(await _mediator.Send(getCandidateId)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromQuery] DeleteCandidateCommand deleteCandidateCommand,int id)
        {
            try
            {
                deleteCandidateCommand.idCandidate = id;
                var request = await _mediator.Send(deleteCandidateCommand);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
