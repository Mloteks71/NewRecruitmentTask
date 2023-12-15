using System.ComponentModel.DataAnnotations;

namespace TedeeRecruitmentTask.Application.Areas.Trips.Models.Requests;
public sealed record PostRegisterRequest
{
    [Required]
    public string Email { get; set; }
}