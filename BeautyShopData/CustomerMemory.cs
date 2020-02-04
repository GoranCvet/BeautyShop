using BeautyShopCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeautyShopData
{
	public class CustomerMemory : ICustomer
	{
		private List<Customer> customers;
		public CustomerMemory()
		{
			customers = new List<Customer>();
		}

		public Customer Add(Customer customer)
		{
			if(customers.Count() == 0)
			{
				customer.Id = 1;
			}
			else
			{
				customer.Id = customers.Max(c => c.Id + 1);
			}
			customers.Add(customer);
			return customer;
		}

		public int Commit()
		{
			return 0;
		}

		public IEnumerable<Customer> Delete(Customer customer)
		{
			customers.RemoveAll(r => r.Id == customer.Id);
			return customers;
		}

		public Customer GetCustomerById(int id)
		{
			return customers.FirstOrDefault(r => r.Id == id);
		}

		public IEnumerable<Customer> GetCustomers(string name = null)
		{
			return customers.Where(r => string.IsNullOrEmpty(name) || r.FirstName.ToLower().StartsWith(name.ToLower())
			|| r.LastName.ToLower().StartsWith(name.ToLower())).OrderBy(r => r.FirstName);
		}

		public Customer Update(Customer customer)
		{
			var tempt = customers.SingleOrDefault(r => r.Id == customer.Id);
			if (tempt != null)
			{
				tempt.FirstName = customer.FirstName;
				tempt.LastName = customer.LastName;
				tempt.MemberShip = customer.MemberShip;
				tempt.MembershipId = customer.MembershipId;
			}
			return tempt;
		}
	}
}
