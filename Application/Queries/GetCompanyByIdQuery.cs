using MediatR;

namespace CompaniesAPI.Application.Queries
{
    public class GetCompanyByIdQuery : IRequest<Company>
    {
        public Guid Id { get; set; }
        public GetCompanyByIdQuery(Guid id) => Id = id;
    }
}