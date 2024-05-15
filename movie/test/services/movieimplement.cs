using Microsoft.EntityFrameworkCore;
using test.Controllers;
using test.dto;
using test.model;

namespace test.services
{
    public class movieimplement : imovie
    {
        public readonly applicationdbcontext _context;

        public movieimplement(applicationdbcontext context)
        {
            _context = context;
        }

        public async Task<movie> addmovies(movie movie)
        {
            await _context.AddAsync(movie);
            _context.SaveChangesAsync();
            return movie;
        }

        public async Task<IEnumerable<movie>> GetAsync(int genreId=0)
        {
            return await _context.movies.Include(m => m.genre)
               .Where(m=>m.genreid==genreId||genreId==0) .OrderByDescending(m => m.rate)
                .ToListAsync();
        }


        public async Task<movie> getmoviebyid(int Id)
        {
           return await _context.movies.Include(x => x.genre).SingleOrDefaultAsync(x => x.id == Id);
         
      
        }

    

       

        public movie update(movie movie)
        {
            _context.Update(movie);
            _context.SaveChanges();
            return movie;
        }
    }
}
