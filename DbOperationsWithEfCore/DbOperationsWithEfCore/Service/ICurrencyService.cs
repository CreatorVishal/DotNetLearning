using DbOperationsWithEfCore.Data;

namespace DbOperationsWithEfCore.Services
{
    public interface ICurrencyService
    {
        List<Currency> GetAllCurrencies();

        Currency? GetCurrencyById(int id);

        int GetCurrencyCount();
    }
}