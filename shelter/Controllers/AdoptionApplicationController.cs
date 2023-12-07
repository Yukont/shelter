using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using shelter.Models;

namespace shelter.Controllers
{
    public class AdoptionApplicationController : Controller
    {
        IAdoptionApplicationService adoptionApplicationService;

        private readonly IMapper mapper;

        public AdoptionApplicationController(IAdoptionApplicationService adoptionApplicationService, IMapper mapper)
        {
            this.adoptionApplicationService = adoptionApplicationService;
            this.mapper = mapper;
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
            AdoptionApplicationDTO adoptionApplicationDTO = await adoptionApplicationService.GetAdoptionApplicationById(id);
            AdoptionApplicationViewModel adoptionApplicationViewModel = mapper.Map<AdoptionApplicationDTO, AdoptionApplicationViewModel>(adoptionApplicationDTO);
            return View(adoptionApplicationViewModel);
        }

        // POST: AdoptionStatusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AdoptionApplicationViewModel AdoptionApplicationViewModel)
        {
            try
            {
                AdoptionApplicationDTO adoptionApplicationDTO = mapper.Map<AdoptionApplicationViewModel, AdoptionApplicationDTO>(AdoptionApplicationViewModel);
                await adoptionApplicationService.UpdateAdoptionApplication(adoptionApplicationDTO);
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
            await adoptionApplicationService.RemoveAdoptionApplication(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
