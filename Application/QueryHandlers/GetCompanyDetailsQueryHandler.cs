using CompaniesAPI.Application.Queries;
using CompaniesAPI.Domain.Interfaces;
using MediatR;

namespace CompaniesAPI.Application
{
    public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, Company>
    {
        private readonly ICompanyRepository _companyRepository;

        public GetCompanyByIdQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Company> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            // Retrieve all companies from the repository
            return await _companyRepository.GetByIdAsync(request.Id);
        }
    }

}
