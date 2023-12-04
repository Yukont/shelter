using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using shelter.Models;

namespace shelter.Controllers
{
    public class ClinicController : Controller
    {
        IClinicService clinicService;

        private readonly IMapper mapper;

        public ClinicController(IClinicService clinicService, IMapper mapper)
        {
            this.clinicService = clinicService;
            this.mapper = mapper;
        }


        // GET: AdoptionStatusController
        public async Task<ActionResult> Index()
        {
            IEnumerable<ClinicDTO> clinicDTO = await clinicService.GetAllClinics();

            ClinicIndexModel model = new();
            model.clinicViewModels = mapper.Map<IEnumerable<ClinicDTO>, IEnumerable<ClinicViewModel>>(clinicDTO);

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
        public async Task<ActionResult> CreateAsync(ClinicViewModel clinicViewModel)
        {
            try
            {
                ClinicDTO clinicDTO = mapper.Map<ClinicViewModel, ClinicDTO>(clinicViewModel);
                await clinicService.AddClinic(clinicDTO);
                return RedirectToAction("Index", "Clinic");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdoptionStatusController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            ClinicDTO clinicDTO = await clinicService.GetClinicId(id);
            ClinicViewModel clinicViewModel = mapper.Map<ClinicDTO, ClinicViewModel>(clinicDTO);
            return View(clinicViewModel);
        }

        // POST: AdoptionStatusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ClinicViewModel ClinicViewModel)
        {
            try
            {
                ClinicDTO clinicDTO = mapper.Map<ClinicViewModel, ClinicDTO>(ClinicViewModel);
                await clinicService.UpdateClinic(clinicDTO);
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
            await clinicService.RemoveClinic(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
