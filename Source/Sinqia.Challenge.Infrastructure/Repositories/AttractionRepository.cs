using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sinqia.Challenge.Domain.Entities;
using Sinqia.Challenge.Domain.Repositories;
using Sinqia.Challenge.Infrastructure.Contexts;


namespace Sinqia.Challenge.Infrastructure.Repositories;

public class AttractionRepository(AttractionDbContext context, IConfiguration configuration) : IAttractionRepository
{
	public async Task<IEnumerable<Attraction>> FindAllAttractionAsync()
	{
		return await context.Attractions!.AsNoTracking().ToListAsync();
	}

	public async Task<Attraction?> FindByAttractionNameAsync(string name)
	{
		return await context.Attractions!.AsNoTracking().FirstOrDefaultAsync(a => a.Name == name);
	}

	public async Task<IEnumerable<Attraction>> SearchAttractionAsync(string search)
	{
		await using var sqlConnection = new SqlConnection(configuration["SQLServer:ConnectionString"]);
		await sqlConnection.OpenAsync();
		return await sqlConnection.QueryAsync<Attraction>("SP_SEARCH_ATTRACTION", new { SearchTerm = search },
			commandType: CommandType.StoredProcedure);
	}

	public async Task CreateAttractionAsync(Attraction attraction)
	{
		await context.Attractions!.AddAsync(attraction);
		await context.SaveChangesAsync();
	}
}