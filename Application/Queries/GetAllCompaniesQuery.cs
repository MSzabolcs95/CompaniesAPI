using MediatR;
using System.Collections.Generic;

namespace CompaniesAPI.Application.Queries
{
    public class GetAllCompaniesQuery : IRequest<IEnumerable<Company>>
    {
    }
}
