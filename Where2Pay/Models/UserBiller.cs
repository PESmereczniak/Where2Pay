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
        public int UserBillerId { get; set; }
        private static int nextId = 1;

        public UserBiller()
        {
            UserBillerId = nextId;
            nextId++;
        }
    }
}
