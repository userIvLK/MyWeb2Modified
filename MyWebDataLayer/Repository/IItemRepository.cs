using MyWebDataLayer.DataModels;

namespace MyWebDataLayer.Repository
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAll();
        void Create(Item item);
        void Delete(Guid id);
    }
}
