using HelpingHands.Interfaces;
using HelpingHands.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

/** 
 * A lot of help for implementing a Service was provided by the good people at C# Corner, namely:
 * https://www.c-sharpcorner.com/article/crud-operation-using-entity-framework-core-and-stored-procedure-in-net-core-6-w/
**/
namespace HelpingHands.Services
{
    public class CityService: ICity
    {
        private readonly HelpingHandsV2Context _context;

        public CityService(HelpingHandsV2Context context) => _context = context;
        
        public async Task<List<City>> GetCities()
        {
            return await _context.Cities
                .FromSqlRaw<City>("CityGetAll")
                .ToListAsync();
        }

        public async Task<IEnumerable<City>> GetCity(int Id)
        {
            var param = new SqlParameter("@CityId", Id);
            
            var city = await Task.Run(() => _context.Cities
            .FromSqlRaw(@"exec CityGetOne @CityId", param)
            .ToListAsync());

            return city;
        }

        public async Task AddCity(City city)
        {
            var parameter = new List<SqlParameter>();

            parameter.Add(new SqlParameter("@Name", city.Name));
            parameter.Add(new SqlParameter("@Abbreviation", city.Abbreviation));
            parameter.Add(new SqlParameter("@Active", city.Active));

            await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec CityInsert @Name, @Abbreviation, @Active", parameter.ToArray()));
        }
        
        public async Task UpdateCity(City city)
        {
            try
            {
                var parameter = new List<SqlParameter>();

                parameter.Add(new SqlParameter("@CityId", city.CityId));
                parameter.Add(new SqlParameter("@Name", city.Name));
                parameter.Add(new SqlParameter("@Abbreviation", city.Abbreviation));
                parameter.Add(new SqlParameter("@Active", city.Active));

                await Task.Run(() => _context.Database
                .ExecuteSqlRawAsync(@"exec CityEdit @CityId, @Name, @Abbreviation, @Active", parameter.ToArray()));
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteCity(int Id)
        {
            try
            {
                var param = new SqlParameter("@CityId", Id);

                await Task.Run(() => _context.Database
                .ExecuteSqlRawAsync($"exec CityDelete {param}", param));
            }
            catch
            {
                throw;
            }
        }
    }
}
