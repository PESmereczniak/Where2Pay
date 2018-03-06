using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Where2Pay.Models;
using Where2Pay.ViewModels;
using Where2Pay.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Where2Pay.Controllers
{
    public class AgentController : Controller
    {
        private readonly BillerDbContext context;

        public AgentController(BillerDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            List<Agent> agents = context.Agents.ToList();
            return View(agents);
        }

        public IActionResult Add()
        {
            AgentBillerViewModel model = new AgentBillerViewModel();
            model.Agents = context.Agents.ToList();
            model.Billers = context.Billers.ToList();
            return View(model);
        }
        // GET: /<controller>/
        [HttpPost]
        [Route("/Agent/Add")]
        [HttpPost]
        public IActionResult Add(AddAgentViewModel addAgentViewModel)
        {
            if (ModelState.IsValid)
            {
                Agent newAgent = new Agent
                {
                    Name = addAgentViewModel.Name
                };

                context.Agents.Add(newAgent);
                context.SaveChanges();

                return Redirect("/Agent");

            }
            return View(addAgentViewModel);
        }

        //public IActionResult AddAgentsBiller(AddAgentsBillerViewModel addAgentsBillerViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //LOCAL VARIABLES CREATED FROM DATA SENT BY HTML FORM THROUGH VIEW MODEL
        //        var agentID = addAgentsBillerViewModel.AgentID;
        //        var billerID = addAgentsBillerViewModel.BillerID;
        //        //TOGETHER THESE MAKE A PRIMARY KEY FOR THE CHEESEMENU OBJECT

        //        //CHECKS FOR EXISTING RELATIONSHIP - FOR MULTI-DATA RELATIONSHIP DO NOT USE .SINGLE(), BUT USE .TOLIST()
        //        IList<AgentsBillers> existingItems = context.AgentsBillers
        //            .Where(ab => ab.AgentID == agentID)
        //            .Where(ab => ab.BillerID == billerID).ToList();

        //        if (existingItems.Count == 0)//COMPARES NEW TO EXISTING
        //        {
        //            AgentsBillers agentBiller = new AgentsBillers
        //            {
        //                Agent = context.Agents.Single(a => a.ID == agentID),
        //                Biller = context.Billers.Single(b => b.ID == billerID)
        //            };
        //            context.AgentsBillers.Add(agentBiller);//WHEN NEW ITEM DOES NOT PREVIOUSLY EXIST, ADD NEW MENUITEM AND...
        //            context.SaveChanges();//...SAVE TO DB
        //        }

        //        return Redirect(string.Format("/Agent/ViewAgent/{0}", addAgentsBillerViewModel.AgentID));//STRING FORMATTING
        //    }

        //    return View(addAgentsBillerViewModel);//IF INVALID DATA, RETURN TO VIEW, DISPLAY ANY ERRORS
        //}

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Agents";
            List<Agent> agents = context.Agents.ToList();

            return View(agents);
        }

        [HttpPost]
        public IActionResult Remove(int[] agentIds)
        {
            foreach (int agentId in agentIds)
            {
                Agent removeCheese = context.Agents.Single(c => c.ID == agentId);
                context.Agents.Remove(removeCheese);
            }

            context.SaveChanges();

            return Redirect("/");
        }
    }
}
