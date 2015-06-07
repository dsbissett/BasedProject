namespace Based.Business.Interfaces
{
    public interface ICustomerLogic
    {
        ICustomerDto GetById(int id);
        ICustomerPage GetPage(int pageNumber, int pageSize);
    }
}