using Demo_2.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Demo_2.Repo.Interfaces
{
    public interface ICategoryRepo
    {
        List<Category> GetAll();
        Category GetById(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);
    }
}