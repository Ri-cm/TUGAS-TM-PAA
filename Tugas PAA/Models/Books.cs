using System.ComponentModel.DataAnnotations.Schema;
using Tugas_PAA.Models;

public class Books
{
    [Column("id")]
    public int Id { get; set; }
    [Column("title")]
    public string Title { get; set; } = string.Empty;
    
    public Author Author { get; set; }

    // Petakan properti C# ke nama kolom fisik di database
    [Column("price", TypeName = "decimal(12,2)")]
    public decimal Price { get; set; }

    [Column("author_id")]
    public int AuthorId { get; set; }

    [Column("category_id")]
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}