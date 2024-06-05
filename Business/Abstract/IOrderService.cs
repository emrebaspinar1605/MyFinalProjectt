using Entities.Concrete;

namespace Business.Abstract
{
    public interface IOrderService
    {
        List<Order> GetAll();
        void Add(Order order);
        void Update(Order order);
        void Delete(Order order);
        List<Order> GetByCustomerId(string customerId);
        List<Order> GetByEmployeeId(int employeeId);
        Order GetById(int id);
    }
}
