using CompaniesAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompaniesAPI.Infrastructure.Persistence
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;

        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Company?> GetByIdAsync(Guid id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task AddAsync(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
        }

        public async Task<Company?> GetByIsinAsync(string isin)
        {
            return await _context.Companies.FirstOrDefaultAsync(e => e.Isin == isin);
        }
    }
}
