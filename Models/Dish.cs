using System.ComponentModel.DataAnnotations;
namespace chefs_dishes.Models
{
    public class Dish {
    [Key]
    public int Dishid { get; set; }
    [Required]
    [MinLength(2)]
    public string Dishname { get; set; }
    [Required]
    [Range(1,9000)]
    public int Calories { get; set; }
    [Required]
    [MinLength(3)]
    public string Description { get; set; }
    [Required]
    [Range(1,5)]
    public int Tastiness { get; set; }
    [Required]
    public int Chefid { get; set; }
    public Chef Creator { get; set; }
    }
}