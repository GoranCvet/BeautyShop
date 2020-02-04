﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyShopData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeautyShop.Pages.Visit
{
    public class EditModel : PageModel
    {
        private readonly IVisitData visitData;
        private readonly ICustomer customerData;

        [BindProperty]
        public BeautyShopCore.Visit Visit { get; set; }

        public string Message { get; set; }

        public IEnumerable<SelectListItem> Customers { get; set; }

        public EditModel(IVisitData visitData, ICustomer customerData)
        {
            this.visitData = visitData;
            this.customerData = customerData;
        }

        public IActionResult OnGet()
        {
            Visit = new BeautyShopCore.Visit();

            var customers = customerData.GetCustomers().ToList().Select(p => new { Id = p.Id, Display = $"{p.FirstName} {p.LastName}" });
            Customers = new SelectList(customers, "Id", "Display");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var customer = customerData.GetCustomerById(Visit.CustomerId.Value);
                Visit.Customer = customer;

                Visit = visitData.Create(Visit);
                TempData["Message"] = "The Object is created!";

                visitData.Commit();
                return RedirectToPage("./List");
            }

            var customers = customerData.GetCustomers().ToList().Select(p => new { Id = p.Id, Display = $"{p.FirstName} {p.LastName}" });
            Customers = new SelectList(customers, "Id", "Display");
            return Page();
        }

        public IActionResult OnPostBuy(double? ServicePrice, double? ProductPrice)
        {
            if (ModelState.IsValid)
            {
                var customer = customerData.GetCustomerById(Visit.CustomerId.Value);
                Visit.Customer = customer;

                if (ProductPrice.HasValue && ProductPrice.Value > 0)
                {
                    Visit.BuyProduct(ProductPrice.Value);
                    ProductPrice = 0;
                }
                if (ServicePrice.HasValue && ServicePrice.Value > 0)
                {
                    Visit.BuyService(ServicePrice.Value);
                    ServicePrice = 0;
                }
            }

            Message = Visit.CustomerId == null ? "No customer selected." : $"Total expences: {Visit.TotalExpences()}";
            var customers = customerData.GetCustomers().ToList().Select(p => new { Id = p.Id, Display = $"{p.FirstName} {p.LastName}" });
            Customers = new SelectList(customers, "Id", "Display");
            return Page();
        }
    }
}