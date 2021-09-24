using EmreCrm.Core.Caching;
using EmreCrm.Core.Extensions;
using EmreCrm.Core.Models;
using EmreCrm.Model.DbEntity;
using EmreCrm.Model.Model;
using EmreCrm.Service.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmreCrm.AdminUI.Controllers
{
    public class HomeController : Controller
    {
        #region Fields
        private readonly IUserService _userService;
        #endregion

        #region Ctor
        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Methods

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult Users_Read(int? page, int? rows)
        {
            List<UserModel> users = _userService.GetPagedList(page, rows);

            ViewBag.TotalRows = users.Count;

            return PartialView("_List", users);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(UserModel userModel)
        {
            AjaxReturnModel ajaxReturnModel = new AjaxReturnModel();

            if (!ModelState.IsValid)
            {
                ajaxReturnModel.IsSuccess = false;
                ajaxReturnModel.Message = "Eksik yada hatalı bilgi girdiniz. Lütfen düzelterek tekrar deneyiniz.";

                return Json(ajaxReturnModel);
            }

            ReturnModel<UserModel> returnModel = _userService.Add(userModel);

            ajaxReturnModel.IsSuccess = returnModel.IsSuccess;
            ajaxReturnModel.Message = returnModel.Message;
            ajaxReturnModel.Redirect = returnModel.Redirect;

            return Json(ajaxReturnModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            UserModel UserModel = _userService.GetById(id);

            if (UserModel == null)
                RedirectToAction("Index");

            return View(UserModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(UserModel userModel)
        {
            AjaxReturnModel ajaxReturnModel = new AjaxReturnModel();

            if (!ModelState.IsValid)
            {
                ajaxReturnModel.IsSuccess = false;
                ajaxReturnModel.Message = "Eksik yada hatalı bilgi girdiniz. Lütfen düzelterek tekrar deneyiniz.";

                return Json(ajaxReturnModel);
            }

            ReturnModel returnModel = _userService.Update(userModel);

            ajaxReturnModel.IsSuccess = returnModel.IsSuccess;
            ajaxReturnModel.Message = returnModel.Message;
            ajaxReturnModel.Redirect = returnModel.Redirect;

            return Json(ajaxReturnModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            AjaxReturnModel ajaxReturnModel = new AjaxReturnModel();

            ReturnModel returnModel = _userService.Delete(id);

            ajaxReturnModel.IsSuccess = returnModel.IsSuccess;
            ajaxReturnModel.Message = returnModel.Message;
            ajaxReturnModel.Redirect = returnModel.Redirect;

            return Json(ajaxReturnModel);
        }

        [Route("clear-memory")]
        public IActionResult ClearMemory()
        {
            _userService.ClearMemory();

            return RedirectToAction("Index");
        }
        #endregion
    }
}
