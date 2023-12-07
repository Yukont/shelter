using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using shelter.Models;

namespace shelter.Controllers
{
    public class DonationController : Controller
    {
        IDonationService donationService;

        private readonly IMapper mapper;

        public DonationController(IDonationService donationService, IMapper mapper)
        {
            this.donationService = donationService;
            this.mapper = mapper;
        }


        // GET: AdoptionStatusController
        public async Task<ActionResult> Index()
        {
            IEnumerable<DonationDTO> donationDTO = await donationService.GetAllDonations();

            DonationIndexModel model = new();
            model.donationViewModels = mapper.Map<IEnumerable<DonationDTO>, IEnumerable<DonationViewModel>>(donationDTO);

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
        public async Task<ActionResult> CreateAsync(DonationViewModel donationViewModel)
        {
            try
            {
                DonationDTO donationDTO = mapper.Map<DonationViewModel, DonationDTO>(donationViewModel);
                await donationService.AddDonation(donationDTO);
                return RedirectToAction("Index", "Donation");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdoptionStatusController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            DonationDTO donationDTO = await donationService.GetDonationById(id);
            DonationViewModel donationViewModel = mapper.Map<DonationDTO, DonationViewModel>(donationDTO);
            return View(donationViewModel);
        }

        // POST: AdoptionStatusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(DonationViewModel donationViewModel)
        {
            try
            {
                DonationDTO donationDTO = mapper.Map<DonationViewModel, DonationDTO>(donationViewModel);
                await donationService.UpdateDonation(donationDTO);
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
            await donationService.RemoveDonation(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
