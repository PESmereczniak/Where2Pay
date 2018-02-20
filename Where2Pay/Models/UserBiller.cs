using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Where2Pay.Models
{
    public class UserBiller
    {
        public string Name { get; set; }
        public string Account { get; set; }
        public string Description { get; set; }
        public UserBillerList UsersBiller { get; set; }
        public int UserBillerId { get; set; } //Assigns an ID to the biller in the customer's list; does NOT assign global biller ID
        private static int nextId = 1;

        public UserBiller()
        {
            UserBillerId = nextId;
            nextId++;
        }
    }
}
