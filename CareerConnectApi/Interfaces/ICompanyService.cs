using CareerConnectApi.Models;

namespace CareerConnectApi.Interfaces;

public interface ICompanyService
{
    Task<List<Company>>
    GetAllCompaniesAsync();
}