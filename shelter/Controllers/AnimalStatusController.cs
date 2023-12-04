using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using shelter.Models;

namespace shelter.Controllers
{
    public class AnimalStatusController : Controller
    {
        IAnimalStatusService animalStatusService;

        private readonly IMapper mapper;

        public AnimalStatusController(IAnimalStatusService animalStatusService, IMapper mapper)
        {
            this.animalStatusService = animalStatusService;
            this.mapper = mapper;
        }


        // GET: AdoptionStatusController
        public async Task<ActionResult> Index()
        {
            IEnumerable<AnimalStatusDTO> animalStatusDTO = await animalStatusService.GetAllAnimalStatus();

            AnimalStatusIndexModel model = new();
            model.animalStatusIndexModels = mapper.Map<IEnumerable<AnimalStatusDTO>, IEnumerable<AnimalStatusViewModel>>(animalStatusDTO);

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
        public async Task<ActionResult> CreateAsync(AnimalStatusViewModel animalStatusViewModel)
        {
            try
            {
                AnimalStatusDTO animalStatusDtoCreate = mapper.Map<AnimalStatusViewModel, AnimalStatusDTO>(animalStatusViewModel);
                await animalStatusService.AddAnimalStatus(animalStatusDtoCreate);
                return RedirectToAction("Index", "AnimalStatus");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdoptionStatusController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            AnimalStatusDTO animalStatusDto = await animalStatusService.GetAnimalSatusById(id);
            AnimalStatusViewModel animalStatusViewModel = mapper.Map<AnimalStatusDTO, AnimalStatusViewModel>(animalStatusDto);
            return View(animalStatusViewModel);
        }

        // POST: AdoptionStatusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AnimalStatusViewModel animalStatusViewModel)
        {
            try
            {
                AnimalStatusDTO animalStatusDTO = mapper.Map<AnimalStatusViewModel, AnimalStatusDTO>(animalStatusViewModel);
                await animalStatusService.UpdateAnimalStatus(animalStatusDTO);
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
            await animalStatusService.RemoveAnimalSatus(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
