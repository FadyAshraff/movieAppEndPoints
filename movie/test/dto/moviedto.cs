namespace test.NewFolder
{
    public class moviedto
    {
        public string title { get; set; }
        public int year { get; set; }
        public double rate { get; set; }
        [MaxLength(100)]
        public string storeline { get; set; }
        public IFormFile poster { get; set; }
        public int genreid { get; set; }//fk
    }
}
