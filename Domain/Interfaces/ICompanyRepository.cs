namespace CompaniesAPI.Domain.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Company?> GetByIdAsync(Guid id);
        Task<IEnumerable<Company>> GetAllAsync();
        Task AddAsync(Company company);
        Task UpdateAsync(Company company);
    }
}
