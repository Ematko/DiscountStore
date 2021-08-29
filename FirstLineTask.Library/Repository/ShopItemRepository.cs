using FirstLineTask.Library.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstLineTask.Library.Repository
{
    /// <summary>
    /// Data repository for each ShopItem type (mug, vaze, ...)
    /// </summary>
    public class ShopItemRepository : IShopItemRepository
    {
        /// <summary>
        /// pretend we got data source
        /// </summary>
        private List<ShopItem> items = new();
        private int lastId = 0;
        public ShopItemRepository()
        {
            items = generateShopItems(10);
        }

        public Task<ShopItem> GetShopItem(int ShopItemId)
        {
            var findedItem = items.FirstOrDefault(i => i.Id == ShopItemId);
            return Task.FromResult(findedItem);
        }

        public Task<IEnumerable<ShopItem>> GetShopItems()
        {
            return Task.FromResult(items.AsEnumerable());
        }

        /// <summary>
        /// generates shop items
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private List<ShopItem> generateShopItems(int count)
        {
            List<ShopItem> items = new();

            for (int i = 1; i <= count; i++)
            {
                items.Add(new ShopItem()
                {
                    Id = i,
                    Name = $"ItemName{i}",
                    Price = i * 10
                });
                lastId++;
            }
            //2 for 1
            items[0].Discount = new ItemDiscount()
            {
                Quantity = 2,
                Price = 10
            };
            //3 for 2
            items[1].Discount = new ItemDiscount()
            {
                Quantity = 3,
                Price = 40
            };
            //4 for 2
            items[2].Discount = new ItemDiscount()
            {
                Quantity = 4,
                Price = 60
            };

            return items;
        }
    }
}
