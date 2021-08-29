using System.Collections.Generic;

namespace FirstLineTask.Library.Model
{
    public class ShopingCard : BaseItem, IShopingCard
    {
        /// <summary>
        /// Shop items in card
        /// </summary>
        public ICollection<IShopItem> Items { get; set; } = new List<IShopItem>();
    }
}
