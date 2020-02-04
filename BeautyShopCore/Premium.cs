using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyShopCore
{
	public class Premium : MemberShip
	{
		public Premium()
		{
			Id = 1;
		}
		public override double DiscountService()
		{
			return 25 / 100.0;
		}

		public override string GetMemberShipType()
		{
			return "Premium";
		}
	}
}
