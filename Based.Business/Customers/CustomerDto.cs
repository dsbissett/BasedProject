using System.ComponentModel.DataAnnotations;
using Based.Business.Interfaces;

namespace Based.Business.Customers
{
    public class CustomerDto : ICustomerDto
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(64)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(64)]
        public string LastName { get; set; }

        [Required]
        public int StreetNumber { get; set; }

        [Required]
        [StringLength(128)]
        public string Address1 { get; set; }

        [StringLength(128)]
        public string Address2 { get; set; }

        [StringLength(128)]
        public string Address3 { get; set; }

        [Required]
        [StringLength(64)]
        public string City { get; set; }

        [Required]
        [StringLength(16)]
        public string State { get; set; }

        [Required]
        public int PostalCode { get; set; }

        [Phone]
        [Required]
        [StringLength(10)]
        public string PrimaryPhone { get; set; }

        [Phone]
        [StringLength(10)]
        public string SecondaryPhone { get; set; }

        [EmailAddress]
        [StringLength(512)]
        public string EmailAddress { get; set; }
    }
}