using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Where2Pay.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Where2Pay.Controllers
{
    public class AgentController : Controller
    {

        static private List<Agent> agents = new List<Agent>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.agents = AgentDetail.GetAll();

            return View();
        }

        public IActionResult Add()
        {
            ViewBag.billers = BillerDetail.GetAll();
            return View();
        }
        // GET: /<controller>/
        [HttpPost]
        [Route("/Agent/Add")]
        public IActionResult NewAgent(Agent newAgent)
        {
            // Add new agent to existing agent
            AgentDetail.Add(newAgent);

            return Redirect("/Agent");
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Agents";
            ViewBag.agents = AgentDetail.GetAll();
            return View();
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
