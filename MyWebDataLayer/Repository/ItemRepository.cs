using Microsoft.EntityFrameworkCore;
using MyWebDataLayer.DataModels;

namespace MyWebDataLayer.Repository
{
    public class ItemRepository : IItemRepository
    {
        readonly DbContext _context;
        readonly DbSet<Item> _dbSet;

        public ItemRepository (DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Item>();
        }


        public void Create(Item item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Item? item = _dbSet.Find(id);
            if (item != null)
            {
                _dbSet.Remove(item);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Item> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }
    }
}
