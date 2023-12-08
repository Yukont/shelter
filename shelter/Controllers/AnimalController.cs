using AutoMapper;
using BLL.DTO;
using BLL.ImgWork;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using shelter.Models;

namespace shelter.Controllers
{
    public class AnimalController : Controller
    {
        IAnimalService animalService;
        ISpeciesService speciesService;
        IGenderService genderService;
        IAnimalStatusService animalStatusService;
        IStatusOfHealthService statusOfHealthService;
        IAdoptionApplicationService adoptionApplicationService;

        private readonly IMapper mapper;

        private readonly IWebHostEnvironment hostingEnvironment;

        public AnimalController(IAnimalService animalService, IMapper mapper, IWebHostEnvironment hostingEnvironment,ISpeciesService speciesService, IGenderService genderService, IAnimalStatusService animalStatusService, IStatusOfHealthService statusOfHealthService, IAdoptionApplicationService adoptionApplicationService)
        {
            this.animalService = animalService;
            this.mapper = mapper;
            this.hostingEnvironment = hostingEnvironment;
            this.genderService = genderService;
            this.speciesService = speciesService;
            this.animalStatusService = animalStatusService;
            this.statusOfHealthService = statusOfHealthService;
            this.adoptionApplicationService = adoptionApplicationService;
        }

        // GET: AdoptionStatusController
        public async Task<ActionResult> Index(int id = 0)
        {
            IEnumerable<AnimalDTO> animalDTO;
            if (id == 0)
            {
                animalDTO = await animalService.GetAllAnimals();
            }
            else
            {
                animalDTO = await animalService.GetAllAnimalsByIdSpecies(id);
            }

            AnimalIndexModel model = new();
            model.animalViewModels = mapper.Map<IEnumerable<AnimalDTO>, IEnumerable<AnimalViewModel>>(animalDTO);
            model.speciesViewModels = await GetSpecies();

            return View(model);
        }

        public async Task<ActionResult> Filter(int id)
        {
            // Используйте RedirectToAction для перенаправления с параметром id в Index
            return RedirectToAction("Index", "Animal", new { id });
        }


        // GET: AdoptionStatusController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            AnimalDTO animalDTO = await animalService.GetAnimalId(id);
            animalDTO.adoptionApplicationViewModels = await adoptionApplicationService.GetAllAdoptionApplicationsByAnimalId(animalDTO.Id);
            AnimalViewModel animalViewModel = mapper.Map<AnimalDTO, AnimalViewModel>(animalDTO);
            return View(animalViewModel);
        }

        // GET: AdoptionStatusController/Create
        public async Task<ActionResult> CreateAsync()
        {
            AnimalViewModel animalCreate = new()
            {
                speciesViewModels = await GetSpecies(),
                genderViewModels = await GetGenders(),
                animalStatusViewModels = await GetAnimalStatus(),
                statusOfHealthViewModels = await GetStatusOfHealth()
            };
            return View(animalCreate);
        }

        // POST: AdoptionStatusController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(AnimalViewModel animalViewModel, IFormFile imageFile)
        {
            try
            {
                ImgService img = new();
                string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                string imagePath = await img.ProcessImage(imageFile, uploadFolder);

                AnimalDTO animalDTO = mapper.Map<AnimalViewModel, AnimalDTO>(animalViewModel);
                animalDTO.Photo = imagePath;
                await animalService.AddAnimal(animalDTO);
                return RedirectToAction("Index", "Animal");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdoptionStatusController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            AnimalDTO animalDTO = await animalService.GetAnimalId(id);
            AnimalViewModel animalViewModel = mapper.Map<AnimalDTO, AnimalViewModel>(animalDTO);
            animalViewModel.speciesViewModels = await GetSpecies();
            animalViewModel.genderViewModels = await GetGenders();
            animalViewModel.animalStatusViewModels = await GetAnimalStatus();
            animalViewModel.statusOfHealthViewModels = await GetStatusOfHealth();

            return View(animalViewModel);
        }

        // POST: AdoptionStatusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AnimalViewModel AnimalViewModel, IFormFile imageFile)
        {
            try
            {
                ImgService img = new();
                string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                string imagePath = await img.ProcessImage(imageFile, uploadFolder);

                AnimalDTO animalDTO = mapper.Map<AnimalViewModel, AnimalDTO>(AnimalViewModel);
                animalDTO.Photo = imagePath;
                await animalService.UpdateAnimal(animalDTO);
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
            await animalService.RemoveAnimal(id);
            return RedirectToAction(nameof(Index));
        }
        private async Task<IEnumerable<SpeciesViewModel>> GetSpecies()
        {
            IEnumerable<SpeciesDTO> speciesDTOs = await speciesService.GetAllSpeciess();
            return mapper.Map<IEnumerable<SpeciesDTO>, IEnumerable<SpeciesViewModel>>(speciesDTOs);
        }
        private async Task<IEnumerable<GenderViewModel>> GetGenders()
        {
            IEnumerable<GenderDTO> genderDto = await genderService.GetAllGenders();
            return mapper.Map<IEnumerable<GenderDTO>, IEnumerable<GenderViewModel>>(genderDto);
        }
        private async Task<IEnumerable<AnimalStatusViewModel>> GetAnimalStatus()
        {
            IEnumerable<AnimalStatusDTO> animalStatusDto = await animalStatusService.GetAllAnimalStatus();
            return mapper.Map<IEnumerable<AnimalStatusDTO>, IEnumerable<AnimalStatusViewModel>>(animalStatusDto);
        }
        private async Task<IEnumerable<StatusOfHealthViewModel>> GetStatusOfHealth()
        {
            IEnumerable<StatusOfHealthDTO> statusOfhealthDto = await statusOfHealthService.GetAllStatusOfHealths();
            return mapper.Map<IEnumerable<StatusOfHealthDTO>, IEnumerable<StatusOfHealthViewModel>>(statusOfhealthDto);
        }
    }
}
