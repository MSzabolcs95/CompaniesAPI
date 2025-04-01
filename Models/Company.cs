using System.Text.RegularExpressions;

public class Company
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Exchange { get; set; }
    public string Ticker { get; set; }
    public string Isin { get; set; }
    public string? Website { get; set; }

    public Company() { } // Required by EF Core

    public Company(string name, string exchange, string ticker, string isin, string? website)
    {
        if (!Regex.IsMatch(isin, @"^[A-Za-z]{2}[0-9]+$"))
            throw new ArgumentException("Invalid ISIN format.");

        Id = Guid.NewGuid();
        Name = name;
        Exchange = exchange;
        Ticker = ticker;
        Isin = isin;
        Website = website;
    }
}