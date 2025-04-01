using MediatR;

namespace CompaniesAPI.Application.Queries
{
    public class GetCompanyByIsinQuery : IRequest<Company>
    {
        public string Isin { get; set; }
        public GetCompanyByIsinQuery(string isin) => Isin = isin;
    }
}
