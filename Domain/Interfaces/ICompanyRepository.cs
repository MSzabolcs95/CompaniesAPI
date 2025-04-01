namespace CompaniesAPI.Domain.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Company?> GetByIdAsync(Guid id);
        Task<IEnumerable<Company>> GetAllAsync();
        Task<Company?> GetByIsinAsync(string isin);
        Task AddAsync(Company company);
        Task UpdateAsync(Company company);
    }
}
