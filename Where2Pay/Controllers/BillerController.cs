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
    public class BillerController : Controller
    {

        static private List<Biller> billers = new List<Biller>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.billers = BillerDetail.GetAll();

            return View();
        }

        public IActionResult Add()
        {
            AddBillerViewModel addBillerViewModel = new AddBillerViewModel();
            return View();
        }

        // GET: /<controller>/
        [HttpPost]
        public IActionResult Add(AddBillerViewModel addBillerViewModel)
        {
            if (ModelState.IsValid)
            {
                Biller newBiller = new Biller
                {
                    Name = addBillerViewModel.Name,
                    Phone = addBillerViewModel.Phone,
                    Email = addBillerViewModel.Email,
                    Web = addBillerViewModel.Web
                };
                // Add new biller to existing billers
                BillerDetail.Add(newBiller);
                return Redirect("/Biller");
            }
            return View(addBillerViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Billers";
            ViewBag.billers = BillerDetail.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] billerIds)
        {
            foreach (int billerId in billerIds)
            {
                BillerDetail.Remove(billerId);
            }

            return Redirect("/Biller");
        }
    }
}
