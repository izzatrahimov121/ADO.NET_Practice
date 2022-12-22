using Core.Entities;

namespace WebUI.ViewsModels;

public class HomViewModel
{
	public IEnumerable<SlideItem> SlideItems { get; set; } = null!;
	public IEnumerable<ShippingItem> ShippingItems { get; set; } = null!;
}
