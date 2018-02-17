using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Where2Pay.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Where2Pay.Controllers
{
    public class UserBillerController : Controller
    {

        static private List<UserBiller> userBillers = new List<UserBiller>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.userBillers = UserBillerDetail.GetAll();

            return View();
        }

        [Route("/Shared/Where2Contact")]
        public IActionResult Where2Contact()
        {
            return View();
        }

        public IActionResult Add()
        {
            ViewBag.billers = BillerDetail.GetAll();

            return View();
        }

        // GET: /<controller>/
        [HttpPost]
        [Route("/UserBiller/Add")]
        public IActionResult NewUserBiller(UserBiller newUserBiller)
        {
            // Add new biller to existing billers
            UserBillerDetail.Add(newUserBiller);

            return Redirect("/UserBiller");
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Billers";
            ViewBag.userBillers = UserBillerDetail.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] userBillerIds)
        {
            foreach (int userBillerId in userBillerIds)
            {
                UserBillerDetail.Remove(userBillerId);
            }

            return Redirect("/");
        }
    }
}
