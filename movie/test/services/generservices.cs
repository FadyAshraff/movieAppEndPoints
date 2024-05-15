using Microsoft.EntityFrameworkCore;
using test.model;

namespace test.services
{
    public class generservices : igenerservices
    {
        public readonly applicationdbcontext _context;
        public generservices(applicationdbcontext context)
        {
            _context = context;
        }
        public async Task<genre> createdata(genre genre)
        {
            await _context.genres.AddAsync(genre);
            await _context.SaveChangesAsync();
            return genre;
        }

        public async Task<bool> deletedata(genre genre)
        {
            _context.genres.Remove(genre);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<genre>> GetAsync()
        {
            return await _context.genres.ToListAsync();

        }

        public async Task<genre> getbyid(int Id)
        {
            return await _context.genres.SingleOrDefaultAsync(p => p.id == Id);
        }

        public genre updatedata(genre genre)
        {
            _context.Update(genre);
            _context.SaveChanges();
            return genre;
        }
        public async Task<bool> isvalid(int Id)
        {
            return await _context.movies.AnyAsync(movies => movies.id == Id);
        }
    }
}
