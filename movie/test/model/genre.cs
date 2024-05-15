
namespace test.model
{
    public class genre
    { 
        public int id { get; set; }
        [MaxLength (100)]
        public string name{ get; set; }
    }
}
