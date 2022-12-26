using Core.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Contexts;

public class SlideItemRepository : Repository<SlideItem>, ISlideItemReposiyory
{
	public SlideItemRepository(AppDbContext context) : base(context)
	{
	}
}
