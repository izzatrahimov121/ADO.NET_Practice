using Core.Entities;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
	public class ShippingItemRepository : Repository<ShippingItem>, IShippingItemRepository
	{
		public ShippingItemRepository(AppDbContext context) : base(context)
		{
		}
	}
}
