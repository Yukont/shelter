using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using shelter.Models;

namespace shelter.Controllers
{
    public class StatusOfHealthController : Controller
    {
        IStatusOfHealthService statusOfHealthService;

        private readonly IMapper mapper;

        public StatusOfHealthController(IStatusOfHealthService statusOfHealthService, IMapper mapper)
        {
            this.statusOfHealthService = statusOfHealthService;
            this.mapper = mapper;
        }


        // GET: AdoptionStatusController
        public async Task<ActionResult> Index()
        {
            IEnumerable<StatusOfHealthDTO> statusOfHealthDTO = await statusOfHealthService.GetAllStatusOfHealths();

            StatusOfHealthIndexModel model = new();
            model.statusOfHealthViewModel = mapper.Map<IEnumerable<StatusOfHealthDTO>, IEnumerable<StatusOfHealthViewModel>>(statusOfHealthDTO);

            return View(model);
        }

        // GET: AdoptionStatusController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdoptionStatusController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdoptionStatusController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(StatusOfHealthViewModel statusOfHealthViewModel)
        {
            try
            {
                StatusOfHealthDTO statusOfHealthDTO = mapper.Map<StatusOfHealthViewModel, StatusOfHealthDTO>(statusOfHealthViewModel);
                await statusOfHealthService.AddStatusOfHealth(statusOfHealthDTO);
                return RedirectToAction("Index", "StatusOfHealth");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdoptionStatusController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            StatusOfHealthDTO statusOfHealthDTO = await statusOfHealthService.GetStatusOfHealthId(id);
            StatusOfHealthViewModel statusOfHealthViewModel = mapper.Map<StatusOfHealthDTO, StatusOfHealthViewModel>(statusOfHealthDTO);
            return View(statusOfHealthViewModel);
        }

        // POST: AdoptionStatusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(StatusOfHealthViewModel StatusOfHealthViewModel)
        {
            try
            {
                StatusOfHealthDTO statusOfHealthDTO = mapper.Map<StatusOfHealthViewModel, StatusOfHealthDTO>(StatusOfHealthViewModel);
                await statusOfHealthService.UpdateStatusOfHealth(statusOfHealthDTO);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdoptionStatusController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await statusOfHealthService.RemoveStatusOfHealth(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
