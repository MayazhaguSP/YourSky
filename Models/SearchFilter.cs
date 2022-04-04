namespace YourSky.Models
{
    public class SearchFilter
    {
        private SearchContext context;
        public string course { get; set; }
        public string country { get; set; }
        public string intakes { get; set; }
        public int pageno { get; set; }
        public int pagesize { get; set; }
    }
}
