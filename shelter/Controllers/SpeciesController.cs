using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using shelter.Models;

namespace shelter.Controllers
{
    public class SpeciesController : Controller
    {
        ISpeciesService speciesService;

        private readonly IMapper mapper;

        public SpeciesController(ISpeciesService speciesService, IMapper mapper)
        {
            this.speciesService = speciesService;
            this.mapper = mapper;
        }


        // GET: AdoptionStatusController
        public async Task<ActionResult> Index()
        {
            IEnumerable<SpeciesDTO> speciesDTO = await speciesService.GetAllSpeciess();

            SpeciesIndexModel model = new();
            model.speciesViewModels = mapper.Map<IEnumerable<SpeciesDTO>, IEnumerable<SpeciesViewModel>>(speciesDTO);

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
        public async Task<ActionResult> CreateAsync(SpeciesViewModel speciesViewModel)
        {
            try
            {
                SpeciesDTO speciesDTO = mapper.Map<SpeciesViewModel, SpeciesDTO>(speciesViewModel);
                await speciesService.AddSpecies(speciesDTO);
                return RedirectToAction("Index", "Species");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdoptionStatusController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            SpeciesDTO speciesDTO = await speciesService.GetSpeciesId(id);
            SpeciesViewModel speciesViewModel = mapper.Map<SpeciesDTO, SpeciesViewModel>(speciesDTO);
            return View(speciesViewModel);
        }

        // POST: AdoptionStatusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SpeciesViewModel SpeciesViewModel)
        {
            try
            {
                SpeciesDTO speciesDTO = mapper.Map<SpeciesViewModel, SpeciesDTO>(SpeciesViewModel);
                await speciesService.UpdateSpecies(speciesDTO);
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
            await speciesService.RemoveSpecies(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
