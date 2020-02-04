using BeautyShopCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyShopData
{
	public interface IVisitData
	{
		Visit Create(Visit visit);
		Visit GetVisitById(int Id);

		int Commit();

		IEnumerable<Visit> GetVisits(string name = null);

		IEnumerable<Visit> Delete(Visit visit);
	}
}
