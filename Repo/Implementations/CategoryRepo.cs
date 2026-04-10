using Demo_2.Models;
using Demo_2.Repo.Interfaces;

namespace Demo_2.Repo.Implementations
{
    public class CategoryRepo: ICategoryRepo
    {
        private readonly MyAppContext _context;

        public CategoryRepo(MyAppContext context)
        {
            _context = context;
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(o => o.Id == id);
        }
        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(o => o.Id == id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
    }
}
