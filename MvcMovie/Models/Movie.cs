using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models;

public class Movie {
    public int Id {get; set;}
    
    [Required]
    public string? Title {get; set;}
    
    [Display(Name = "Release data")]
    [DataType((DataType.Date))]
    [Required]
    public DateTime ReleaseDate {get; set;}
    
    [Required]
    public string? Genre {get; set;}
    
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    [Range(1, 10000)]
    public decimal Price {get; set;}
}