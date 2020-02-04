using BeautyShopCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyShopData
{
	public interface ICustomer
	{
		IEnumerable<Customer> GetCustomers(string name = null);

		Customer GetCustomerById(int id);

		Customer Update(Customer customer);

		Customer Add(Customer customer);
		int Commit();

		IEnumerable<Customer> Delete(Customer customer);
	}
}
