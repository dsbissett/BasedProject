using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Based.DataAccess.Interfaces;

namespace Based.DataAccess.Models
{
    [Table("Customer.Detail")]
    public class Detail : IDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }

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

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)] 
        public DateTime RowVersionDate { get; set; }

        [Required]
        [StringLength(64)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)] 
        public string RowVersionUser { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DeletedDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)] 
        public DateTime RowCreatedDate { get; set; }

        [Required]
        [StringLength(64)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)] 
        public string RowCreatedUser { get; set; }
    }
}
