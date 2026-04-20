using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tugas_PAA.Models
{
    [Table("authors")]
    public class Author
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public List<Books> Books { get; set; }
    }
}