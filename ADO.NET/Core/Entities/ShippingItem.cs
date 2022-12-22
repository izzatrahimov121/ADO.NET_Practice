using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class ShippingItem
{
	
	public int Id { get; set; }

	[Required, MaxLength(50)]
	public string? Title { get; set; }

	[Required]
	public string? Image { get; set; }

	public string? Description { get; set; }
}
