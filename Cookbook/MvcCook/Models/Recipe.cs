using System.ComponentModel.DataAnnotations;

namespace MvcCook.Models;

public class Recipe
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public TimeSpan? Time { get; set; }
    public string? Description { get; set; }
    public int? NumberOfLikes { get; set; }
    public string? Ingredients { get; set; }
    public string? Process { get; set; }
    public string? TipsAndTricks { get; set; }
}
