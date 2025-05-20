using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace WEB_Proje.Domain.Entities {
    [Table("ProductTable")]
    public class UDdProducts {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Cantitate { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal? NewPrice { get; set; }

        public bool IsOnSale { get; set; }

        public string ImagePath { get; set; } 
        public string ImageFileName { get; set; } 
    }
}
