using BeautyShopCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeautyShopData
{
	public class MemberShipMemory : IMemberShip
	{
		private List<MemberShip> memberships;

		public MemberShipMemory()
		{
			memberships = new List<MemberShip>
			{
				new Premium(),
				new Gold(),
				new Silver(),
				new Bronze()
			};
		}

		public MemberShip GetMemberShipById(int? membershipId)
		{
			return memberships.SingleOrDefault(r => r.Id == membershipId);
		}

		public IEnumerable<MemberShip> GetMemberShips()
		{
			return memberships;
		}
	}
}
