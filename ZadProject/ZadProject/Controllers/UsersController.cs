using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Dynamic;
using System.Security.Cryptography;
using ZadProject.Data;
using ZadProject.Models;

namespace ZadProject.Controllers
{
    public class UsersController : Controller
    {
        private readonly ZadDbContext _context;
        dynamic MyModel = new ExpandoObject();

        public UsersController(ZadDbContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public IActionResult UserAccount()
        //{
        //    if (HttpContext.Session.GetInt32("UserId") == null)
        //    {

        //        TempData["UserId"] = null;
        //    }
        //    else
        //    {
        //        TempData["UserId"] = HttpContext.Session.GetInt32("UserId");
        //    }

        //    var banks = _context.Banks.ToList();

        //    // Create a list of SelectListItem from your banks
        //    var banksNames = banks.Select(b => new SelectListItem
        //    {
        //        Text = b.BankName,
        //        Value = b.BankName // You can adjust Value property based on your requirement
        //    }).ToList();

        //    // Add an option for default selection
        //    banksNames.Insert(0, new SelectListItem
        //    {
        //        Text = "-- Select your bank --",
        //        Value = ""
        //    });

        //    ViewBag.BanksNames = banksNames;
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult UserAccount(UserAccountDto userAccountDto)
        //{
        //    if (HttpContext.Session.GetInt32("UserId") == null)
        //    {

        //        TempData["UserId"] = null;
        //    }
        //    else
        //    {
        //        TempData["UserId"] = HttpContext.Session.GetInt32("UserId");
        //    }

        //    var bankname = userAccountDto.BankName;
        //    var bankDealing = _context.Banks.FirstOrDefault(b => b.BankName == bankname);
        //    var bankid = bankDealing.BankId;
        //    var fees = 200;
        //    var newBalance = userAccountDto.AccountBalance - fees;
        //    userAccountDto.AccountBalance = newBalance;
        //    var userid = HttpContext.Session.GetInt32("UserId");
        //    var UserAccount = new UserAccount()
        //    {
        //        AccountBalance = userAccountDto.AccountBalance,
        //        CvvNumber = userAccountDto.CvvNumber,
        //        ExpireDate = userAccountDto.ExpireDate,
        //        UserAccountNumber = userAccountDto.UserAccountNumber,
        //        BankId = bankid,
        //        UserId = (int)userid,
        //        HolderName = userAccountDto.HolderName,
        //    };
        //    _context.UserAccounts.Add(UserAccount);
        //    _context.SaveChanges();

        //    return RedirectToAction("Login","Home");
        //}

        [HttpGet]
        public IActionResult UploadAuction()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            TempData["UserId"] = HttpContext.Session.GetInt32("UserId");
            return View();
        }

        [HttpGet]
        public IActionResult UploadOtherAuction()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            TempData["UserId"] = HttpContext.Session.GetInt32("UserId");
            var user = _context.Users.Where(a => a.UserId == HttpContext.Session.GetInt32("UserId")).FirstOrDefault();
            ViewBag.UserName = user.UserName;
            ViewBag.UserPhone = user.UserPhone;
            return View();
        }

        [HttpPost]
        public IActionResult UploadOtherAuction(OtherAuction AuctionOther, IFormCollection form)
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            TempData["UserId"] = HttpContext.Session.GetInt32("UserId");
            var image = form.Files["Auctionimage"];
            if (image != null && image.Length > 0)
            {
                var fileName = Path.GetFileName(image.FileName);
                var filePath = Path.Combine("wwwroot", "OtherAuctionImages", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyToAsync(stream);
                }
                var OtherAuction = new OtherAuction()
                {
                    AuctionCategory = AuctionOther.AuctionCategory,
                    AuctionCoverImage = fileName.ToString(),
                    AuctionDesctibtion = AuctionOther.AuctionDesctibtion,
                    AuctionStartDate = AuctionOther.AuctionStartDate,
                    AuctionEndDate = AuctionOther.AuctionEndDate,
                    AuctionProdutName = AuctionOther.AuctionProdutName,
                    AuctionStatus = Status.Pending,
                    AuctionStartPrice = AuctionOther.AuctionStartPrice,
                    MinimunSalePrice = AuctionOther.AuctionStartPrice,
                    OwnerName = AuctionOther.OwnerName,
                    OwnerPhone = AuctionOther.OwnerPhone,
                    VideoLink = AuctionOther.VideoLink
                    
                };

                _context.OtherAuctions.Add(OtherAuction);
                _context.SaveChanges();
                TempData["UploadMessage"] = "Your data has been Uploaded successfully and you can see it here after the approve of admin";
                return RedirectToAction("GetAllOtherAuctions");

            }
            else
            {
                TempData["UploadMessageError"] = "you should attach an image of the product you want to upload";
                return View(AuctionOther);
            }

        }

        [HttpGet]
        public IActionResult UploadCarAuction()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            TempData["UserId"] = HttpContext.Session.GetInt32("UserId");
            var user = _context.Users.Where(a => a.UserId == HttpContext.Session.GetInt32("UserId")).FirstOrDefault();
            ViewBag.UserName = user.UserName;
            ViewBag.UserPhone = user.UserPhone; 
            return View();
        }

        [HttpPost]
        public IActionResult UploadCarAuction(CarAuction AuctionCar, IFormCollection form)

        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            TempData["UserId"] = HttpContext.Session.GetInt32("UserId");
            var image = form.Files["AuctionImage"];
            if (image != null && image.Length > 0)
            {
                var fileName = Path.GetFileName(image.FileName);
                var filePath = Path.Combine("wwwroot", "CarAuctionImages", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyToAsync(stream);
                }
                var CarAuction = new CarAuction()
                {
                    Colors = AuctionCar.Colors,
                    MinimunSalePrice = AuctionCar.StartingPrice,
                    AccidentBefore = AuctionCar.AccidentBefore,
                    AuctionEndDate = AuctionCar.AuctionEndDate,
                    AuctionImage = fileName.ToString(),
                    AuctionStartDate = AuctionCar.AuctionStartDate,
                    AuctionStatus = Status.Pending,
                    CarModel = AuctionCar.CarModel,
                    Condition = AuctionCar.Condition,
                    FuelType = AuctionCar.FuelType,
                    NumberOfDoors = AuctionCar.NumberOfDoors,
                    StartingPrice = AuctionCar.StartingPrice,
                    TireCondition = AuctionCar.TireCondition,
                    TransmisssionType = AuctionCar.TransmisssionType,
                    YearOfManufacture = AuctionCar.YearOfManufacture,
                    AuctionType = "car",
                    NOK = AuctionCar.NOK,
                    VideoLink = AuctionCar.VideoLink,
                    NumberOfOwner = AuctionCar.NumberOfOwner,
                    OwnerName = AuctionCar.OwnerName,
                    OwnerPhone = AuctionCar.OwnerPhone,
                    TechnicalInspection = AuctionCar.TechnicalInspection,
                    Warranty = AuctionCar.Warranty
                    
                };

                _context.CarAuctions.Add(CarAuction);
                _context.SaveChanges();
                TempData["UploadMessage"] = "Your data has been Uploaded successfully and you can see it here after the approve of admin";
                return RedirectToAction("GetAllCarsAuctions");

            }
            else
            {
                TempData["UploadMessageError"] = "you should attach an image of the product you want to upload";
                return View(AuctionCar);
            }

        }

        [HttpGet]
        public IActionResult UploadRealStateAuction()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            TempData["UserId"] = HttpContext.Session.GetInt32("UserId");
            var user = _context.Users.Where(a => a.UserId == HttpContext.Session.GetInt32("UserId")).FirstOrDefault();
            ViewBag.UserName = user.UserName;
            ViewBag.UserPhone = user.UserPhone;
            return View();
        }

        [HttpPost]
        public IActionResult UploadRealStateAuction(RealStateAuction AuctionRealState, IFormCollection form)
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            TempData["UserId"] = HttpContext.Session.GetInt32("UserId");
            var image = form.Files["AuctionImage"];
            if (image != null && image.Length > 0)
            {
                var fileName = Path.GetFileName(image.FileName);
                var filePath = Path.Combine("wwwroot", "RealStateAuctionImages", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyToAsync(stream);
                }
                var RealStateAuction = new RealStateAuction()
                {
                    MinimunSalePrice = AuctionRealState.StartingPrice,
                    HouseSize = AuctionRealState.HouseSize,
                    HouseAddress = AuctionRealState.HouseAddress,
                    Condition = AuctionRealState.Condition,
                    AuctionEndDate = AuctionRealState.AuctionEndDate,
                    AuctionImage = fileName.ToString(),
                    AuctionStartDate = AuctionRealState.AuctionStartDate,
                    AuctionStatus = Status.Pending,
                    NumberOfBathrooms = AuctionRealState.NumberOfBathrooms,
                    NumberOfRooms = AuctionRealState.NumberOfRooms,
                    Parking = AuctionRealState.Parking,
                    StartingPrice = AuctionRealState.StartingPrice,
                    TypeOfProperty = AuctionRealState.TypeOfProperty,
                    YearOfBuild = AuctionRealState.YearOfBuild,
                    AuctionType = "RealState",
                    OwnerPhone = AuctionRealState.OwnerPhone,
                    OwnerName = AuctionRealState.OwnerName,
                    NumberOfFloors = AuctionRealState.NumberOfFloors,
                    VideoLink = AuctionRealState.VideoLink
                    

                };

                _context.RealStateAuctions.Add(RealStateAuction);
                _context.SaveChanges();
                TempData["UploadMessage"] = "Your data has been Uploaded successfully and you can see it here after the approve of admin";

                return RedirectToAction("GetAllRealStateAuctions");

            }
            else
            {
                TempData["UploadMessageError"] = "you should attach an image of the product you want to upload";
                return View(AuctionRealState);
            }

        }

        [HttpGet]
        public IActionResult GetAllRealStateAuctions() 
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            TempData["UserId"] = HttpContext.Session.GetInt32("UserId");
            var user = _context.Users.FirstOrDefault(a => a.UserId == HttpContext.Session.GetInt32("UserId"));
           
            var RealStateAuctions = _context.RealStateAuctions
                .Where(a => a.AuctionStatus == Status.Accepted && a.OwnerName != user.UserName && a.OwnerPhone != user.UserPhone).ToList();
            if(RealStateAuctions != null)
            {
                return View(RealStateAuctions);
            }
            return View();
        }

        [HttpGet]
        public IActionResult RealStateAuctionDetails(int id)
        {
            TempData["UserId"] = HttpContext.Session.GetInt32("UserId");

            var RealStateAuction = _context.RealStateAuctions.Where(ac => ac.RealStateAuctionId == id).FirstOrDefault();
            var BidingRealStateAuction = _context.BidingRealStateAuctions.Where(a => a.RealStateAuctionId == id).ToList();
            var RealStateAuctionDetails = new RealStateDetailsView
            {
                RealStateAuction = RealStateAuction,
                BidingStateAuction = BidingRealStateAuction
            };
            TempData["MinimumPriceRealState"] = 100000;
            ViewBag.RealStateAuctionId = id;
            return View(RealStateAuctionDetails);
        }

        [HttpPost]
        public IActionResult BidingOnRealStateAuction(RealStateDetailsView realStateDetailsView)
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            TempData["UserId"] = HttpContext.Session.GetInt32("UserId");

            var RealStateAuction = _context.RealStateAuctions
                .FirstOrDefault(a => a.RealStateAuctionId == realStateDetailsView.RealStateAuction.RealStateAuctionId);

            var MinimunPriceRealState = 100000;

            if (realStateDetailsView.BidNumber < MinimunPriceRealState)
            {

                TempData["BidingError"] = "this price is lower than the minimun acceptable range so your biding is rejected";
                return RedirectToAction("RealStateAuctionDetails", new { id = realStateDetailsView.RealStateAuction.RealStateAuctionId });

            }


            var BidingOnRealState = new BidingRealStateAuction()
            {
                BidingDate = DateTime.Now,
                BidingPrice = realStateDetailsView.BidNumber,
                RealStateAuctionId = realStateDetailsView.RealStateAuction.RealStateAuctionId,
                UserId = (int)HttpContext.Session.GetInt32("UserId")
            };
            RealStateAuction.StartingPrice += realStateDetailsView.BidNumber;

            _context.RealStateAuctions.Update(RealStateAuction);
            _context.BidingRealStateAuctions.Add(BidingOnRealState);
            _context.SaveChanges();
            TempData["BidingSuccess"] = "Your biding done successfully";

            return RedirectToAction("RealStateAuctionDetails", new { id = realStateDetailsView.RealStateAuction.RealStateAuctionId });
        }

        [HttpGet]
        public IActionResult GetAllCarsAuctions()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            TempData["UserId"] = HttpContext.Session.GetInt32("UserId");
            var user = _context.Users.FirstOrDefault(a => a.UserId == HttpContext.Session.GetInt32("UserId"));

            var auctions = _context.CarAuctions
                .Where(a => a.AuctionStatus == Status.Accepted && a.OwnerName != user.UserName && a.OwnerPhone != user.UserPhone).ToList();
            if (auctions != null)
            {
                return View(auctions);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CarAuctionDetails(int id)
        {
            TempData["UserId"] = HttpContext.Session.GetInt32("UserId");

            var CarAuction = _context.CarAuctions.Where(ac => ac.CarAuctionId == id).FirstOrDefault();
            var BidingCarAuction = _context.BidingCarAuctions.Where(a => a.CarAuctionId == id).ToList();
            var CarAuctionDetails = new CarDetailsView
            {
                CarAuction = CarAuction,
                BidingCarAuction = BidingCarAuction
            };
            TempData["MinimumPriceCar"] = 50000;
            ViewBag.CarAuctionId = id;
            return View(CarAuctionDetails);
        }

        [HttpPost]
        public IActionResult BidingOnCarAuction(CarDetailsView CarDetailsView)
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            TempData["UserId"] = HttpContext.Session.GetInt32("UserId");

            var CarAuction = _context.CarAuctions
                .FirstOrDefault(a => a.CarAuctionId == CarDetailsView.CarAuction.CarAuctionId);

            var MinimunPriceCar = 50000;

            if (CarDetailsView.BidNumber < MinimunPriceCar)
            {

                TempData["BidingError"] = "this price is lower than the minimun acceptable range so your biding is rejected";
                return RedirectToAction("CarAuctionDetails", new { id = CarDetailsView.CarAuction.CarAuctionId });

            }

            
            var BidingOnCar = new BidingCarAuction()
            {
                BidingDate = DateTime.Now,
                BidingPrice = CarDetailsView.BidNumber,
                CarAuctionId = CarDetailsView.CarAuction.CarAuctionId,
                UserId = (int)HttpContext.Session.GetInt32("UserId")
            };
            CarAuction.StartingPrice += CarDetailsView.BidNumber;

            _context.CarAuctions.Update(CarAuction);
            _context.BidingCarAuctions.Add(BidingOnCar);
            _context.SaveChanges();
            TempData["BidingSuccess"] = "Your biding done successfully";

            return RedirectToAction("CarAuctionDetails", new { id = CarDetailsView.CarAuction.CarAuctionId });
        }

        [HttpGet]
        public IActionResult GetAllOtherAuctions()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            TempData["UserId"] = HttpContext.Session.GetInt32("UserId");
            var user = _context.Users.FirstOrDefault(a => a.UserId == HttpContext.Session.GetInt32("UserId"));

            var auctions = _context.OtherAuctions
                .Where(a => a.AuctionStatus == Status.Accepted && a.OwnerName != user.UserName && a.OwnerPhone != user.UserPhone).ToList();
            if (auctions != null)
            {
                return View(auctions);
            }
            return View();
        }

        [HttpGet]
        public IActionResult OtherAuctionDetails(int id)
        {
            TempData["UserId"] = HttpContext.Session.GetInt32("UserId");

            var OtherAuctino = _context.OtherAuctions.Where(ac => ac.OtherAuctionId == id).FirstOrDefault();
            var BidingOtherAuction = _context.BidingOtherAuctions.Where(a => a.OtherAuctionId == id).ToList();
            var OtherAuctionDetails = new OtherDetailsView
            {
                OtherAuction = OtherAuctino,
                BidingOtherAuction = BidingOtherAuction
            };
            TempData["MinimumPriceOther"] = 20000;
            ViewBag.OtherAuctionId = id;
            return View(OtherAuctionDetails);
        }

        [HttpPost]
        public IActionResult BidingOnOtherAuction(OtherDetailsView OtherDetailsView)
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            TempData["UserId"] = HttpContext.Session.GetInt32("UserId");

            var OtherAuction = _context.OtherAuctions
                .FirstOrDefault(a => a.OtherAuctionId == OtherDetailsView.OtherAuction.OtherAuctionId);

            var MinimunPriceOther = 20000;

            if (OtherDetailsView.BidNumber < MinimunPriceOther)
            {

                TempData["BidingError"] = "this price is lower than the minimun acceptable range so your biding is rejected";
                return RedirectToAction("OtherAuctionDetails", new { id = OtherDetailsView.OtherAuction.OtherAuctionId });

            }


            var BidingOnOther = new BidingOtherAuction()
            {
                BidingDate = DateTime.Now,
                BidingPrice = OtherDetailsView.BidNumber,
                OtherAuctionId = OtherDetailsView.OtherAuction.OtherAuctionId,
                UserId = (int)HttpContext.Session.GetInt32("UserId")
            };
            OtherAuction.AuctionStartPrice += OtherDetailsView.BidNumber;

            _context.OtherAuctions.Update(OtherAuction);
            _context.BidingOtherAuctions.Add(BidingOnOther);
            _context.SaveChanges();
            TempData["BidingSuccess"] = "Your biding done successfully";

            return RedirectToAction("OtherAuctionDetails", new { id = OtherDetailsView.OtherAuction.OtherAuctionId });
        }

        [HttpGet]
        public IActionResult GetAllAuctions()
        {
            TempData["UserId"] = HttpContext.Session.GetInt32("UserId");

            var AllAuctions = new AllAuctions()
            {
               CarAuction = _context.CarAuctions.Where(a => a.AuctionStatus == Status.Accepted).ToList(),
               OtherAuction = _context.OtherAuctions.Where(a => a.AuctionStatus == Status.Accepted).ToList(),
               RealStateAuction = _context.RealStateAuctions.Where(a => a.AuctionStatus == Status.Accepted).ToList()
            };
            if (AllAuctions.OtherAuction != null && AllAuctions.CarAuction != null && AllAuctions.RealStateAuction != null)
            {
                return View(AllAuctions);
            }
            TempData["Message"] = "there is no avaliable auctions yet";
            return View(AllAuctions);
        }

        [HttpGet]
        public IActionResult UserDashboard(int id)
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            TempData["UserId"] = HttpContext.Session.GetInt32("UserId");

            var BidingCarAuction = _context.BidingCarAuctions.Where(a => a.UserId == HttpContext.Session.GetInt32("UserId")).ToList();
            var BuyingCarAuction = _context.BuyingCarAuctions.Where(a => a.UserId == HttpContext.Session.GetInt32("UserId")).ToList();
            var BidingOtherAuction = _context.BidingOtherAuctions.Where(a => a.UserId == HttpContext.Session.GetInt32("UserId")).ToList();
            var BuyingOtherAuction = _context.BuyingOtherAuctions.Where(a => a.UserId == HttpContext.Session.GetInt32("UserId")).ToList();
            var BidingRealStateAuction = _context.BidingRealStateAuctions.Where(a => a.UserId == HttpContext.Session.GetInt32("UserId")).ToList();
            var BuyingRealStateAuction = _context.BuyingRealStateAuctions.Where(a => a.UserId == HttpContext.Session.GetInt32("UserId")).ToList();
            var BidingNumber = BidingCarAuction.Count() + BidingOtherAuction.Count() + BidingRealStateAuction.Count();
            var BuyingNumber = BuyingCarAuction.Count() + BuyingOtherAuction.Count() + BuyingRealStateAuction.Count();

            var BidingCarAuctions = _context.BidingCarAuctions.Where(a => a.UserId == HttpContext.Session.GetInt32("UserId")).ToList();
            var BidingCarAuctinosDto = new List<BidingCarAuctionDto>();
            foreach (var item in BidingCarAuctions)
            {
                var BidingCarDto = new BidingCarAuctionDto()
                {
                    BidingCarAuction = item,
                    CarAuction = _context.CarAuctions.FirstOrDefault(a => a.CarAuctionId == item.CarAuctionId)
                };
                BidingCarAuctinosDto.Add(BidingCarDto);
            }

            var BidingOtherAuctions = _context.BidingOtherAuctions.Where(a => a.UserId == HttpContext.Session.GetInt32("UserId")).ToList();
            var BidingOthteAuctinosDto = new List<BidingOtherAuctionDto>();
            foreach (var item in BidingOtherAuctions)
            {
                var BidingOtherDto = new BidingOtherAuctionDto()
                {
                    BidingOtherAuction = item,
                    OtherAuction = _context.OtherAuctions.FirstOrDefault(a => a.OtherAuctionId == item.OtherAuctionId)
                };
                BidingOthteAuctinosDto.Add(BidingOtherDto);
            }

            var BidingRealStateAuctions = _context.BidingRealStateAuctions.Where(a => a.UserId == HttpContext.Session.GetInt32("UserId")).ToList();
            var BidingRealStateAuctionsDto = new List<BidingRealStateAuctionDto>();
            foreach (var item in BidingRealStateAuctions)
            {
                var BidingRealStateDto = new BidingRealStateAuctionDto()
                {
                    BidingRealStateAuction = item,
                    RealStateAuction = _context.RealStateAuctions.FirstOrDefault(a => a.RealStateAuctionId == item.RealStateAuctionId)
                };
                BidingRealStateAuctionsDto.Add(BidingRealStateDto);
            }

            var AllUserBiding = new AllUserBiding()
            {
                BidingCarAuctionDto = BidingCarAuctinosDto,
                BidingOtherAuctionDto = BidingOthteAuctinosDto,
                BidingRealStateAuctionDto = BidingRealStateAuctionsDto
            };

            var BuyingCarAuctions = _context.BuyingCarAuctions.Where(a => a.UserId == HttpContext.Session.GetInt32("UserId")).ToList();
            var BuyingCarAuctinosDto = new List<BuyingCarAuctionDto>();
            foreach (var item in BuyingCarAuctions)
            {
                var BuyingCarDto = new BuyingCarAuctionDto()
                {
                    BuyingCarAuction = item,
                    CarAuction = _context.CarAuctions.FirstOrDefault(a => a.CarAuctionId == item.CarAuctionId)
                };
                BuyingCarAuctinosDto.Add(BuyingCarDto);
            }

            var BuyingOtherAuctions = _context.BuyingOtherAuctions.Where(a => a.UserId == HttpContext.Session.GetInt32("UserId")).ToList();
            var BuyingOthteAuctinosDto = new List<BuyingOtherAuctionDto>();
            foreach (var item in BuyingOtherAuctions)
            {
                var BuyingOtherDto = new BuyingOtherAuctionDto()
                {
                    BuyingOtherAuction = item,
                    OtherAuction = _context.OtherAuctions.FirstOrDefault(a => a.OtherAuctionId == item.OtherAuctionId)
                };
                BuyingOthteAuctinosDto.Add(BuyingOtherDto);
            }

            var BuyingRealStateAuctions = _context.BuyingRealStateAuctions.Where(a => a.UserId == HttpContext.Session.GetInt32("UserId")).ToList();
            var BuyingRealStateAuctionsDto = new List<BuyingRealStateAuctionDto>();
            foreach (var item in BuyingRealStateAuctions)
            {
                var BuyingRealStateDto = new BuyingRealStateAuctionDto()
                {
                    BuyingRealStateAuction = item,
                    RealStateAuction = _context.RealStateAuctions.FirstOrDefault(a => a.RealStateAuctionId == item.RealStateAuctinoId)
                };
                BuyingRealStateAuctionsDto.Add(BuyingRealStateDto);
            }
            var AllUserBuying = new AllUserBuying()
            {
                BuyingCarAuctionDto = BuyingCarAuctinosDto,
                BuyingOtherAuctionDto = BuyingOthteAuctinosDto,
                BuyingRealStateAuctionDto = BuyingRealStateAuctionsDto
            };

            var user = _context.Users.First(a => a.UserId == HttpContext.Session.GetInt32("UserId"));
            var UserDto = new UserDto()
            {
                NationalIdImage = user.NationalIdImage,
                UserAddress = user.UserAddress,
                UserEmail = user.UserEmail,
                UserName = user.UserName,
                UserPassword = user.UserPassword,
                UserPhone = user.UserPhone,
            };

            var UserCarAuctions = _context.CarAuctions.Where(a => a.OwnerName == user.UserName && a.OwnerPhone == user.UserPhone).ToList();
            var UserOtherAuctions = _context.OtherAuctions.Where(a => a.OwnerName == user.UserName && a.OwnerPhone == user.UserPhone).ToList();
            var UserRealStateAuctions = _context.RealStateAuctions.Where(a => a.OwnerName == user.UserName && a.OwnerPhone == user.UserPhone).ToList();

            var UserDashboard = new UserDashboardViewModel()
            {
                BidingNumber = BidingNumber,
                BuyingNumber= BuyingNumber,
                AllUserBiding= AllUserBiding,
                AllUserBuying= AllUserBuying,
                User = UserDto,
                UserCarAuctions = UserCarAuctions,
                UserOtherAuctions = UserOtherAuctions,
                UserRealStateAuctions = UserRealStateAuctions
            };

            return View(UserDashboard);
        }

        [HttpPost]
        public IActionResult UserProfile(UserDto userDto, IFormCollection form)
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            TempData["UserId"] = HttpContext.Session.GetInt32("UserId");
            var existingUser = _context.Users.FirstOrDefault(a => a.UserId == HttpContext.Session.GetInt32("UserId"));
            var image = form.Files["image"];
            if (image != null && image.Length > 0)
            {
                var fileName = Path.GetFileName(image.FileName);
                var filePath = Path.Combine("wwwroot", "UserImages", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyToAsync(stream);
                }

                var user = new User()
                {
                    UserId = (int)HttpContext.Session.GetInt32("UserId"),
                    NationalIdImage = fileName.ToString(),
                    UserAddress = userDto.UserAddress,
                    UserEmail = userDto.UserEmail,
                    UserName = userDto.UserName,
                    UserPassword = userDto.UserPassword,
                    UserPhone = userDto.UserPhone,
                };
                _context.Users.Update(user);
                _context.SaveChanges();
                TempData["EditResult"] = "Your Profile Data Updated Successfully";
                return RedirectToAction("UserDashboard");

            }
            else
            {
                existingUser.UserId = (int)HttpContext.Session.GetInt32("UserId");
                existingUser.UserAddress = userDto.UserAddress;
                existingUser.UserEmail = userDto.UserEmail;
                existingUser.UserName = userDto.UserName;
                existingUser.UserPassword = userDto.UserPassword;
                existingUser.UserPhone = userDto.UserPhone;
                existingUser.NationalIdImage = existingUser.NationalIdImage;

                _context.Users.Update(existingUser);
                _context.SaveChanges();
                TempData["EditResult"] = "Your Profile Data Updated Successfully";
                return RedirectToAction("UserDashboard");
            }
        }

        [HttpPost]
        public IActionResult EndAuction(int auctionId, string auctionType)
        {
            if(auctionType == "Car")
            {
                try
                {
                    var WantedAuction = _context.CarAuctions.Where(a => a.CarAuctionId == auctionId).FirstOrDefault();
                    WantedAuction.AuctionStatus = Status.Complete;
                    var WinnerBidding = _context.BidingCarAuctions.Where(a => a.CarAuctionId == auctionId).OrderByDescending(a => a.BidingPrice).First();
                    var WinnerUser = _context.Users.Where(a => a.UserId == WinnerBidding.UserId).First();
                    var NewPurchaseRecord = new BuyingCarAuction()
                    {
                        CarAuctionId = auctionId,
                        UserId = WinnerUser.UserId
                    };
                    _context.CarAuctions.Update(WantedAuction);
                    _context.BuyingCarAuctions.Add(NewPurchaseRecord);
                    _context.SaveChanges();
                    return Json(new { success = true });
                }
                catch (Exception)
                {

                    return Json(new { success = false });
                }
            }
            else if(auctionType == "House")
            {
                try
                {
                    var WantedAuction = _context.RealStateAuctions.Where(a => a.RealStateAuctionId == auctionId).FirstOrDefault();
                    WantedAuction.AuctionStatus = Status.Complete;
                    var WinnerBidding = _context.BidingRealStateAuctions.Where(a => a.RealStateAuctionId == auctionId).OrderByDescending(a => a.BidingPrice).First();
                    var WinnerUser = _context.Users.Where(a => a.UserId == WinnerBidding.UserId).First();
                    var NewPurchaseRecord = new BuyingRealStateAuction()
                    {
                        RealStateAuctinoId = auctionId,
                        UserId = WinnerUser.UserId
                    };
                    _context.RealStateAuctions.Update(WantedAuction);
                    _context.BuyingRealStateAuctions.Add(NewPurchaseRecord);
                    _context.SaveChanges();
                    return Json(new { success = true });
                }
                catch (Exception)
                {

                    return Json(new { success = false });
                }
            }
            else
            {
                try
                {
                    var WantedAuction = _context.OtherAuctions.Where(a => a.OtherAuctionId == auctionId).FirstOrDefault();
                    WantedAuction.AuctionStatus = Status.Complete;
                    var WinnerBidding = _context.BidingOtherAuctions.Where(a => a.OtherAuctionId == auctionId).OrderByDescending(a => a.BidingPrice).First();
                    var WinnerUser = _context.Users.Where(a => a.UserId == WinnerBidding.UserId).First();
                    var NewPurchaseRecord = new BuyingOtherAuction()
                    {
                        OtherAuctionId = auctionId,
                        UserId = WinnerUser.UserId
                    };
                    _context.OtherAuctions.Update(WantedAuction);
                    _context.BuyingOtherAuctions.Add(NewPurchaseRecord);
                    _context.SaveChanges();
                    return Json(new { success = true });
                }
                catch (Exception)
                {

                    return Json(new { success = false });
                }
            }
        }

    }
}
