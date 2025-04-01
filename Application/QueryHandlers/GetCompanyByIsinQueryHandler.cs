using CompaniesAPI.Application.Queries;
using CompaniesAPI.Domain.Interfaces;
using MediatR;

namespace CompaniesAPI.Application.QueryHandlers
{
    public class GetCompanyByIsinQueryHandler : IRequestHandler<GetCompanyByIsinQuery, Company>
    {
        private readonly ICompanyRepository _companyRepository;

        public GetCompanyByIsinQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Company> Handle(GetCompanyByIsinQuery request, CancellationToken cancellationToken)
        {
            return await _companyRepository.GetByIsinAsync(request.Isin);
        }
    }
}
