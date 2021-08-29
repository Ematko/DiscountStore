using FirstLineTask.Library.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstLineTask.Library.Repository
{
    public class ShopingCardRepository : IShopingCardRepository
    {
        /// <summary>
        /// pretend we got data source
        /// </summary>
        private List<ShopingCard> items = new();
        private int lastId = 1;


        public void AddItemToCard(int cardId, IShopItem item)
        {
            if (item is null) return;
            var card = GetShopingCard(cardId).Result;

            if (card is null) return;
            card.Items.Add(item);
        }


        public void RemoveItemFromCard(int cardId, IShopItem item)
        {
            //if (item is null) throw new NullReferenceException();
            GetShopingCard(cardId).Result.Items.Remove(item);
        }

        public Task<ShopingCard> AddShopingCard(ShopingCard shopingCard)
        {
            if (shopingCard is null) return Task.FromResult<ShopingCard>(null);
            //creates item to save
            var itemToSave = new ShopingCard() { Id = lastId++ };
            items.Add(itemToSave);
            return Task.FromResult(itemToSave);
        }

        public void DeletShopingCard(int shopingCardId)
        {
            var findedItem = items.FirstOrDefault(i => i.Id == shopingCardId);
            items.Remove(findedItem);
        }

        public Task<ShopingCard> GetShopingCard(int shopingCardId)
        {
            var findedItem = items.FirstOrDefault(i => i.Id == shopingCardId);
            return Task.FromResult(findedItem);
        }

        public Task<IEnumerable<ShopingCard>> GetShopingCards()
        {
            return Task.FromResult(items.AsEnumerable());
        }
    }
}
