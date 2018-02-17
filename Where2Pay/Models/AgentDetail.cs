using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Where2Pay.Models
{
    public class AgentDetail
    {
        static private List<Agent> agents = new List<Agent>();

        // Get All
        public static List<Agent> GetAll()
        {
            return agents;
        }

        // Add Method
        public static void Add(Agent newAgent, int BillerId)
        {
            AgentBiller AgentBillerToAdd = GetById(BillerId);
            
            agents.Add(newAgent);
        }

        // Remove Method
        public static void Remove(int id)
        {
            Agent AgentToRemove = GetById(id);
            agents.Remove(AgentToRemove);
        }

        // Get By ID
        public static Agent GetById(int id)
        {
            return agents.Single(x => x.AgentId == id);
        }
    }
}