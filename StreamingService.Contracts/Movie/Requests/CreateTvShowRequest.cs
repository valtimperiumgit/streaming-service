using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace StreamingService.Contracts.Movie.Requests;

public class CreateTvShowRequest
{
    [Required(ErrorMessage = "Title is required.")]
    [StringLength(200, ErrorMessage = "Title length cannot exceed 200 characters.")]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "Description is required.")]
    [StringLength(1000, ErrorMessage = "Description length cannot exceed 1000 characters.")]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "MaturityRating is required.")]
    [Range(1, 18, ErrorMessage = "Maturity Rating must be between 1 and 18.")]
    public int MaturityRating { get; set; }
    
    [Required(ErrorMessage = "Image is required.")]
    public IFormFile Image { get; set; }
    
    [Required(ErrorMessage = "Trailer is required.")]
    public IFormFile Trailer { get; set; }
    
    [Required(ErrorMessage = "Logo is required.")]
    public IFormFile Logo { get; set; }
    
    [Required(ErrorMessage = "Release Date is required.")]
    public DateTime ReleaseDate { get; set; }
    
    [MinLength(1, ErrorMessage = "At least one genre is required.")]
    public List<Guid> Genres { get; set; }
    
    [MinLength(1, ErrorMessage = "At least one actor is required.")]
    public List<Guid> Actors { get; set; }

    [MinLength(1, ErrorMessage = "At least one creator is required.")]
    public List<Guid> Creators { get; set; }
}