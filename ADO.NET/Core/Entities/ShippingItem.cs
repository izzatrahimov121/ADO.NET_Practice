using Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class ShippingItem:IEntity
{
	
	public int Id { get; set; }

	[Required(ErrorMessage ="Boş buraxma"), MaxLength(50,ErrorMessage ="Uzunluq 50-dən çox olmamalıdır")]
	public string? Title { get; set; }

	[Required(ErrorMessage ="Boş buraxma")]
	public string? Image { get; set; }

	public string? Description { get; set; }
}
