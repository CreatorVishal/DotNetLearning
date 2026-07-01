using CareerConnectApi.Data;
using CareerConnectApi.Interfaces;
using CareerConnectApi.Models;

using Microsoft.EntityFrameworkCore;

namespace CareerConnectApi.Services;

public class CompanyService: ICompanyService
{

    private readonly AppDbContext _db;
    public CompanyService(AppDbContext db)
    {
        _db = db;
    }
    public async Task<List<Company>>
    GetAllCompaniesAsync()
    {

        return await _db

        .Companies

        .AsNoTracking()

        .ToListAsync();

    }

}