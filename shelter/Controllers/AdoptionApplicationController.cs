using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using shelter.Models;

namespace shelter.Controllers
{
    public class AdoptionApplicationController : Controller
    {
        IAdoptionApplicationService adoptionApplicationService;
        IAdoptionStatusService adoptionStatusService;

        private readonly IMapper mapper;

        public AdoptionApplicationController(IAdoptionApplicationService adoptionApplicationService, IMapper mapper, IAdoptionStatusService adoptionStatusService)
        {
            this.adoptionApplicationService = adoptionApplicationService;
            this.mapper = mapper;
            this.adoptionStatusService = adoptionStatusService;
        }


        // GET: AdoptionStatusController
        public async Task<ActionResult> Index()
        {
            IEnumerable<AdoptionApplicationDTO> adoptionApplicationDTO = await adoptionApplicationService.GetAllAdoptionApplications();

            AdoptionApplicationIndexModel model = new();
            model.adoptionApplicationViewModels = mapper.Map<IEnumerable<AdoptionApplicationDTO>, IEnumerable<AdoptionApplicationViewModel>>(adoptionApplicationDTO);

            return View(model);
        }

        // GET: AdoptionStatusController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Create(int id)
        {
            try
            {
                AdoptionApplicationDTO adoptionApplicationDTO = new()
                {
                    IdUser = int.Parse(User.Identity.Name),
                    IdStatus = 1,
                    IdAnimal = id
                };
                await adoptionApplicationService.AddAdoptionApplication(adoptionApplicationDTO);
                return View();
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: AdoptionStatusController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            TempData["PreviousUrl"] = Request.Headers["Referer"].ToString();
            AdoptionApplicationDTO adoptionApplicationDTO = await adoptionApplicationService.GetAdoptionApplicationById(id);
            AdoptionApplicationViewModel adoptionApplicationViewModel = mapper.Map<AdoptionApplicationDTO, AdoptionApplicationViewModel>(adoptionApplicationDTO);
            adoptionApplicationViewModel.adoptionStatusViewModels = await GetAdoptionStatus();
            return View(adoptionApplicationViewModel);
        }

        // POST: AdoptionStatusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AdoptionApplicationViewModel AdoptionApplicationViewModel, int AnimalId, int UserId)
        {
            try
            {
                AdoptionApplicationDTO adoptionApplicationDTO = mapper.Map<AdoptionApplicationViewModel, AdoptionApplicationDTO>(AdoptionApplicationViewModel);
                adoptionApplicationDTO.IdAnimal = AnimalId;
                adoptionApplicationDTO.IdUser = UserId;
                await adoptionApplicationService.UpdateAdoptionApplication(adoptionApplicationDTO);
                var previousUrl = TempData["PreviousUrl"]?.ToString();
                return Redirect(previousUrl);
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: AdoptionStatusController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await adoptionApplicationService.RemoveAdoptionApplication(id);
            return RedirectToAction(nameof(Index));
        }
        private async Task<IEnumerable<AdoptionStatusViewModel>> GetAdoptionStatus()
        {
            IEnumerable<AdoptionStatusDTO> adoptionStatusDTOs = await adoptionStatusService.GetAllAdoptionStatus ();
            return mapper.Map<IEnumerable<AdoptionStatusDTO>, IEnumerable<AdoptionStatusViewModel>>(adoptionStatusDTOs);
        }
    }
}
