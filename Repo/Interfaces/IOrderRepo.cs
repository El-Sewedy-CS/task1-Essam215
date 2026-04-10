using Demo_2.Models;

namespace Demo_2.Repo.Interfaces
{
    public interface IOrderRepo
    {
        List<Order> GetAll();
        Order GetById(int id);
        void Add(Order order);
        void Update(Order order);
        void Delete(int id);
    }
}
