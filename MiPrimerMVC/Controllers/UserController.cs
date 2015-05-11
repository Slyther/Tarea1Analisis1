using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Domain.Services;
using MiPrimerMVC.Models;
using Domain.Entities;

namespace MiPrimerMVC.Controllers
{
    public class UserController : Controller
    {
        readonly IReadOnlyRepository _readOnlyRepository;
        readonly IWriteOnlyRepository _writeOnlyRepository;

        public UserController(IReadOnlyRepository readOnlyRepository, IWriteOnlyRepository writeOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository;
            _writeOnlyRepository = writeOnlyRepository;
        }

        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Synergy");
            }
            return View(new AccountLoginModel());
        }
        
        [HttpPost]
        public ActionResult Login(AccountLoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = _readOnlyRepository.FirstOrDefault<User>(x => x.Email == model.Email);
                if (user != null)
                {
                    if (PasswordEncryptionService.CheckPassword(user, model.Password))
                    {
                        var ticket = new FormsAuthenticationTicket(1, user.Name, DateTime.Now, DateTime.Now.AddMinutes(30), model.RememberMe, user.Email, FormsAuthentication.FormsCookiePath);

                        // Encrypt the ticket.
                        string encTicket = FormsAuthentication.Encrypt(ticket);

                        // Create the cookie.
                        Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                        if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        return RedirectToAction("Index", "Synergy");
                    }
                }
                ModelState.AddModelError("", "The e-mail address or password provided is incorrect.");
            }
            return View(model);
        }

        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Synergy");
            }
            return View(new AccountRegisterModel());
        }
        
        [HttpPost]
        public ActionResult Register(AccountRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var testEmail = _readOnlyRepository.FirstOrDefault<User>(x => x.Email == model.Email);
                if (testEmail != null)
                {
                    ModelState.AddModelError("", "An account with that e-mail address already exists!");
                    return View(model);
                }
                var newUser = new User
                {
                    Email = model.Email,
                    Name = model.Name,
                    Password = model.Password,
                    IsAdmin = false
                };
                PasswordEncryptionService.Encrypt(newUser);
                _writeOnlyRepository.Create(newUser);
                return RedirectToAction("Login");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }
    }
}