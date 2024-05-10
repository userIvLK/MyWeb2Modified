using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebDataLayer;
using MyWebDataLayer.Repository;
using MyWebDataLayer.DataModels;

namespace MyWeb.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        [HttpPost(Name = "PostItemController")]

        public void AddItem(string name)
        {
            DbContext context = new MyWebDbContext();
            IItemRepository IRep = new ItemRepository(context);
            Item item = new()
            {
                Name = name,
                Id = Guid.NewGuid()
            };
            IRep.Create(item);
        }

        [HttpGet(Name = "GetItemController")]

        public string PrintItems()
        {
            DbContext context = new MyWebDbContext();
            IItemRepository IRep = new ItemRepository(context);
            IEnumerable<Item> items = IRep.GetAll();
            string res = "";
            foreach (var s in items)
            {
                res = res + s.Name + "\n";
            }
            return res;
        }

        [HttpDelete(Name = "DeleteItemController")]

        public void Delete(Guid id)
        {
            DbContext context = new MyWebDbContext();       
            IItemRepository IRep = new ItemRepository(context);
            IRep.Delete(id);
        }
    }
}

