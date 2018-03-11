using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Where2Pay.Models;
using Where2Pay.ViewModels;
using Where2Pay.Data;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

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
            AddAgentViewModel addAgentViewModel = new AddAgentViewModel();
            return View(addAgentViewModel);
        }

        // GET: /<controller>/
        [HttpPost]
        public IActionResult Add(AddAgentViewModel addAgentViewModel)
        {
            if (ModelState.IsValid)
            {
                Agent newAgent = new Agent
                {
                    Name = addAgentViewModel.Name,
                    Phone = addAgentViewModel.Phone,
                    Street1 = addAgentViewModel.Street1,
                    Street2 = addAgentViewModel.Street2,
                    City = addAgentViewModel.City,
                    State = addAgentViewModel.State,
                    Zip = addAgentViewModel.Zip
                };

                context.Agents.Add(newAgent);
                context.SaveChanges();

                return Redirect("/Agent");

            }
            return View(addAgentViewModel);
        }

        public IActionResult ViewAgent(int id)
        {
            Agent agent = context.Agents.Single(a => a.ID == id);
            return View(agent);
        }

        //RENDER PAGE FOR ADDING BILLERS TO AGENT'S LIST
        public IActionResult AddAgentsBillers(int id)
        {
            Agent agent = context.Agents.Single(a => a.ID == id);//GETS MENU BASED ON MENU ID PASSED ABOVE (int id)
            List<Biller> billers = context.Billers.ToList();//THIS LIST OF BILLERS IS SPECIFICALLY FOR POPULATING A SELECT LIST IN HTML
            return View(new AgentBillerViewModel(agent, billers));
        }

        //ACTION THAT ADDS BILLER TO AGENT'S LIST
        [HttpPost]
        public IActionResult AddAgentsBillers(AgentBillerViewModel agentBillerViewModel)
        {
            if (ModelState.IsValid)
            {
                //LOCAL VARIABLES CREATED FROM DATA SENT BY HTML FORM THROUGH VIEW MODEL
                var agentID = agentBillerViewModel.AgentID;
                var billerID = agentBillerViewModel.BillerID;
                //TOGETHER THESE MAKE A PRIMARY KEY FOR THE CHEESEMENU OBJECT

                //CHECKS FOR EXISTING RELATIONSHIP - FOR MULTI-DATA RELATIONSHIP DO NOT USE .SINGLE(), BUT USE .TOLIST()
                IList<AgentsBillers> existingItems = context.AgentsBillers
                    .Where(ab => ab.AgentID == agentID)
                    .Where(ab => ab.BillerID == billerID).ToList();

                if (existingItems.Count == 0)//COMPARES NEW TO EXISTING
                {
                    AgentsBillers agentBiller = new AgentsBillers
                    {
                        Agent = context.Agents.Single(a => a.ID == agentID),
                        Biller = context.Billers.Single(b => b.ID == billerID)
                    };
                    context.AgentsBillers.Add(agentBiller);//WHEN NEW ITEM DOES NOT PREVIOUSLY EXIST, ADD NEW MENUITEM AND...
                    context.SaveChanges();//...SAVE TO DB
                }

                return Redirect(string.Format("/Agent/ViewAgent/{0}", agentBillerViewModel.AgentID));//STRING FORMATTING
            }

            return View(agentBillerViewModel);//IF INVALID DATA, RETURN TO VIEW, DISPLAY ANY ERRORS
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Agents";
            ViewBag.agents = context.Agents.ToList();

            return View();
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
