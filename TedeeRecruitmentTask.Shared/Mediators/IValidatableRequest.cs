using MediatR;
using System.ComponentModel.DataAnnotations;

namespace NewRecruitmentTask.Shared.Mediators;

public interface IValidatableRequest<TResponse> : IRequest<TResponse>, IValidatableObject
{
}