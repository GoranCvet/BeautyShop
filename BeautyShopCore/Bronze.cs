using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyShopCore
{
	public class Bronze : MemberShip
	{
		public Bronze()
		{
			Id = 4;
		}
		public override double DiscountService()
		{
			return 0.05;
		}

		public override string GetMemberShipType()
		{
			return "Bronze";
		}
	}
}
