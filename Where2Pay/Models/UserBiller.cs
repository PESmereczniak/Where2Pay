using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Where2Pay.Models
{
    public class UserBiller
    {
        public string Name { get; set; }//PUBLIC CLASS BILLER >> reference in views, etc.
        public string Account { get; set; }
        public string Description { get; set; }
        public UserBillerList UsersBiller { get; set; }//REMOVE - USED FOR UI
        public int UserBillerId { get; set; } //TO BE REMOVED (DATA COMES FROM BILLER CLASS ABOVE) PREVIOUS: Assigns an ID to the biller in the customer's list; does NOT assign global biller ID
        private static int nextId = 1;

        public UserBiller()
        {
            UserBillerId = nextId;
            nextId++;
        }
    }
}
