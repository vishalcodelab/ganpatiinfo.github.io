using GanpatiBappa.Models;
using GanpatiBappa.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GanpatiBappa.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetDonationList()
        {
            DonationRepository repo = new DonationRepository();
            List<DonationModel> donationList;
            try
            {
                donationList= repo.GetAllDonationList();
            }
            catch (Exception ex)
            {

                throw;
            }
            return View(donationList);
        }
        public ActionResult GetExpensesList()
        {
            ExpenseRepository repo = new ExpenseRepository();
            List<ExpenseModel> expensesList;
            try
            {
                expensesList = repo.GetAllExpenseList();
            }
            catch (Exception ex)
            {

                throw;
            }
            return View(expensesList);
        }
        public ActionResult GetMembersList()
        {
            MemberRepository repo = new MemberRepository();
            List<MemberModel> membersList;
            try
            {
                membersList = repo.GetMemberList();
            }
            catch (Exception ex)
            {

                throw;
            }
            return View(membersList);
        }
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            var loginMassage = "";
            if (userName == "" && password == "")
            {
                loginMassage = "Login Faild !!";
                return Json(loginMassage, JsonRequestBehavior.AllowGet);
            }
            else
            {

                if (userName == "Vishal" && password == "Vishal@123")
                {
                    Session["username"] = userName;
                    Session["password"] = password;

                    loginMassage = "Login Successfully !!";

                }
                else
                {
                    loginMassage = "Login Faild !!";
                }
                return Json(loginMassage, JsonRequestBehavior.AllowGet);
            }


        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");

        }
    }
}