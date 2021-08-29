using FirstLineTask.Library.Model;
using FirstLineTask.Library.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstLineTask.Library.Services
{
    public class ShopingCardService : IShopingCardService
    {
        private readonly IShopItemRepository _shopItemsRepo;
        private readonly IShopingCardRepository _shopingCardRepo;

        public ShopingCardService(IShopItemRepository shopItemsRepo, IShopingCardRepository shopingCardRepo)
        {
            _shopItemsRepo = shopItemsRepo;
            _shopingCardRepo = shopingCardRepo;
        }

        public void AddItem(int cardId, int itemId)
        {
            var itemToAdd = _shopItemsRepo.GetShopItem(itemId).Result;
            _shopingCardRepo.AddItemToCard(cardId, itemToAdd);
        }
        public void RemoveItem(int cardId, int itemId)
        {
            var itemToRemove = _shopItemsRepo.GetShopItem(itemId).Result;
            _shopingCardRepo.RemoveItemFromCard(cardId, itemToRemove);
        }

        public Task<double> GetTotalPrice(int cardId)
        {
            double price = 0;
            //sorted card items by name
            var cardItesm = GetShopingCard(cardId).Result.Items.OrderBy(i => i.Name).ToList();
            //for each type of item calculate price
            for (int i = 0; i < cardItesm.Count(); i++)
            {
                int lastIndexOfOneType = cardItesm.LastIndexOf(cardItesm[i]);
                int itemsCount = lastIndexOfOneType + 1 - i;
                //dont have discount 
                if (cardItesm[i].Discount is null)
                {
                    price += itemsCount * cardItesm[i].Price;
                }
                //have discount
                else
                {
                    price += calculatePriceOneItemType(cardItesm[i].Discount, itemsCount, cardItesm[i].Price);
                }
                i = lastIndexOfOneType;
            }
            //vypocitrame cenu
            return Task.FromResult(price);
        }
        /// <summary>
        /// Calculate total price for one type of shopItem 
        /// </summary>
        /// <param name="discount">Discount on item</param>
        /// <param name="itemsCount">Count of items with same type</param>
        /// <param name="itemPrice">Regular price for one item</param>
        /// <returns></returns>
        private double calculatePriceOneItemType(ItemDiscount discount, int itemsCount, double itemPrice)
        {
            double discountedItemsPrice = (int)(itemsCount / discount.Quantity) * discount.Price;
            double nonDiscountedItemsPrice = itemsCount % discount.Quantity * itemPrice;
            return discountedItemsPrice + nonDiscountedItemsPrice;
        }

        public Task<ShopingCard> GetShopingCard(int shopingCardId)
        {
            return _shopingCardRepo.GetShopingCard(shopingCardId);
        }

        public Task<IEnumerable<ShopingCard>> GetShopingCards()
        {
            return _shopingCardRepo.GetShopingCards();
        }
        public void DeletShopingCard(int shopingCardId)
        {
            _shopingCardRepo.DeletShopingCard(shopingCardId);
        }

        public Task<ShopingCard> AddShopingCard(ShopingCard shopingCard)
        {
            //add new card
            var card = _shopingCardRepo.AddShopingCard(shopingCard).Result;

            if (card is null) return Task.FromResult<ShopingCard>(null);
            //add items to cart
            if (shopingCard.Items is not null)
            {
                foreach (var item in shopingCard.Items)
                {
                    AddItem(card.Id, item.Id);
                }
            }
            return _shopingCardRepo.GetShopingCard(card.Id);
        }
    }
}
