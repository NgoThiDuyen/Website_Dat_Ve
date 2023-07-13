using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Website_Dat_Ve.Models;

namespace Website_Dat_Ve.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginVM model)
        {
            var _httpClient = MyHttpClient.Instance;
            var apiUrl = _httpClient.BaseAddress + "api/UserAuthenticate/UserLogin";
            var loginRequest = new
            {
                username = model.Username,
                password = model.Password
            };

            // Gửi yêu cầu POST đến API
            var response = await _httpClient.PostAsJsonAsync(apiUrl, loginRequest);
            if (response.IsSuccessStatusCode)
            {
                var loginResult = await response.Content.ReadAsAsync<UserResponse>();

                if (loginResult != null && loginResult.Code == "Oke")
                {
                    UserVM login = new UserVM();
                    login = loginResult.Data.User;
                    Session["UserId"] = login.Id;
                    Session["Username"] = login.Username;
                    Session["Name"] = login.Name;
                    Session["Email"] = login.Email;
                    Session["Phone"] = login.NumberPhone;
                    Session["Token"] = loginResult.Data.Token;
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Thông tin tài khoản mật khẩu không chính xác");
            return View(model);
        }

        public ActionResult Logout()
        {
            Session["UserId"] = null;
            Session["Username"] = null;
            Session["Name"] = null;
            Session["Email"] = null;
            Session["Phone"] = null;
            Session["Token"] = null;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(UserVM model)
        {
            var _httpClient = MyHttpClient.Instance;
            var apiUrl = _httpClient.BaseAddress + "api/UserAuthenticate/UserRegister";
            var registerRequest = new
            {
                name = model.Name,
                numberPhone = model.NumberPhone,
                address = model.Address,
                email = model.Email,
                password = model.Password,
            };

            // Gửi yêu cầu POST đến API
            var response = await _httpClient.PostAsJsonAsync(apiUrl, registerRequest);
            if (response.IsSuccessStatusCode)
            {
                var registerResult = await response.Content.ReadAsAsync<UserResponse>();

                if (registerResult != null && registerResult.Code == "Oke")
                {
                    return RedirectToAction("Login", "User");
                }
            }

            ModelState.AddModelError("", "Đăng ký thất bại!");
            return View(model);
        }


    }
}