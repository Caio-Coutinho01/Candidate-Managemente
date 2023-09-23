using AutoMapper;
using CandidateManagemente.Application.Commands.Candidates;
using CandidateManagemente.Application.Queries.Candidates;
using CandidateManagemente.Web.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CandidateManagemente.Web.Controllers
{
    public class CandidateController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly int _idUser;

        public CandidateController(IMediator mediator, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _idUser = int.Parse(httpContextAccessor.HttpContext.User.FindFirst("IdUser").Value);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _mediator.Send(new GetCandidateCommand { IdUser = _idUser});

                return View(response.Candidates);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        public async Task<IActionResult> Details(int idCandidate)
        {
            var response = await _mediator.Send(new GetCandidateCommand { IdUser = _idUser, IdCandidate = idCandidate });

            if (response.CandidateExperiences != null)
            {
                var result = _mapper.Map<List<CandidateCompleteVM>>(response.CandidateExperiences).FirstOrDefault();
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
                command.IdUser = _idUser;
                var request = await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(int IdCandidate)
        {
            var response = await _mediator.Send(new GetCandidateCommand { IdUser = _idUser, IdCandidate = IdCandidate });

            var convertListToVM =_mapper.Map<List<CandidateCompleteVM>>(response.CandidateExperiences);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int IdCandidate)
        {
            try
            {
                var request = await _mediator.Send(new DeleteCandidateCommand {idCandidate = IdCandidate });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> FindCandidate()
        //{
        //    try
        //    {
        //        var response = await _mediator.Send(new GetCandidateCommand { IdUser = _idUser });
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
