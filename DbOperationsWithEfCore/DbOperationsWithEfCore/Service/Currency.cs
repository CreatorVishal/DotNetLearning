using DbOperationsWithEfCore.Data;

namespace DbOperationsWithEfCore.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly AppDbContext _context;

        // DI Here
        public CurrencyService(AppDbContext context)
        {
            _context = context;
        }

        public List<Currency> GetAllCurrencies()
        {
            return _context.Currencies.ToList();
        }

        public Currency? GetCurrencyById(int id)
        {
            return _context.Currencies.FirstOrDefault(x => x.Id == id);
        }

        public int GetCurrencyCount()
        {
            return _context.Currencies.Count();
        }
    }

}