using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Where2Pay.Models;
using Where2Pay.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Where2Pay.Controllers
{
    public class UserBillerController : Controller
    {

        static private List<UserBiller> userBillers = new List<UserBiller>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<UserBiller> biller = UserBillerDetail.GetAll();

            return View(biller);
        }

        [Route("/Shared/Where2Contact")]
        public IActionResult Where2Contact()
        {
            return View();
        }

        public IActionResult Add()
        {
            AddUserBillerViewModel addUserBillerViewModel = new AddUserBillerViewModel();
            return View(addUserBillerViewModel);
        }

        // GET: /<controller>/
        [HttpPost]
        public IActionResult Add(AddUserBillerViewModel addUserBillerViewModel)
        {
            if (ModelState.IsValid)
            {
                // Add new cheese to existing cheeses
                UserBiller newUserBiller = new UserBiller
                {
                    Account = addUserBillerViewModel.Account,
                    Description = addUserBillerViewModel.Description,
                    UsersBiller = addUserBillerViewModel.UsersBiller
                };
                UserBillerDetail.Add(newUserBiller);
                return Redirect("/");
            }
            return View(addUserBillerViewModel);
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
