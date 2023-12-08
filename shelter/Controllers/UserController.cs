using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using shelter.Models;

namespace shelter.Controllers
{
    public class UserController : Controller
    {
        IUserService userService;

        private readonly IMapper mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }


        // GET: AdoptionStatusController
        public async Task<ActionResult> Index()
        {
            IEnumerable<UserDTO> userDTO = await userService.GetAllUsers();

            UserIndexModel model = new();
            model.userViewModels = mapper.Map<IEnumerable<UserDTO>, IEnumerable<UserViewModel>>(userDTO);

            return View(model);
        }

        // GET: AdoptionStatusController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            UserDTO userDTO = await userService.GetUserById(id);
            UserViewModel userViewModel = mapper.Map<UserDTO, UserViewModel>(userDTO);
            return View(userViewModel);
        }

        // GET: AdoptionStatusController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdoptionStatusController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(UserViewModel userViewModel)
        {
            try
            {
                UserDTO userDTO = mapper.Map<UserViewModel, UserDTO>(userViewModel);
                await userService.AddUser(userDTO);
                return RedirectToAction("Index", "User");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdoptionStatusController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            UserDTO userDTO = await userService.GetUserById(id);
            UserViewModel userViewModel = mapper.Map<UserDTO, UserViewModel>(userDTO);
            return View(userViewModel);
        }

        // POST: AdoptionStatusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserViewModel UserViewModel)
        {
            try
            {
                UserDTO userDTO = mapper.Map<UserViewModel, UserDTO>(UserViewModel);
                await userService.UpdateUser(userDTO);
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
            await userService.RemoveUser(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
