using BeautyShopCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeautyShopData
{
	public class VisitDataMemory : IVisitData
	{
		private List<Visit> visits;
		public VisitDataMemory()
		{
			visits = new List<Visit>();
		}

		public int Commit()
		{
			return 0;
		}

		public Visit Create(Visit visit)
		{
			visit.Id = visits.Any() ? visits.Max(p => p.Id) + 1 : 1;
			visits.Add(visit);
			return visit;
		}

		public IEnumerable<Visit> Delete(Visit visit)
		{
			visits.RemoveAll(r => r.Id == visit.Id);
			return visits;
		}

		public Visit GetVisitById(int Id)
		{
			return visits.SingleOrDefault(r => r.Id == Id);
		}

		public IEnumerable<Visit> GetVisits(string name = null)
		{
			return visits.Where(r => string.IsNullOrEmpty(name) || r.Customer.FirstName.ToLower().StartsWith(name.ToLower())
			|| r.Customer.LastName.ToLower().StartsWith(name.ToLower())).OrderBy(r => r.Customer.FirstName);
		}
	}
}
