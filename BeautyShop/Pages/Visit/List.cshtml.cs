using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyShopData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeautyShop.Pages.Visit
{
    public class ListModel : PageModel
    {
		private readonly IVisitData visit;

		[BindProperty(SupportsGet =true)]
		public string SearchTerm { get; set; }
		[TempData]
		public string Message { get; set; }
		public ListModel(IVisitData visit)
		{
			this.visit = visit;
		}
		public IEnumerable<BeautyShopCore.Visit> Visits { get; set; }
        public void OnGet()
        {
			Visits = visit.GetVisits(SearchTerm);
        }
    }
}