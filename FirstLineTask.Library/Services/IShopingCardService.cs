using FirstLineTask.Library.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstLineTask.Library.Services
{
    public interface IShopingCardService
    {
        /// <summary>
        /// Add new item to card
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        void AddItem(int cardId, int itemId);
        /// <summary>
        /// Remove item from card
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        void RemoveItem(int cardId, int itemId);
        /// <summary>
        /// Get total card price 
        /// </summary>
        /// <returns></returns>
        Task<double> GetTotalPrice(int cardId);
        /// <summary>
        /// Return all shoping cards
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ShopingCard>> GetShopingCards();
        /// <summary>
        /// Return shoping card by Id
        /// </summary>
        /// <param name="shopingCardId"></param>
        /// <returns></returns>
        Task<ShopingCard> GetShopingCard(int shopingCardId);
        /// <summary>
        /// Return added shoping card
        /// </summary>
        /// <param name="shopingCard"></param>
        /// <returns></returns>
        Task<ShopingCard> AddShopingCard(ShopingCard shopingCard);
        /// <summary>
        /// Remove shoping card
        /// </summary>
        /// <param name="shopingCardId"></param>
        void DeletShopingCard(int shopingCardId);
    }
}
