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
	public async Task<IEnumerable<Attraction>> FindAllAsync()
	{
		return await context.Attractions!.ToListAsync();
	}

	public async Task<Attraction?> FindByAttractionIdAsync(Guid id)
	{
		return await context.Attractions!.FindAsync(id)!;
	}

	public async Task<Attraction?> FindByAttractionNameAsync(string name)
	{
		return await context.Attractions!.FirstOrDefaultAsync(a => a.Name == name);
	}

	public async Task<Attraction?> FindByAttractionStateAsync(string state)
	{
		return await context.Attractions!.FirstOrDefaultAsync(a => a.State == state);
	}

	public async Task<Attraction?> FindByAttractionCityAsync(string city)
	{
		return await context.Attractions!.FirstOrDefaultAsync(a => a.City == city);
	}

	public async Task<Attraction?> FindByAttractionLocationAsync(string location)
	{
		return await context.Attractions!.FirstOrDefaultAsync(a => a.Location == location);
	}

	public async Task<IEnumerable<Attraction>> SearchAttractionByNameAsync(string search)
	{
		return await context.Attractions!
			.Where(a => EF.Functions.Like(a.Name, $"%{search}%"))
			.ToListAsync();
	}

	public async Task<IEnumerable<Attraction>> SearchAttractionByDescriptionAsync(string search)
	{
		return await context.Attractions!
			.Where(a => EF.Functions.Like(a.Description, $"%{search}%"))
			.ToListAsync();
	}

	public async Task<IEnumerable<Attraction>> SearchAttractionByLocationAsync(string search)
	{
		return await context.Attractions!
			.Where(a => EF.Functions.Like(a.Location, $"%{search}%"))
			.ToListAsync();
	}

	public async Task CreateAsync(Attraction attraction)
	{
		await using var sqlConnection = new SqlConnection(configuration["SQLServer:ConnectionString"]);
		await sqlConnection.OpenAsync();
		await sqlConnection.ExecuteAsync("SP_INSERT_ATTRACTION", attraction, commandType: CommandType.StoredProcedure);
	}

	public async Task UpdateAsync(Attraction attraction)
	{
		context.Entry(attraction).State = EntityState.Modified;
		await SaveChangesAsync();
	}

	public async Task DeleteAsync(Guid id)
	{
		var attractionToDelete = await context.Attractions!.FindAsync(id);
		if (attractionToDelete != null)
		{
			context.Attractions.Remove(attractionToDelete);
			await SaveChangesAsync();
		}
	}

	private async Task SaveChangesAsync()
	{
		await context.SaveChangesAsync();
	}
}