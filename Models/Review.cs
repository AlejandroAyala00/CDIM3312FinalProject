using System.ComponentModel.DataAnnotations;

namespace CDIM3312FinalProject.Models;

public class Review
{
    public int ReviewID {get; set;} // Primary Key

    [Range(1,5)]
    public int Score {get; set;}

    public string ReviewText {get; set;} = string.Empty;

    public int ProductID {get; set;} // Foreign Key
    public Product? Product {get; set;} = default!; // Navigation Property back to Movie
}