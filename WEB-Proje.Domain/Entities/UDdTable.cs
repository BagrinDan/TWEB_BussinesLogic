using System;
using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema;
using WEB_Proje.Domain.Enums;

namespace WEB_Proje.Domain.Entities {
    [Table("UserDate")]
    public class UDdTable {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Username")]
        [Index(IsUnique = true)]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Error Login")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Error Password")]
        public string Password { get; set; }

        public URole userRole { get; set; }

        // Additional info

        [Display(Name = "Email")]
        public string Email {  get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

    }
}
