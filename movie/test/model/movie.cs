namespace test.model
{
    public class movie
    {
        public int id { get; set; }
        public string title { get; set; }
        public int year { get; set; }
        public double  rate { get; set; }
        [MaxLength(100)]
        public string  storeline { get; set; }
        public byte[] ?poster { get; set; }
        public int genreid { get; set; }
        public genre genre { get; set; }
    }
}
