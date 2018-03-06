using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Where2Pay.Models
{
    public class Biller
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }

        public int AgentID { get; set; }
        public Agent Agent { get; set; }

        public ICollection<AgentsBillers> AgentsBillers { get; set; } = new List<AgentsBillers>();
    }
}
