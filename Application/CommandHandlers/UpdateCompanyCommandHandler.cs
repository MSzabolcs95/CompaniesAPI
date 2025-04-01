using MediatR;

using System.Threading;
using System.Threading.Tasks;
using CompaniesAPI.Domain.Interfaces;
using CompaniesAPI.Application.Commands;

namespace CompaniesAPI.Application.CommandHandlers
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
    {
        private readonly ICompanyRepository _companyRepository;

        public UpdateCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            // Fetch the existing company from the database
            var company = await _companyRepository.GetByIdAsync(request.Id);
            if (company == null)
            {
                throw new ArgumentException("Company not found.");
            }

            // Update company properties
            company.Name = request.Name;
            company.Exchange = request.Exchange;
            company.Ticker = request.Ticker;
            company.Isin = request.Isin;
            company.Website = request.Website;

            // Update the company in the database
            await _companyRepository.UpdateAsync(company);

            return Unit.Value; // Successful update
        }

        Task IRequestHandler<UpdateCompanyCommand>.Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }
}
