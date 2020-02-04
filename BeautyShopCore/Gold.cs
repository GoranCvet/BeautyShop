using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyShopCore
{
	public class Gold : MemberShip
	{
		public Gold()
		{
			Id = 2;
		}
		public override double DiscountService()
		{
			return 15 / 100.0;
		}

		public override string GetMemberShipType()
		{
			return "Gold";
		}
	}
}
