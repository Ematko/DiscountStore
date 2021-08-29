namespace FirstLineTask.Library.Model
{
    public class ShopItem : BaseItem, IShopItem
    {
        /// <summary>
        /// Name of item
        /// </summary>
        public string Name { get; set; } = "DefName";
        /// <summary>
        /// Price of item
        /// </summary>
        public double Price { get; set; } = 0;
        /// <summary>
        /// Discount on item
        /// </summary>
        public ItemDiscount Discount { get; set; }
    }
}
