using FirstLineTask.Library.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstLineTask.Library.Repository
{
    public interface IShopingCardRepository
    {
        /// <summary>
        /// Add IShopItem to card
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="item"></param>
        void AddItemToCard(int cardId, IShopItem item);
        /// <summary>
        /// Remove IshopItem from card
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="item"></param>
        void RemoveItemFromCard(int cardId, IShopItem item);
        /// <summary>
        /// Get all shoping cards
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ShopingCard>> GetShopingCards();
        /// <summary>
        /// Get shoping card by Id
        /// </summary>
        /// <param name="shopingCardId"></param>
        /// <returns></returns>
        Task<ShopingCard> GetShopingCard(int shopingCardId);
        /// <summary>
        /// Add new shoping card without items
        /// </summary>
        /// <param name="shopingCard"></param>
        /// <returns></returns>
        Task<ShopingCard> AddShopingCard(ShopingCard shopingCard);
        /// <summary>
        /// Delete shoping card by Id
        /// </summary>
        /// <param name="shopingCardId"></param>
        void DeletShopingCard(int shopingCardId);
    }
}