using System.ComponentModel.DataAnnotations;
using TedeeRecruitmentTask.Domain.Entities;
using TedeeRecruitmentTask.Domain.Enums;

namespace TedeeRecruitmentTask.Application.Areas.Trips.Models.Responses;
public sealed record TripDto
{
    [Required]
    public int Id { get; private set; }
    [Required]
    public string Name { get; private set; }
    [Required]
    [EnumDataType(typeof(Country))]
    public Country Country { get; private set; }
    [Required]
    public DateTimeOffset StartDate { get; private set; }
    [Required]
    public int SeatsCount { get; private set; }

    public TripDto(Trip trip)
    {
        Id = trip.Id;
        Name = trip.Name;
        Country = trip.Country;
        StartDate = trip.StartDate;
        SeatsCount = trip.SeatsCount;
    }
}
