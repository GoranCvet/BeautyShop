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
    public class CustomerListModel : PageModel
    {
		private readonly ICustomer customer;

		public CustomerListModel(ICustomer customer)
		{
			this.customer = customer;
		}
		[BindProperty(SupportsGet =true)]
		public string SearchTerm { get; set; }
		[TempData]
		public string Message { get; set; }
		public IEnumerable<Customer> Customers { get; set; }
        public void OnGet()
        {
			Customers = customer.GetCustomers(SearchTerm);

        }
    }
}