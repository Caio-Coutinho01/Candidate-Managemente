using AutoMapper;
using CandidateManagemente.Application.Commands.Candidates;
using CandidateManagemente.Application.DTO;
using CandidateManagemente.Application.Queries.Candidates;
using CandidateManagemente.Domain.Entities;
using CandidateManagemente.Infra.Data.Repositories;
using CandidateManagemente.Web.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CandidateManagemente.Web.Controllers
{
    //[Route("api/[controller]")]
    public class CandidateController : Controller
    {
        private readonly CandidateRepository _candidareRepository = new CandidateRepository();
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

        // GET: CandidateController/Details/5
        public async Task<IActionResult> Details([FromQuery] GetCandidateDetail getCandidateId, int Id)
        {
            getCandidateId.Id = Id;
            return View(_mapper.Map<List<CandidateCompleteVM>>(await _mediator.Send(getCandidateId)));
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: CandidateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddCandidateCommand command)
        {
            try
            {
                var request = await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CandidateController/Edit/5
        public async Task<IActionResult> Edit( int Id)
        {
            GetCandidateDetail getCandidateId = new GetCandidateDetail();
            getCandidateId.Id = Id;
            var convertListToVM =_mapper.Map<List<CandidateCompleteVM>>(await _mediator.Send(getCandidateId));
            return View(_mapper.Map<CandidateCompleteVM>(convertListToVM.FirstOrDefault()));
        }

        // POST: CandidateController/Edit/5
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

        // GET: CandidateController/Delete/5
        public async Task<IActionResult> Delete(int Id)
        {
            GetCandidateDetail getCandidateId = new GetCandidateDetail();
            getCandidateId.Id = Id;
            return View(_mapper.Map<List<CandidateCompleteVM>>(await _mediator.Send(getCandidateId)));
        }

        // POST: CandidateController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromQuery] DeleteCandidateCommand deleteCandidateCommand,int id)
        {
            try
            {
                deleteCandidateCommand.idCandidate = id;
                var request = await _mediator.Send(deleteCandidateCommand);
                //return View(_mapper.Map<CandidateCompleteVM>(convertListToVM.FirstOrDefault()));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
