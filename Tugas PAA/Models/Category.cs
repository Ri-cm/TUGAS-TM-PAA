using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tugas_PAA.Models
{
    [Table("categories")]
    public class Category
    {
        [Column("id")]
        public int Id { get; set; }


        public List<Books> Books { get; set; }
    }
}