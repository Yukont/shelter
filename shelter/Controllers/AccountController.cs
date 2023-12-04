using BLL.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using shelter.Models;
using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using System.Collections.Generic;

namespace shelter.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        private readonly IUserGenderService userGenderService;
        private readonly IMapper mapper;

        public AccountController(IAccountService accountService, IUserGenderService userGenderService, IMapper mapper)
        {
            this.accountService = accountService;
            this.userGenderService = userGenderService;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel authViewModel)
        {
            if (ModelState.IsValid)
            {
                AuthDTO authDTO = mapper.Map<RegisterViewModel, AuthDTO>(authViewModel);

                if (await accountService.CheakLoginAsync(authDTO.Login))
                {
                    TempData["AuthDTO_Login"] = authDTO.Login;
                    TempData["AuthDTO_Password"] = authDTO.Password;
                    return RedirectToAction("Create");
                }
                ModelState.AddModelError("", "Пользователь уже есть");
            }
            return View(authViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            UserViewModel userCreate = new()
            {
                UserGenders = await GetUserGenders()
            };
            return View(userCreate);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                if (TempData["AuthDTO_Login"] is string authDTO_login && TempData["AuthDTO_Password"] is string authDTO_password)
                {
                    AuthDTO authDTO = new AuthDTO { Login = authDTO_login, Password = authDTO_password }; 
                    UserDTO userDTO = mapper.Map<UserViewModel, UserDTO>(userViewModel);

                    var response = await accountService.Register(authDTO, userDTO);
                    if (response is ClaimsIdentity)
                    {
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(response));

                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", "Пользователь уже есть");
                }
            }

            // В случае невалидной модели повторно передайте UserGenders в представление
            userViewModel.UserGenders = await GetUserGenders(); // Получите список пользовательских полов

            return View(userViewModel);
        }

        private async Task<IEnumerable<UserGenderViewModel>> GetUserGenders()
        {
            IEnumerable<UsersGenderDTO> userGenderDto = await userGenderService.GetAllUserGender();
            return mapper.Map<IEnumerable<UsersGenderDTO>, IEnumerable<UserGenderViewModel>>(userGenderDto);
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel authViewModel)
        {
            if (ModelState.IsValid)
            {
                AuthDTO authDTO = mapper.Map<LoginViewModel, AuthDTO>(authViewModel);

                var response = await accountService.Login(authDTO);
                if (response is ClaimsIdentity)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(response));

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Не верный логин");
            }
            return View(authViewModel);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
