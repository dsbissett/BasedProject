using System;
using Based.DataAccess.Interfaces;

namespace Based.DataAccess.Models
{    
    public class Detail : IDetail
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StreetNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PostalCode { get; set; }
        public string PrimaryPhone { get; set; }
        public string SecondaryPhone { get; set; }
        public string EmailAddress { get; set; }
        public DateTime RowVersionDate { get; set; }
        public string RowVersionUser { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime RowCreatedDate { get; set; }
        public string RowCreatedUser { get; set; }
    }
}