using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Where2Pay.Models;

namespace Where2Pay.ViewModels
{
    public class AddAgentsBillerViewModel
    {
        public Agent Agent { get; set; }
        public List<SelectListItem> Billers { get; set; }//BUILDS DROP DOWN LIST
        
        public int AgentID { get; set; }
        public int BillerID { get; set; }

        public AddAgentsBillerViewModel() { }

        public AddAgentsBillerViewModel(Agent agent, IEnumerable<Biller> billers)
        {
            Billers = new List<SelectListItem>();

            foreach (var biller in billers)
            {
                Billers.Add(new SelectListItem
                {
                    Value = biller.ID.ToString(),//TOSTRING, BECAUSE ID IS AN INT
                    Text = biller.Name
                });
            }
            Agent = agent;
        }
    }
}
