using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Where2Pay.Models;
using Where2Pay.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Where2Pay.Controllers
{
    public class AgentController : Controller
    {

        //static private List<Agent> agents = new List<Agent>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            AgentBillerViewModel model = new AgentBillerViewModel();
            model.Agents = AgentDetail.GetAll();
            model.Billers = BillerDetail.GetAll();

            return View(model);
        }

        public IActionResult Add()
        {
            AgentBillerViewModel model = new AgentBillerViewModel();
            model.Agents = AgentDetail.GetAll();
            model.Billers = BillerDetail.GetAll();
            return View(model);
        }
        // GET: /<controller>/
        [HttpPost]
        [Route("/Agent/Add")]
        public IActionResult NewAgent(Agent newAgent)
        {
            // ADD BILLERS TO AGENTBILLER LIST
            var billerToAdd = Request.Form["name"];
            //newAgent.AgentBillers.Append(billerToAdd);

            // Add new agent
            AgentDetail.Add(newAgent);

            return Redirect("/Agent");
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Agents";
            List<Agent> agents = AgentDetail.GetAll();

            return View(agents);
        }

        [HttpPost]
        public IActionResult Remove(int[] agentIds)
        {
            foreach (int agentId in agentIds)
            {
                AgentDetail.Remove(agentId);
            }

            return Redirect("/Agent");
        }
    }
}
