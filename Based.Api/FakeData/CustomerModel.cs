using System.Collections.Generic;

namespace Based.Api.FakeData
{
    public interface ILink
    {
        string PrevPageUrl { get; set; }
        string NextPageUrl { get; set; }
    }

    public class Link : ILink
    {
        public string PrevPageUrl { get; set; }
        public string NextPageUrl { get; set; }
    }

    public interface ICustomerResponse
    {
        int TotalCount { get; set; }
        int TotalPages { get; set; }
        ILink Link { get; set; }
        IEnumerable<ICustomerModel> Customer { get; set; }
    }

    public class CustomerResponse : ICustomerResponse
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public ILink Link { get; set; }
        public IEnumerable<ICustomerModel> Customer { get; set; }
    }

    public interface ICustomerModel
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        IAddress Address { get; set; }
        IPhone Phone { get; set; }
        string Email { get; set; }
    }

    public class CustomerModel : ICustomerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IAddress Address { get; set; }
        public IPhone Phone { get; set; }
        public string Email { get; set; }
    }

    public interface IAddress
    {
        int StreetNumber { get; set; }
        string Address1 { get; set; }
        string Address2 { get; set; }
        string Address3 { get; set; }
        string City { get; set; }
        string State { get; set; }
        string PostalCode { get; set; }
    }

    public class Address : IAddress
    {
        public int StreetNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }

    public interface IPhone
    {
        string PrimaryPhone { get; set; }
        string AlternatePhone { get; set; }
    }

    public class Phone : IPhone
    {
        public string PrimaryPhone { get; set; }
        public string AlternatePhone { get; set; }
    }
}
