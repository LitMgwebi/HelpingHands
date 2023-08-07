using HelpingHands.Interfaces;
using HelpingHands.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace HelpingHands.Services
{
    public class SuburbService : ISuburb
    {
        private readonly HelpingHandsV2Context _context;

        public SuburbService(HelpingHandsV2Context context) => _context = context;

        public async Task<List<Suburb>> GetSuburbs()
        {
            try
            {
                return await _context.Suburbs.FromSqlRaw("SuburbGetAll").ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Suburb>> GetSuburb(int Id)
        {
            try
            {
                var param = new SqlParameter("@SuburbId", Id);

                var suburb = await Task.Run(() => _context.Suburbs.FromSqlRaw(@"exec SuburbGetOne @SuburbId", param).ToListAsync());

                return suburb;
            }
            catch
            {
                throw;
            }
        }

        public async Task AddSuburb(Suburb suburb)
        {
            try
            {
                var parameter = new List<SqlParameter>();

                parameter.Add(new SqlParameter("@Name", suburb.SuburbName));
                parameter.Add(new SqlParameter("@PostalCode", suburb.PostalCode));
                parameter.Add(new SqlParameter("@CityId", suburb.CityId));
                parameter.Add(new SqlParameter("@Active", suburb.Active));

                await Task.Run(() => _context.Database.ExecuteSqlRawAsync(@"exec SuburbInsert @Name, @PostalCode, @CityId, @Active", parameter.ToArray()));
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateSuburb(Suburb suburb)
        {
            try
            {
                var parameter = new List<SqlParameter>();

                parameter.Add(new SqlParameter("@SuburbId", suburb.SuburbId));
                parameter.Add(new SqlParameter("@Name", suburb.SuburbName));
                parameter.Add(new SqlParameter("@PostalCode", suburb.PostalCode));
                parameter.Add(new SqlParameter("@CityId", suburb.CityId));
                parameter.Add(new SqlParameter("@Active", suburb.Active));

                await Task.Run(() => _context.Database.ExecuteSqlRawAsync(@"exec SuburbInsert @SuburbId, @Name, @PostalCode, @CityId, @Active", parameter.ToArray()));
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteSuburb(int Id)
        {
            try
            {
                var param = new SqlParameter("@SuburbId", Id);

                await Task.Run(() => _context.Database
                .ExecuteSqlRawAsync("exec SuburbDelete @SuburbId", param));
            }
            catch
            {
                throw;
            }
        }
    }
}
