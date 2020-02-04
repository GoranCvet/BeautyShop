using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyShopCore;
using BeautyShopData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeautyShop.Pages.Customers
{
    public class CustomerDetailsModel : PageModel
    {
		private readonly ICustomer customer;
		
		
		public CustomerDetailsModel(ICustomer customer)
		{
			this.customer = customer;
		}
		[TempData]
		public string Message { get; set; }
		[BindProperty]
		public Customer Customer { get; set; }

        public IActionResult OnGet(int Id)
        {
			Customer = customer.GetCustomerById(Id);
			if(Customer == null)
			{
				return RedirectToPage("./NotFound");
			}
			return Page();
        }
    }
}