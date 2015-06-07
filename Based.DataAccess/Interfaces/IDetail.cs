using System;

namespace Based.DataAccess.Interfaces
{
    public interface IDetail
    {
        int Id { get; set; }
        int CustomerId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int StreetNumber { get; set; }
        string Address1 { get; set; }
        string Address2 { get; set; }
        string Address3 { get; set; }
        string City { get; set; }
        string State { get; set; }
        int PostalCode { get; set; }
        string PrimaryPhone { get; set; }
        string SecondaryPhone { get; set; }
        string EmailAddress { get; set; }
        DateTime RowVersionDate { get; set; }
        string RowVersionUser { get; set; }
        DateTime? DeletedDate { get; set; }
        DateTime RowCreatedDate { get; set; }
        string RowCreatedUser { get; set; }
    }
}