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
    public class VisitDeleteModel : PageModel
    {
        private readonly IVisitData visitData;

        public VisitDeleteModel(IVisitData visitData)
        {
            this.visitData = visitData;
        }
        [BindProperty]
        public Visit Visit { get; set; }
        public IActionResult OnGet(int? Id)
        {
            if(Id == null)
            {
                return RedirectToPage("./NotFound");
            }
            Visit = visitData.GetVisitById(Id.Value);
            if(Visit == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if(Visit != null)
            {
                visitData.Delete(Visit);
                visitData.Commit();

                TempData["Message"] = "The Object is successfully deleted";

                return RedirectToPage("./List");
            }
            return Page();
        }
    }
}