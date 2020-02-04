using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyShopCore;
using BeautyShopData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeautyShop.Pages.Customers
{
    public class CustomerEditModel : PageModel
    {
		private readonly ICustomer customer;
		private readonly IMemberShip memberShip;

		[BindProperty]
		public Customer Customer { get; set; }

		public IEnumerable<SelectListItem> MemberShips { get; set; }
		public CustomerEditModel(ICustomer customer,IMemberShip memberShip)
		{
			this.customer = customer;
			this.memberShip = memberShip;
		}
		public IActionResult OnGet(int? Id)
		{
			if (Id.HasValue)
			{
				Customer = customer.GetCustomerById(Id.Value);
				if(Customer == null)
				{
					return RedirectToPage("./NotFound");
				}
			}
			else
			{
				Customer = new Customer();
			}
			var membership = memberShip.GetMemberShips().ToList().Select(p => new { Id = p.Id, Display = p.GetMemberShipType() });
			MemberShips = new SelectList(membership, "Id", "Display");
			return Page();
		}
		public IActionResult OnPost()
		{
			if (ModelState.IsValid)
			{
				var memberships = memberShip.GetMemberShipById(Customer.MembershipId);
				Customer.MemberShip = memberships;
				if(Customer.Id == 0)
				{
					Customer = customer.Add(Customer);
					TempData["Message"] = "The Object is created";
				}
				else
				{
					Customer = customer.Update(Customer);
					TempData["Message"] = "The Object is updated";
				}
				customer.Commit();
				return RedirectToPage("./CustomerList");
			}
			var membership = memberShip.GetMemberShips().ToList().Select(p => new { Id = p.Id, Display = p.GetMemberShipType() });
			MemberShips = new SelectList(membership, "Id", "Display");
			return Page();
		}
    }
}