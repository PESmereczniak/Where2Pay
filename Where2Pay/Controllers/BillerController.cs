using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Where2Pay.Models;

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
            return View();
        }

        // GET: /<controller>/
        [HttpPost]
        [Route("/Biller/Add")]
        public IActionResult NewBiller(Biller newBiller)
        {
            // Add new biller to existing billers
            BillerDetail.Add(newBiller);

            return Redirect("/Biller");
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
