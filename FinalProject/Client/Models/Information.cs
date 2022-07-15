using System;
using System.ComponentModel.DataAnnotations;
namespace Models
{
    public class Information{
        [Required]
        public string Name{get; set;}


    [Required]
    // public string City { get; set; }
    public string Address { get; set; }
    // [Required,Range(1000000000 ,9999999999 ,ErrorMessage = "Postal Code must be 10 characters")]
    // public long PostalCode { get; set; }
    // [Required, Range(1000000,99999999999, ErrorMessage= "This is not phone number!")]
    [StringLength(13,MinimumLength = 7,ErrorMessage ="This is not phone number!")]
    public string Phone { get; set; }
    // [Required]
    //     [EmailAddress]
    //     public string Email{get; set;}

        public DateTime Date;
    }
}