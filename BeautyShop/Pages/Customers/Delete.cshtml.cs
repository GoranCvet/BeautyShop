using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyShopCore;
using BeautyShopData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeautyShop
{
    public class DeleteModel : PageModel
    {
        private readonly ICustomer customer;

        public DeleteModel(ICustomer customer)
        {
            this.customer = customer;
        }
        [BindProperty]
        public Customer Customer { get; set; }
        public IActionResult OnGet(int? Id)
        {
            if(Id == null)
            {
                return RedirectToPage("./NotFound");
            }
            Customer = customer.GetCustomerById(Id.Value);
            if(Customer == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if(Customer != null)
            {
                customer.Delete(Customer);
                customer.Commit();

                TempData["Message"] = "Customer successfully delete";

                return RedirectToPage("./CustomerList");
            }
            return Page();
        }
    }
}