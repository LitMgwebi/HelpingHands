using HelpingHands.Models;
/** 
 * A lot of help for implementing a Service was provided by the good people at C# Corner, namely:
 * https://www.c-sharpcorner.com/article/crud-operation-using-entity-framework-core-and-stored-procedure-in-net-core-6-w/
**/
namespace HelpingHands.Interfaces
{
    public interface ICity
    {
        public Task<List<City>> GetCities();
        public Task<IEnumerable<City>> GetCity(int Id);
        public Task AddCity(City city);
        public Task UpdateCity(City city);
        public Task DeleteCity(int Id);
    }
}
