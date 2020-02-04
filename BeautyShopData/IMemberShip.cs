using BeautyShopCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyShopData
{
	public interface IMemberShip
	{
		IEnumerable<MemberShip> GetMemberShips();
		MemberShip GetMemberShipById(int? membershipId);
	}
}
