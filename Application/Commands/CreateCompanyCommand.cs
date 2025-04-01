using MediatR;

public record CreateCompanyCommand(string Name, string Exchange, string Ticker, string Isin, string? Website) : IRequest<Guid>;