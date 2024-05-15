using test.model;

namespace test.services
{
    public interface imovie
    {
        Task<IEnumerable< movie>> GetAsync(int genreId=0);
        Task<movie> getmoviebyid(int Id);
        Task<movie>addmovies(movie movie);
   
        movie update( movie movie);
     



    }
}
