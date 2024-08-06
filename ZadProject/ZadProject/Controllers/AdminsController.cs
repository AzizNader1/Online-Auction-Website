using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using ZadProject.Data;
using ZadProject.Models;

namespace ZadProject.Controllers
{
    public class AdminsController : Controller
    {
        private readonly ZadDbContext _context;
        dynamic MyModel = new ExpandoObject();

        public AdminsController(ZadDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var PendingCarAuctionCount = _context.CarAuctions.Where(a => a.AuctionStatus == Status.Pending).ToList();
            var AcceptedCarAuctionCount = _context.CarAuctions.Where(a => a.AuctionStatus == Status.Accepted).ToList();
            var RejectedCarAuctionCount = _context.CarAuctions.Where(a => a.AuctionStatus == Status.Rejected).ToList();

            var PendingOtherAuctionCount = _context.OtherAuctions.Where(a => a.AuctionStatus == Status.Pending).ToList();
            var AcceptedOtherAuctionCount = _context.OtherAuctions.Where(a => a.AuctionStatus == Status.Accepted).ToList();
            var RejectedOtherAuctionCount = _context.OtherAuctions.Where(a => a.AuctionStatus == Status.Rejected).ToList();

            var PendingRealStateAuctionCount = _context.RealStateAuctions.Where(a => a.AuctionStatus == Status.Pending).ToList();
            var RejectedRealStateAuctionCount = _context.RealStateAuctions.Where(a => a.AuctionStatus == Status.Rejected).ToList();
            var AcceptedRealStateAuctionCount = _context.RealStateAuctions.Where(a => a.AuctionStatus == Status.Accepted).ToList();

            ViewBag.PendingNumber = PendingCarAuctionCount.Count() + PendingOtherAuctionCount.Count() + PendingRealStateAuctionCount.Count();
            ViewBag.AcceptedNumber = AcceptedCarAuctionCount.Count() + AcceptedOtherAuctionCount.Count() + AcceptedRealStateAuctionCount.Count();
            ViewBag.RejectedNumber = RejectedCarAuctionCount.Count() + RejectedOtherAuctionCount.Count() + RejectedRealStateAuctionCount.Count();

            return View();
        }

        [HttpGet]
        public IActionResult AcceptedAuctions() 
        {

            var AllAcceptedAuction = new AllAcceptedAuctions()
            {
                AcceptedCarAuctions = _context.CarAuctions.Where(a => a.AuctionStatus == Status.Accepted).ToList(),
                AcceptedOtherAuctions = _context.OtherAuctions.Where(a => a.AuctionStatus == Status.Accepted).ToList(),
                AcceptedRealStateAuctions = _context.RealStateAuctions.Where(a => a.AuctionStatus == Status.Accepted).ToList()
            };

            return View(AllAcceptedAuction);
        }

        [HttpGet]
        public IActionResult RejectedAuctions()
        {
            var AllRejectedAuction = new AllRejectedAuctions()
            {
                RejectedCarAuctions = _context.CarAuctions.Where(a => a.AuctionStatus == Status.Rejected).ToList(),
                RejectedOtherAuctions = _context.OtherAuctions.Where(a => a.AuctionStatus == Status.Rejected).ToList(),
                RejectedRealStateAuctions = _context.RealStateAuctions.Where(a => a.AuctionStatus == Status.Rejected).ToList()
            };

            return View(AllRejectedAuction);
        }

        [HttpGet]
        public IActionResult CompletedAuctions()
        {

            var AllCompletedAuction = new AllCompletedAuctions()
            {
                CompletedCarAuctions = _context.CarAuctions.Where(a => a.AuctionStatus == Status.Complete).ToList(),
                CompletedOtherAuctions = _context.OtherAuctions.Where(a => a.AuctionStatus == Status.Complete).ToList(),
                CompletedRealStateAuctions = _context.RealStateAuctions.Where(a => a.AuctionStatus == Status.Complete).ToList()
            };

            return View(AllCompletedAuction);
        }

        [HttpGet]
        public IActionResult CarCompletedAuctionDetails(int id)
        {
            return View(_context.CarAuctions.FirstOrDefault(a => a.CarAuctionId == id));
        }

        [HttpGet]
        public IActionResult OtherCompletedAuctionDetails(int id)
        {
            return View(_context.OtherAuctions.FirstOrDefault(a => a.OtherAuctionId == id));
        }

        [HttpGet]
        public IActionResult RealStateCompletedAuctionDetails(int id)
        {
            return View(_context.RealStateAuctions.FirstOrDefault(a => a.RealStateAuctionId == id));
        }

        [HttpGet]
        public IActionResult CarAuctionDetails(int id)
        {
            return View(_context.CarAuctions.FirstOrDefault(a => a.CarAuctionId == id));
        }

        [HttpGet]
        public IActionResult OtherAuctionDetails(int id)
        {
            return View(_context.OtherAuctions.FirstOrDefault(a => a.OtherAuctionId == id));
        }

        [HttpGet]
        public IActionResult RealStateAuctionDetails(int id)
        {
            return View(_context.RealStateAuctions.FirstOrDefault(a => a.RealStateAuctionId == id));
        }

        [HttpGet]
        public IActionResult PendingAuctions()
        {
            var AllPendingAuction = new AllPendingAuctions()
            {
                PendingCarAuctions = _context.CarAuctions.Where(a => a.AuctionStatus == Status.Pending).ToList(),
                PendingOtherAuctions = _context.OtherAuctions.Where(a => a.AuctionStatus == Status.Pending).ToList(),
                PendingRealStateAuctions = _context.RealStateAuctions.Where(a => a.AuctionStatus == Status.Pending).ToList()
            };

            return View(AllPendingAuction);
        }

        [HttpGet]
        public IActionResult CarAuctionDetailsForChangeStatus(int id)
        {
            return View(_context.CarAuctions.First(a => a.CarAuctionId == id));
        }

        [HttpPost]
        public IActionResult CarAuctionChangeStatusToAccept(int id)
        {
            var CarAuction = _context.CarAuctions.First(a => a.CarAuctionId == id);
            CarAuction.AuctionStatus = Models.Status.Accepted;
            _context.CarAuctions.Update(CarAuction);
            _context.SaveChanges();
            TempData["ActionResult"] = "Your Action done successfully";
            return RedirectToAction("PendingAuctions");
        }

        [HttpPost]
        public IActionResult CarAuctionChangeStatusToReject(int id)
        {
            var CarAuction = _context.CarAuctions.First(a => a.CarAuctionId == id);
            CarAuction.AuctionStatus = Models.Status.Rejected;
            _context.CarAuctions.Update(CarAuction);
            _context.SaveChanges();
            TempData["ActionResult"] = "Your Action done successfully";
            return RedirectToAction("PendingAuctions");
        }

        [HttpGet]
        public IActionResult OtherAuctionDetailsForChangeStatus(int id)
        {
            return View(_context.OtherAuctions.First(a => a.OtherAuctionId == id));
        }

        [HttpPost]
        public IActionResult OtherAuctionChangeStatusToAccept(int id)
        {
            var OtherAuction = _context.OtherAuctions.First(a => a.OtherAuctionId == id);
            OtherAuction.AuctionStatus = Models.Status.Accepted;
            _context.OtherAuctions.Update(OtherAuction);
            _context.SaveChanges();
            TempData["ActionResult"] = "Your Action done successfully";
            return RedirectToAction("PendingAuctions");
        }

        [HttpPost]
        public IActionResult OtherAuctionChangeStatusToReject(int id)
        {
            var OtherAuction = _context.OtherAuctions.First(a => a.OtherAuctionId == id);
            OtherAuction.AuctionStatus = Models.Status.Rejected;
            _context.OtherAuctions.Update(OtherAuction);
            _context.SaveChanges();
            TempData["ActionResult"] = "Your Action done successfully";
            return RedirectToAction("PendingAuctions");
        }

        [HttpGet]
        public IActionResult RealStateAuctionDetailsForChangeStatus(int id)
        {
            return View(_context.RealStateAuctions.First(a => a.RealStateAuctionId == id));
        }

        [HttpPost]
        public IActionResult RealStateAuctionChangeStatusToAccept(int id)
        {
            var RealStateAuction = _context.RealStateAuctions.FirstOrDefault(a => a.RealStateAuctionId == id);
            RealStateAuction.AuctionStatus = Models.Status.Accepted;
            _context.RealStateAuctions.Update(RealStateAuction);
            _context.SaveChanges();
            TempData["ActionResult"] = "Your Action done successfully";
            return RedirectToAction("PendingAuctions");
        }

        [HttpPost]
        public IActionResult RealStateAuctionChangeStatusToReject(int id)
        {
            var RealStateAuction = _context.RealStateAuctions.First(a => a.RealStateAuctionId == id);
            RealStateAuction.AuctionStatus = Models.Status.Rejected;
            _context.RealStateAuctions.Update(RealStateAuction);
            _context.SaveChanges();
            TempData["ActionResult"] = "Your Action done successfully";

            return RedirectToAction("PendingAuctions");
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _context.Users.ToList();
            if (users == null)
                ViewBag.error = "there is no users avalible yet";
            return View(users);
        }

        [HttpGet]
        public IActionResult UserDetails(int id)
        {
            return View(_context.Users.First(a => a.UserId == id));
        }

        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.SingleOrDefault(a => a.UserId == id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            TempData["ActionResult"] = "Your Action done successfully";
            HttpContext.Session.Clear();
            return View("GetAllUsers",_context.Users.ToList());
        }

        //[HttpGet]
        //public IActionResult GetAllPendingOtherAuctions()
        //{
        //    var auctions = _context.OtherAuctions.Where(z => z.AuctionStatus == Models.Status.Pending).ToList();
        //    if (auctions == null)
        //        ViewBag.error = "there is no auctions avalible yet";
        //    return View(auctions);
        //}
        //[HttpGet]
        //public IActionResult GetAllPendingCarAuctions()
        //{
        //    var auctions = _context.CarAuctions.Where(z => z.AuctionStatus == Models.Status.Pending).ToList();
        //    if (auctions == null)
        //        ViewBag.error = "there is no auctions avalible yet";
        //    return View(auctions);
        //}
        //[HttpGet]
        //public IActionResult GetAllPendingRealStateAuctions()
        //{
        //    var auctions = _context.RealStateAuctions.Where(z => z.AuctionStatus == Models.Status.Pending).ToList();
        //    if (auctions == null)
        //        ViewBag.error = "there is no auctions avalible yet";
        //    return View(auctions);
        //}
        //[HttpPost]
        //public IActionResult ChangeAuctionStatus(int id)
        //{
        //    return View();
        //}
        
    }
}
