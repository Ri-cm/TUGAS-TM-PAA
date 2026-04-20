namespace Tugas_PAA.Models
{
    public class BookCreateDto
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
