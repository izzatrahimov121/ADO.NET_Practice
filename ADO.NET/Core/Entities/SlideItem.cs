using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class SlideItem:IEntity
{
	public int Id { get; set; }
	[Required,MaxLength(200)]
    public string? Offer { get; set; }
    [Required]
    public string? Photo { get; set; }
    [Required, MaxLength(200)]
    public string? Description { get; set; }
}
