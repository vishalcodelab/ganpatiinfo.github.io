using GanpatiBappa.Models;
using GanpatiBappa.Models.ViewModel;
using GanpatiBappa.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GanpatiBappa.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
            {
            DonationRepository donationRepo = new DonationRepository();
            ExpenseRepository expenseRepo = new ExpenseRepository();
            vmDashboard obj = new vmDashboard();
            try
            {
                if (Session["username"] == null)
                {
                    return RedirectToAction("Index","Home");
                }

                List<int> countList = new List<int>();
                var donationList = donationRepo.GetAllDonationList();
               
                obj.TotalDonations = donationList.Sum(dontion => dontion.donateAmount);
                obj.TotalExpenses = expenseRepo.GetAllExpenseList().Sum(expense => expense.expenseAmount);
                obj.TotalSaveAmount = obj.TotalDonations - obj.TotalExpenses;
                obj.TotalByCash = donationList.Where(x => x.PaymentBy == "Cash").Sum(x => x.donateAmount);
                obj.TotalByOnline = donationList.Where(x => x.PaymentBy == "Online").Sum(x => x.donateAmount);
                obj.TotalDonaters = donationList.Count();
                var highestdonaterAmount= donationList.Max(x => x.donateAmount);
                obj.highestdonateAmount = highestdonaterAmount;
                obj.highestdonateName= donationList.Where(x => x.donateAmount == highestdonaterAmount).FirstOrDefault().donaterName;
                




            }
            catch (Exception ex)
            {
               
            }
            return View(obj);

        }

        public ActionResult AddExpenses()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExpenses(ExpenseModel expenseObj)
        {
            try
            {
                ExpenseRepository repo = new ExpenseRepository();
                expenseObj.expenseYear = DateTime.Now.Year.ToString();
                var res = repo.AddExpense(expenseObj);
                if (res)
                {

                    return Json(res, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json(res, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex, JsonRequestBehavior.AllowGet);
                throw;
            }
            
        }

        public ActionResult GetExpenses()
        {
            List<ExpenseModel> list ; 
            try
            {

                ExpenseRepository repo = new ExpenseRepository();
                list = repo.GetAllExpenseList();

                return View(list);
            }
            catch (Exception ex)
            {
                return View();
            }
            
        }

        public ActionResult AddDonations()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDonations(DonationModel donationObj)
        {
            try
            {
                DonationRepository repo = new DonationRepository();
                donationObj.donationYear = DateTime.Now.Year.ToString();
                var res = repo.AddDonation(donationObj);
                if (res)
                {

                    return Json(res, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json(res, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex, JsonRequestBehavior.AllowGet);
                throw;
            }
            
        }

        public ActionResult GetDonations()
        {
            List<DonationModel> list;
            try
            {

                DonationRepository repo = new DonationRepository();
                list = repo.GetAllDonationList();

                return View(list);
            }
            catch (Exception ex)
            {
                return View();
            }
            
        }
       
        public ActionResult AddMembers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMembers(MemberModel memberObj)
        {
            try
            {
                MemberRepository repo = new MemberRepository();
                
                var res = repo.AddMember(memberObj);
                if (res)
                {
                    return Json(res, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(res, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex, JsonRequestBehavior.AllowGet);
                throw;
            }
            
        }

        public ActionResult GetMembers()
        {
            List<MemberModel> list;
            try
            {

                MemberRepository repo = new MemberRepository();
                list = repo.GetMemberList();

                return View(list);
            }
            catch (Exception ex)
            {
                return View();
            }

        }

    }
}