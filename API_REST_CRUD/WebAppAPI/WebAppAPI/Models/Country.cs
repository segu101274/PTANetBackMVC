using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppAPI.Models
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 idCountry { get; set; }
        [Required]
        public String country { get; set; }
        [Required]
        public String countryCode { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime fechaRegistro { get; set; }
    }
}
