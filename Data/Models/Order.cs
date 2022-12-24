using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PieShop.Models
{
    public class Order
    {
        [Key]
        [BindNever]
        public int Id { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; } = default;
        [Required(ErrorMessage = "Please enter a valid value for {0}.")]
        [StringLength(50)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter a valid value for {0}.")]
        [StringLength(50)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter a valid value for {0}.")]
        [StringLength(100)]
        [DisplayName("Address Line 1")]
        public string Address1 { get; set; }
        [Required(ErrorMessage = "Please enter a valid value for {0}.")]
        [StringLength(100)]
        [DisplayName("Address Line 2")]
        public string Address2 { get; set; }
        [DisplayName("Address Line 3")]
        public string? Address3 { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a valid value for {0}.")]
        [Display(Name = "Zip code")]
        [StringLength(50)]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Please enter a valid value for {0}.")]
        [StringLength(50)]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter a valid value for {0}.")]
        [StringLength(50)]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter a valid value for {0}.")]
        [StringLength(50)]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please enter a valid value for {0}.")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please enter a valid value for {0}.")]
        [StringLength(25)]
        [DataType(DataType.EmailAddress)]
        //[RegularExpression(@"/[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?/g", ErrorMessage = "The email Address is not in a correct format.")]
        public string Email { get; set; }
        public float Total { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public bool Active { get; set; }
    }
}
