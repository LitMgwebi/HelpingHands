using HelpingHands.Models;

namespace HelpingHands.Interfaces
{
    public interface ISuburb
    {
        public Task<List<Suburb>> GetSuburbs();
        public Task<IEnumerable<Suburb>> GetSuburb(int Id);
        public Task AddSuburb(Suburb suburb);
        public Task UpdateSuburb(Suburb suburb);
        public Task DeleteSuburb(int Id);
    }
}
