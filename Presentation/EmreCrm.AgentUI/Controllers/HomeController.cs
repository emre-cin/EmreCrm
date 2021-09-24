//using EmreCrm.AgentUI.Helper;
//using EmreCrm.Core.Extensions;
//using EmreCrm.Core.Models;
//using EmreCrm.Model.Enum;
//using EmreCrm.Model.Model;
//using EmreCrm.Model.Model.File;
//using EmreCrm.Service.AdvertisementService;
//using EmreCrm.Service.AgentService;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Threading.Tasks;

//namespace EmreCrm.AgentUI.Controllers
//{
//    public class HomeController : Controller
//    {
//        #region Fields
//        private readonly IAgentService _userService;
//        private readonly IAdvertisementService _advertisementService;
//        private readonly IAppContext _appContext;
//        private readonly IHttpContextAccessor _httpContextAccessor;
//        private ISession _session => _httpContextAccessor.HttpContext.Session;
//        #endregion

//        #region Ctor
//        public HomeController(IAgentService agentService,
//          IAdvertisementService advertisementService,
//          IHttpContextAccessor httpContextAccessor,
//          IAppContext appContext)
//        {
//            _userService = agentService;
//            _advertisementService = advertisementService;
//            _appContext = appContext;
//            _httpContextAccessor = httpContextAccessor;
//        }
//        #endregion

//        #region Methods
//        public IActionResult Index()
//        {
//            AdvertisementFilterModel advertisementModel = new AdvertisementFilterModel();

//            advertisementModel.UsableTypes.Add(new SelectListItem() { Text = "Seçiniz" });

//            foreach (HouseType type in (HouseType[])Enum.GetValues(typeof(HouseType)))
//            {
//                advertisementModel.UsableTypes.Add(new SelectListItem() { Text = type.GetEnumDescription(), Value = type.GetHashCode().ToString() });
//            }

//            return View(advertisementModel);
//        }

//        public PartialViewResult Advertisement_Read(AdvertisementFilterModel filterModel, int? page, int? rows, bool filter = false)
//        {
//            filterModel.AgentId = _appContext.Agent.Id;

//            List<AdvertisementModel> advertisement = _advertisementService.GetPagedList(filterModel, page, rows, filter);

//            ViewBag.TotalRows = advertisement.Count;

//            return PartialView("_List", advertisement);
//        }

//        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
//        public IActionResult Login(LoginModel model)
//        {
//            AjaxReturnModel ajaxReturnModel = new AjaxReturnModel();

//            try
//            {
//                UserModel UserModel = _userService.Login(model);

//                if (UserModel != null)
//                {
//                    List<Claim> claims = new List<Claim>
//                    {
//                        new Claim(ClaimTypes.Email, UserModel.UserName),
//                        new Claim(ClaimTypes.Expiration, TimeSpan.FromHours(2).ToString()),
//                        new Claim("Agent", JsonConvert.SerializeObject(UserModel))
//                    };

//                    var agentIdentity = new ClaimsIdentity(claims, "login");

//                    ClaimsPrincipal principal = new ClaimsPrincipal(agentIdentity);

//                    HttpContext.SignInAsync(principal);

//                    ajaxReturnModel.IsSuccess = true;
//                    ajaxReturnModel.Message = "Giriş gerçekleştirildi. Yönlendiriliyorsunuz..";
//                    ajaxReturnModel.Redirect = "/Home/Index";
//                }
//                else
//                {
//                    ajaxReturnModel.IsSuccess = false;
//                    ajaxReturnModel.Message = "Girmiş olduğunuz bilgilere ait hesap bulunamadı";
//                }
//            }
//            catch (Exception ex)
//            {
//                ajaxReturnModel.IsSuccess = false;
//                ajaxReturnModel.Message = "Bilinmeyen bir hata oluştu";
//            }

//            return Ok(ajaxReturnModel);
//        }

//        [HttpGet, AllowAnonymous]
//        public IActionResult Login()
//        {
//            if (User.Claims != null && User.Claims.Any())
//                return RedirectToAction("Index");

//            return View();
//        }

//        [HttpGet]
//        public async Task<IActionResult> Logout()
//        {
//            if (User.Claims == null || !User.Claims.Any())
//                return Redirect("/Home/Login");

//            if (_session.GetComplexData<UserModel>("Agent") != null)
//                _session.Remove("Agent");

//            await HttpContext.SignOutAsync();

//            return Redirect("/Home/Login");
//        }

//        [HttpGet]
//        public IActionResult AddAdvertisement()
//        {
//            AdvertisementModel advertisementModel = new AdvertisementModel();

//            foreach (HouseType type in (HouseType[])Enum.GetValues(typeof(HouseType)))
//            {
//                advertisementModel.UsableTypes.Add(new SelectListItem() { Text = type.GetEnumDescription(), Value = type.GetHashCode().ToString() });
//            }

//            return View(advertisementModel);
//        }

//        [HttpPost, ValidateAntiForgeryToken]
//        public IActionResult AddAdvertisement(AdvertisementModel advertisementModel, List<IFormFile> photos = null)
//        {
//            AjaxReturnModel ajaxReturnModel = new AjaxReturnModel();

//            UserModel UserModel = _appContext.Agent;

//            if (!ModelState.IsValid)
//            {
//                ajaxReturnModel.IsSuccess = false;
//                ajaxReturnModel.Message = "Eksik yada hatalı bilgi girdiniz. Lütfen düzelterek tekrar deneyiniz.";

//                return Json(ajaxReturnModel);
//            }

//            if (UserModel == null)
//            {
//                ajaxReturnModel.IsSuccess = false;
//                ajaxReturnModel.Message = "Firma tespit edilemedi.";

//                return Json(ajaxReturnModel);
//            }

//            advertisementModel.AgentId = UserModel.Id;

//            ReturnModel returnModel = _advertisementService.Add(advertisementModel, photos);

//            ajaxReturnModel.IsSuccess = returnModel.IsSuccess;
//            ajaxReturnModel.Message = returnModel.Message;
//            ajaxReturnModel.Redirect = returnModel.Redirect;

//            return Json(ajaxReturnModel);
//        }

//        [HttpGet]
//        public IActionResult EditAdvertisement(int id)
//        {
//            AdvertisementModel advertisementModel = _advertisementService.GetById(id);

//            if (advertisementModel == null)
//                RedirectToAction("Index");

//            foreach (HouseType type in (HouseType[])Enum.GetValues(typeof(HouseType)))
//            {
//                advertisementModel.UsableTypes.Add(new SelectListItem() { Text = type.GetEnumDescription(), Value = type.GetHashCode().ToString() });
//            }

//            List<AdvertisementPhotoModel> advertisementPhotoModels = _advertisementService.GetPhotoByAdvertisementId(id);

//            List<InitialPreviewConfig> pictureConfig = (from p in advertisementPhotoModels
//                                                        select
//                     new InitialPreviewConfig
//                     {
//                         Caption = p.Url.Split('.')[0],
//                         DownloadUrl = $"/uploads/{p.Url}",
//                         Key = p.Id,
//                         Width = "120px",

//                     }).ToList();

//            FileInput fileInput = new FileInput()
//            {
//                InitialPreview = advertisementPhotoModels.Select(x => "/uploads/" + x.Url).ToList(),
//                InitialPreviewConfig = pictureConfig
//            };

//            advertisementModel.FileInput = JsonConvert.SerializeObject(fileInput);

//            return View(advertisementModel);
//        }

//        [HttpPost, ValidateAntiForgeryToken]
//        public IActionResult EditAdvertisement(AdvertisementModel advertisementModel, List<IFormFile> photos = null)
//        {
//            AjaxReturnModel ajaxReturnModel = new AjaxReturnModel();

//            if (!ModelState.IsValid)
//            {
//                ajaxReturnModel.IsSuccess = false;
//                ajaxReturnModel.Message = "Eksik yada hatalı bilgi girdiniz. Lütfen düzelterek tekrar deneyiniz.";

//                return Json(ajaxReturnModel);
//            }

//            ReturnModel returnModel = _advertisementService.Update(advertisementModel, photos);

//            ajaxReturnModel.IsSuccess = returnModel.IsSuccess;
//            ajaxReturnModel.Message = returnModel.Message;
//            ajaxReturnModel.Redirect = returnModel.Redirect;

//            return Json(ajaxReturnModel);
//        }

//        [HttpGet]
//        public IActionResult Profile()
//        {
//            UserModel agent = _userService.GetById(_appContext.Agent.Id);

//            return View(agent);
//        }

//        [HttpPost, ValidateAntiForgeryToken]
//        public IActionResult Profile(UserModel UserModel, IFormFile companyLogo)
//        {
//            AjaxReturnModel ajaxReturnModel = new AjaxReturnModel();

//            if (!ModelState.IsValid)
//            {
//                ajaxReturnModel.IsSuccess = false;
//                ajaxReturnModel.Message = "Eksik yada hatalı bilgi girdiniz. Lütfen düzelterek tekrar deneyiniz.";

//                return Json(ajaxReturnModel);
//            }

//            ReturnModel returnModel = _userService.Update(UserModel, companyLogo);

//            ajaxReturnModel.IsSuccess = returnModel.IsSuccess;
//            ajaxReturnModel.Message = returnModel.Message;
//            ajaxReturnModel.Redirect = "/profilim";

//            return Json(ajaxReturnModel);
//        }

//        [HttpPost]
//        public IActionResult DeleteAdvertisement(int id)
//        {
//            AjaxReturnModel ajaxReturnModel = new AjaxReturnModel();

//            ReturnModel returnModel = _advertisementService.Delete(id);

//            ajaxReturnModel.IsSuccess = returnModel.IsSuccess;
//            ajaxReturnModel.Message = returnModel.Message;
//            ajaxReturnModel.Redirect = returnModel.Redirect;

//            return Json(ajaxReturnModel);
//        }

//        [HttpPost]
//        public IActionResult DeleteAdvertisementPhoto(int key)
//        {
//            AjaxReturnModel ajaxReturnModel = new AjaxReturnModel();

//            ReturnModel returnModel = _advertisementService.DeleteAdvertisementPhoto(key);

//            ajaxReturnModel.IsSuccess = returnModel.IsSuccess;
//            ajaxReturnModel.Message = ajaxReturnModel.Message;

//            return Json(ajaxReturnModel);
//        }
//        #endregion
//    }
//}