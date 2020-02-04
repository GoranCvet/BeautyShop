using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyShopCore;
using BeautyShopData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeautyShop.Pages.MemberShips
{
    public class MembershipListModel : PageModel
    {
		private readonly IMemberShip membershipData;
		public IEnumerable<MemberShip> Memberships { get; set; }

		public MembershipListModel(IMemberShip membershipData)
		{
			this.membershipData = membershipData;
		}

		public void OnGet()
		{
			Memberships = membershipData.GetMemberShips();
		}
	}
}