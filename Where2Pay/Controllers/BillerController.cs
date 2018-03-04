using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Where2Pay.Data;
using Where2Pay.Models;
using Where2Pay.ViewModels;

namespace Where2Pay.Controllers
{
    public class BillerController : Controller
    {
        private readonly BillerDbContext context;

        public BillerController(BillerDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Biller> billers = context.Billers.ToList();

            return View(billers);
        }

        public IActionResult Add()
        {
            AddBillerViewModel addBillerViewModel = new AddBillerViewModel();
            return View(addBillerViewModel);
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

                //creates model in database
                context.Billers.Add(newBiller);
                //commits changes to db
                context.SaveChanges();

                return Redirect("/Biller");
            }
            return View(addBillerViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Billers";
            ViewBag.billers = context.Billers.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] billerIds)
        {
            foreach (int billerId in billerIds)
            {
                Biller theBiller = context.Billers.Single(c => c.ID == billerId);
                context.Billers.Remove(theBiller);
            }

            context.SaveChanges();

            return Redirect("/Biller");
        }
    }
}
