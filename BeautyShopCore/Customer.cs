using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeautyShopCore
{
	public	class Customer
	{
		public int Id { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		public bool IsMember
		{
			get
			{
				return MemberShip != null;
			}
		}
		public MemberShip MemberShip { get; set; }
		[Display(Name = "Memebrship")]
		public int? MembershipId { get; set; }
	}
}
