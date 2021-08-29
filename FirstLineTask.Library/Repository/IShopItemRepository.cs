using FirstLineTask.Library.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstLineTask.Library.Repository
{
    public interface IShopItemRepository
    {
        /// <summary>
        /// Return all shop items
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ShopItem>> GetShopItems();
        /// <summary>
        /// Return shop item by id
        /// </summary>
        /// <param name="ShopItemId"></param>
        /// <returns></returns>
        Task<ShopItem> GetShopItem(int ShopItemId);
    }
}
