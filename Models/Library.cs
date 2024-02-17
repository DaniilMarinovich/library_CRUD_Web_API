namespace LibraryAPI.Models
{
    public class Library
    {
        public int ISBN { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime TakeTime { get; set; }
        public DateTime ReturnTime { get; set; }
    }
}
