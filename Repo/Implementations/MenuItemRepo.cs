using Demo_2.Models;
using Demo_2.Repo.Interfaces;

namespace Demo_2.Repo.Implementations
{
    public class MenuItemRepo:IMenuItemRepo
    {
        private readonly MyAppContext _context;

        public MenuItemRepo(MyAppContext context)
        {
            _context = context;
        }

        public List<MenuItem> GetAll()
        {
            return _context.MenuItems.ToList();
        }
        public MenuItem GetById(int id)
        {
            return _context.MenuItems.FirstOrDefault(o => o.Id == id);
        }
        public void Add(MenuItem menuItem)
        {
            _context.MenuItems.Add(menuItem);
            _context.SaveChanges();
        }
        public void Update(MenuItem menuItem)
        {
            _context.MenuItems.Update(menuItem);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var menuItem = _context.MenuItems.FirstOrDefault(o => o.Id == id);
            if (menuItem != null)
            {
                _context.MenuItems.Remove(menuItem);
                _context.SaveChanges();
            }
        }
    }
}
