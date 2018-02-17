using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Where2Pay.Models
{
    public class Biller
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public int BillerId { get; set; }
        private static int nextId = 1;

        public Biller()
        {
            BillerId = nextId;
            nextId++;
        }
    }
}
