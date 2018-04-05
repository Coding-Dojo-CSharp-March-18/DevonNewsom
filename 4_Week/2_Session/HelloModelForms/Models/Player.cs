using System;
using System.ComponentModel.DataAnnotations;
namespace HelloModels.Models
{
    public class Player
    {
        [Required(ErrorMessage="FOREST NAM EIS REUROED")]
        [MinLength(4, ErrorMessage="Name Fields must be 4 characters or greater")]
        [Display(Name="First Name")]
        public string FirstName {get;set;}
        [Required]
        [MinLength(4, ErrorMessage="Name Fields must be 4 characters or greater")]
        [Display(Name="Last Name")]
        public string LastName {get;set;}
        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage="Player Numbers Must Be Positive")]
        public int Number {get;set;}
    }
}