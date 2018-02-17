using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Where2Pay.Models
{
    public class BillerDetail
    {
        static private List<Biller> billers = new List<Biller>();

        // Get All
        public static List<Biller> GetAll()
        {
            return billers;
        }
        // Add Method
        public static void Add(Biller newBiller)
        {
            billers.Add(newBiller);
        }

        // Remove Method
        public static void Remove(int id)
        {
            Biller BillerToRemove = GetById(id);
            billers.Remove(BillerToRemove);
        }

        // Get By ID
        public static Biller GetById(int id)
        {
            return billers.Single(x => x.BillerId == id);
        }
    }
}