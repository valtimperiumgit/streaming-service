using System.ComponentModel.DataAnnotations;

namespace StreamingService.Contracts.Movie.Requests;

public class CreateTvShowSeasonRequest
{
    [Required(ErrorMessage = "Title is required.")]
    [StringLength(200, ErrorMessage = "Title length cannot exceed 200 characters.")]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "Number is required.")]
    [Range(0, int.MaxValue, ErrorMessage = "Number must be not negative value.")]
    public int Number { get; set; }
    
    [Required(ErrorMessage = "TvShowId is required.")]
    public Guid TvShowId { get; set; }
}