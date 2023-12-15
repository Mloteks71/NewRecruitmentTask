using System.ComponentModel.DataAnnotations;
using TedeeRecruitmentTask.Domain.Enums;

namespace TedeeRecruitmentTask.Application.Areas.Trips.Models.Requests;
public sealed record PostPatchTripRequest
{
    [Required]
    public string Name { get; set; }
    [Required]
    [EnumDataType(typeof(Country))]
    public Country Country { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public DateTimeOffset StartDate { get; set; }
    [Required]
    public int SeatsCount { get; set; }
}