using Demo_2.Models;

namespace Demo_2.Repo.Interfaces
{
    public interface IMenuItemRepo
    {
        List<MenuItem> GetAll();
        MenuItem GetById(int id);
        void Add(MenuItem menuItem);
        void Update(MenuItem menuItem);
        void Delete(int id);
    }
}
