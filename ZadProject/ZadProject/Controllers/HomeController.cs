using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text;
using ZadProject.Data;
using ZadProject.Models;
using System.Security.Cryptography;

namespace ZadProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ZadDbContext _context;

        public HomeController(ZadDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult HowItWork()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {

                TempData["UserId"] = null;
            }
            else
            {
                TempData["UserId"] = HttpContext.Session.GetInt32("UserId");
            }
            return View();
        }

        [HttpGet]
        public IActionResult AboutUs()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {

                TempData["UserId"] = null;
            }
            else
            {
                TempData["UserId"] = HttpContext.Session.GetInt32("UserId");
            }
            return View();
        }

        [HttpGet]
        public IActionResult HomePage()
        {
            if(HttpContext.Session.GetInt32("UserId") == null)
            {

                TempData["UserId"] = null; 
            }
            else
            {
                TempData["UserId"] = HttpContext.Session.GetInt32("UserId");
            }
            var AllAcceptedAuction = new AllAcceptedAuctions()
            {
                AcceptedCarAuctions = _context.CarAuctions.Where(a => a.AuctionStatus == Status.Accepted).ToList(),
                AcceptedOtherAuctions = _context.OtherAuctions.Where(a => a.AuctionStatus == Status.Accepted).ToList(),
                AcceptedRealStateAuctions = _context.RealStateAuctions.Where(a => a.AuctionStatus == Status.Accepted).ToList()
            };

            return View(AllAcceptedAuction);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LogingUserDto loginUserDto)
        {
            if (ModelState.IsValid)
            {
                if(loginUserDto.UserEmail == "admin@gmail.com" && loginUserDto.UserPassword == "adminadmin")
                {
                    return RedirectToAction("Index", "Admins");
                }
                var users = _context.Users.Where(z => z.UserEmail == loginUserDto.UserEmail && z.UserPassword == HashPassword(loginUserDto.UserPassword)).FirstOrDefault();
                if (users != null)
                {
                    if (loginUserDto.UserEmail == users.UserEmail && HashPassword(loginUserDto.UserPassword) == users.UserPassword)
                    {

                        HttpContext.Session.SetInt32("UserId", users.UserId);
                        TempData["UserId"] = HttpContext.Session.GetInt32("UserId");
                        TempData["LoginError"] = "Your password or email maybe incorrect";
                        return RedirectToAction("HomePage", "Home");
                    }
                }
                TempData["LoginError"] = "there is no user for this data";
                return View();
            }
            else
            {
                return View(loginUserDto);
            }
        }

        [HttpGet]
        public IActionResult SignUp()
        { return View(); }

        [HttpPost]
        public IActionResult SignUp(UserDto userDto, IFormCollection form)
        {
            var users = _context.Users.ToList();
            if (users.Any(a => a.UserEmail == userDto.UserEmail))
            {
                ViewBag.EmailError = "this email already exist ";
                return View(userDto);
            }
            if (users.Any(a => a.UserPhone == userDto.UserPhone))
            {
                ViewBag.PhoneError = "this phone already exist ";
                return View(userDto);
            }
            var image = form.Files["userimage"];
            if (image != null && image.Length > 0)
            {
                var fileName = Path.GetFileName(image.FileName);
                var filePath = Path.Combine("wwwroot", "UserImages", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyToAsync(stream);
                }
                
                var user = new User();
                user.NationalIdImage = fileName.ToString();
                user.UserPhone = userDto.UserPhone;
                user.UserName = userDto.UserName;
                user.UserPassword = HashPassword(userDto.UserPassword);
                
                user.UserEmail = userDto.UserEmail;
                user.UserAddress = userDto.UserAddress;

                _context.Users.Add(user);
                _context.SaveChanges();
                var userr = _context.Users.First(u => u.UserName == userDto.UserName);
                HttpContext.Session.SetInt32("UserId", userr.UserId);
                return RedirectToAction("Login","Home");

            }
            else
            {
                TempData["SignUpError"] = "you should upload an image for you";
                return View(userDto);
            }

        }

        [HttpGet]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("HomePage");
        }

        private static string HashPassword(string password)
        {
            byte[] passBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = new MD5CryptoServiceProvider().ComputeHash(passBytes);

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                stringBuilder.Append(hashBytes[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }
    }
}
