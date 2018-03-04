using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Where2Pay.Models;

namespace Where2Pay.ViewModels
{
    public class AgentBillerViewModel
    {
        public List<Agent> Agents { get; set; }
        public List<Biller> Billers { get; set; }
    }
}
