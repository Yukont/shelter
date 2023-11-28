using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shelter.Models;

namespace shelter.Controllers
{
    public class AdoptionStatusController : Controller
    {
        IAdoptionStatusService adoptionStatusService;

        private readonly IMapper mapper;

        public AdoptionStatusController(IAdoptionStatusService adoptionStatusService, IMapper mapper)
        {
            this.adoptionStatusService = adoptionStatusService;
            this.mapper = mapper;
        }


        // GET: AdoptionStatusController
        public async Task<ActionResult> Index()
        {
            IEnumerable<AdoptionStatusDTO> adoptionStatusDtos = await adoptionStatusService.GetAllAdoptionStatus();

            AdoptionStatusIndexModel model = new();
            model.adoptionStatusIndexModels = mapper.Map<IEnumerable<AdoptionStatusDTO>, IEnumerable<AdoptionStatusViewModel>>(adoptionStatusDtos);

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
        public async Task<ActionResult> CreateAsync(AdoptionStatusViewModel adoptionStatusViewModel)
        {
            try
            {
                AdoptionStatusDTO adoptionStatusDtoCreate = mapper.Map<AdoptionStatusViewModel, AdoptionStatusDTO>(adoptionStatusViewModel);
                await adoptionStatusService.AddAdoptionStatus(adoptionStatusDtoCreate);
                return RedirectToAction("Index", "AdoptionStatus");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdoptionStatusController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            AdoptionStatusDTO adoptionStatusDto = await adoptionStatusService.GetAdoptionStatusById(id);
            AdoptionStatusViewModel adoptionStatusViewModel = mapper.Map<AdoptionStatusDTO, AdoptionStatusViewModel>(adoptionStatusDto);
            return View(adoptionStatusViewModel);
        }

        // POST: AdoptionStatusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AdoptionStatusViewModel adoptionStatusViewModel)
        {
            try
            {
                AdoptionStatusDTO adoptionStatusDto = mapper.Map<AdoptionStatusViewModel, AdoptionStatusDTO>(adoptionStatusViewModel);
                await adoptionStatusService.UpdateAdoptionStatus(adoptionStatusDto);
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
            await adoptionStatusService.RemoveAdoptionStatus(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: AdoptionStatusController/Delete/5
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(AdoptionStatusViewModel adoptionStatusViewModel)
        {
            try
            {
                await adoptionStatusService.RemoveAdoptionStatus(adoptionStatusViewModel.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }*/
    }
}
