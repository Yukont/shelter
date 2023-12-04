using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using shelter.Models;

namespace shelter.Controllers
{
    public class GenderController : Controller
    {
        IGenderService genderService;

        private readonly IMapper mapper;

        public GenderController(IGenderService genderService, IMapper mapper)
        {
            this.genderService = genderService;
            this.mapper = mapper;
        }


        // GET: AdoptionStatusController
        public async Task<ActionResult> Index()
        {
            IEnumerable<GenderDTO> genderDTO = await genderService.GetAllGenders();

            GenderIndexModel model = new();
            model.genderViewModels = mapper.Map<IEnumerable<GenderDTO>, IEnumerable<GenderViewModel>>(genderDTO);

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
        public async Task<ActionResult> CreateAsync(GenderViewModel genderViewModel)
        {
            try
            {
                GenderDTO genderDTO = mapper.Map<GenderViewModel, GenderDTO>(genderViewModel);
                await genderService.AddGender(genderDTO);
                return RedirectToAction("Index", "Gender");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdoptionStatusController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            GenderDTO genderDTO = await genderService.GetGenderId(id);
            GenderViewModel genderViewModel = mapper.Map<GenderDTO, GenderViewModel>(genderDTO);
            return View(genderViewModel);
        }

        // POST: AdoptionStatusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(GenderViewModel GenderViewModel)
        {
            try
            {
                GenderDTO genderDTO = mapper.Map<GenderViewModel, GenderDTO>(GenderViewModel);
                await genderService.UpdateGender(genderDTO);
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
            await genderService.RemoveGender(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
