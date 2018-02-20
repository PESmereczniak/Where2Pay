using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Where2Pay.Models
{
    public class Agent
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public int AgentId { get; set; }

        //LIST OF INDIVIDUAL AGENT'S BILLERS
        public List<Agent> AgentBillers { get; set; }

        private static int nextId = 1;

        public Agent()
        {
            AgentId = nextId;
            nextId++;
        }
    }
}
