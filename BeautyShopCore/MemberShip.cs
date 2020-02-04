using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyShopCore
{
	public abstract class MemberShip
	{
		public int Id { get; set; }
		public abstract string GetMemberShipType();
		public abstract double DiscountService();

		public virtual double DiscountProduct()
		{
			return 15 / 100.0;
		}
	}

}
