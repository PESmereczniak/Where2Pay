using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Where2Pay.Models
{
    public class UserBillerDetail
    {
        static private List<UserBiller> billers = new List<UserBiller>();

        // Get All
        public static List<UserBiller> GetAll()
        {
            return billers;
        }
        // Add Method
        public static void Add(UserBiller newBiller)
        {
            billers.Add(newBiller);
        }

        // Remove Method
        public static void Remove(int id)
        {
            UserBiller BillerToRemove = GetById(id);
            billers.Remove(BillerToRemove);
        }

        // Get By ID
        public static UserBiller GetById(int id)
        {
            return billers.Single(x => x.UserBillerId == id);
        }
    }
}