using test.model;

namespace test.services
{
    public interface igenerservices
    {
        Task<IEnumerable<genre>> GetAsync();
        Task<genre> createdata(genre genre);
        genre updatedata(genre genre);
        Task<genre> getbyid(int Id);
       Task<bool> deletedata(genre genre);
        Task<bool> isvalid(int Id);
    }
}
 