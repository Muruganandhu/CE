using ChitEngine.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChitEngine.Models;
using ChitEngine.Models.Shared;
using System.Data;
using ChitEngine.Models.Chit;


namespace ChitEngine.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/

        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Session["UserObj"] != null)
            {
                CustomerModel _cmb = new CustomerModel();
                _cmb = HelpersClass.Cast<CustomerModel>(System.Web.HttpContext.Current.Session["UserObj"]);
                ChitdetailRepo repo = new ChitdetailRepo();
                DataTable viewModel = repo.GetChitDetails(_cmb.CustomerId, _cmb.IsAdmin);
               IList<ChitDetailsModel> _result  =ChitEngine.Repos.DataTableExtensions.ToList<ChitDetailsModel>(viewModel);
               ViewBag.ProfileName = _cmb.FullName;
                return View(_result);
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        public ActionResult CreateChit()
        {
            return  View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateChitDB(Repos.Models.ParamModelChitUSer chitDetails)
        {
            if (System.Web.HttpContext.Current.Session["UserObj"] != null)
            {
                CustomerModel _cmb = new CustomerModel();
                _cmb = HelpersClass.Cast<CustomerModel>(System.Web.HttpContext.Current.Session["UserObj"]);
                ChitdetailRepo repo = new ChitdetailRepo();
                DataTable viewModel = repo.GetChitDetails(_cmb.CustomerId, _cmb.IsAdmin);
                IList<ChitDetailsModel> _result = ChitEngine.Repos.DataTableExtensions.ToList<ChitDetailsModel>(viewModel);
                ViewBag.ProfileName = _cmb.FullName;
                //return View(_result);
                string chitname = chitDetails.cname;
                decimal chitAmount = chitDetails.camount;
                decimal chitMonth = chitDetails.cmonth;
                decimal beetAmount = chitDetails.bamount;
                Repos.RepoLibrary.CustomerRepo objCust = new Repos.RepoLibrary.CustomerRepo();
                objCust.CreateChit(chitname, chitMonth, chitAmount, beetAmount,_cmb.CustomerId);
                return Json(true);
            }
            else
            {
                //return RedirectToAction("Login", "Auth");
                return Json(false);
            }
            
        }
        public ActionResult MapChitUser()
        {
            return View();
        }
        public ActionResult Edit(decimal id)
        {
            if (System.Web.HttpContext.Current.Session["UserObj"] != null)
            {
                CustomerModel _cmb = new CustomerModel();
                _cmb = HelpersClass.Cast<CustomerModel>(System.Web.HttpContext.Current.Session["UserObj"]);
                ViewBag.ProfileName = _cmb.FullName;
                return View(getChitDetails(id, _cmb.CustomerId, _cmb.IsAdmin));
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }           
        }
        public ActionResult Details(decimal id)
        {
            if (System.Web.HttpContext.Current.Session["UserObj"] != null)
            {
                CustomerModel _cmb = new CustomerModel();
                _cmb = HelpersClass.Cast<CustomerModel>(System.Web.HttpContext.Current.Session["UserObj"]);
                ViewBag.ProfileName = _cmb.FullName;
                return View(getChitDetails(id, _cmb.CustomerId, _cmb.IsAdmin));
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }   
        }
        private ChitDetailsModel getChitDetails(decimal id, decimal userId,bool isAdmin)
        {           
            ChitdetailRepo repo = new ChitdetailRepo();
            DataTable viewModel = repo.GetChitDetails(userId, isAdmin);
            var tempData = (from n in viewModel.AsEnumerable()
                            where n.Field<decimal>("ChitId").Equals(id)
                            select n).FirstOrDefault();
           return HelpersClass.CreateItemFromRow<ChitDetailsModel>(tempData);
        }
    }
}
