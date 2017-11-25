using ChitEngine.Models.Auth;
using ChitEngine.Models.Shared;
using ChitEngine.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace ChitEngine.Controllers
{
     [SessionState(SessionStateBehavior.Default)] 
    public class AuthController : Controller
    {
        //
        // GET: /Auth/
         //IAuthRepo _repo;
        public ActionResult Login()
        {
            return View();
        }
          
        // POST: /Auth/Delete/5
        [HttpPost]
        public JsonResult LoginAction(Repos.Models.LoginModel uDetails)
        {
           
            try
            {
                // TODO: Add delete logic here
                //return RedirectToAction("Login");
                
                AuthRepo _repo = new AuthRepo();                
                var ResultData =  _repo.GetUserAuthincate(uDetails);
                if (ResultData != null)
                {
                    Session["UserObj"] = ResultData;
                    var data = new
                    {
                        IsSuccess = true,
                        IsActive = ResultData.UserStatus,
                        IsAdmin = ResultData.IsAdmin                        
                    };
                    return Json(data);
                }
                else
                {
                    var data = new
                    {
                        IsSuccess = false,                        
                        ErrorMessage = "No user Found"
                    };
                    return Json(data);
                }
            }
            catch(Exception ex)
            {
                var data = new
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message.ToString()
                };
                return Json(data);
            }
           // return Json(true);
        }
    }
}
