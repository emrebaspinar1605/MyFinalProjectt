using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _oDal;

        public OrderManager(IOrderDal oDal)
        {
            _oDal = oDal;
        }

        public void Add(Order order)
        {
            _oDal.Add(order);
        }

        public void Delete(Order order)
        {
            _oDal.Delete(order);
        }

        public List<Order> GetAll()
        {
            return _oDal.GetAll();
        }

        public List<Order> GetByCustomerId(string customerId)
        {
            return _oDal.GetAll(o => o.CustomerID == customerId).ToList();
        }

        public List<Order> GetByEmployeeId(int employeeId)
        {
            return _oDal.GetAll(o => o.EmployeeID == employeeId).ToList();
        }

        public Order GetById(int id)
        {
            return _oDal.Get(o => o.OrderID == id);
        }

        public void Update(Order order)
        {
            _oDal.Update(order);
        }
    }
}
