using Where2Pay.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Where2Pay.ViewModels
{
    public class AddUserBillerViewModel
    {
        [Required(ErrorMessage = "Please enter a short description, like 'Home' or 'Mom's House'")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Account field cannot be empty")]
        [Display(Name = "[BILLER] Customer Account Number")]
        public string Account { get; set; }

        public UserBillerList UsersBiller { get; set; }

        public List<SelectListItem> UsersBillerList { get; set; }

        public AddUserBillerViewModel()
        {
            UsersBillerList = new List<SelectListItem>();

            // <option value = "0">Hard</option>
            UsersBillerList.Add(new SelectListItem
            {
                Value = ((int)UserBillerList.ElectriCo).ToString(),
                Text = UserBillerList.ElectriCo.ToString()
            });
            UsersBillerList.Add(new SelectListItem
            {
                Value = ((int)UserBillerList.WaterCorp).ToString(),
                Text = UserBillerList.WaterCorp.ToString()
            });
            UsersBillerList.Add(new SelectListItem
            {
                Value = ((int)UserBillerList.Gas).ToString(),
                Text = UserBillerList.Gas.ToString()
            });
        }
    }
}
