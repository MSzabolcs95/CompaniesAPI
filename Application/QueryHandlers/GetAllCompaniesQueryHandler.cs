using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CompaniesAPI.Domain.Interfaces;
using CompaniesAPI.Application.Queries;

namespace CompaniesAPI.Application.Handlers
{
    public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, IEnumerable<Company>>
    {
        private readonly ICompanyRepository _companyRepository;

        public GetAllCompaniesQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<IEnumerable<Company>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            // Retrieve all companies from the repository
            return await _companyRepository.GetAllAsync();
        }
    }
}
