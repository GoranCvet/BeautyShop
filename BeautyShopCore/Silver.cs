using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyShopCore
{
	public class Silver : MemberShip
	{
		public Silver()
		{
			Id = 3;
		}
		public override double DiscountService()
		{
			return 10 / 100.0;
		}

		public override string GetMemberShipType()
		{
			return "Silver";
		}
	}
}
