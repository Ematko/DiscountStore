namespace FirstLineTask.Library.Model
{
    public class ItemDiscount : IDiscountItem
    {
        /// <summary>
        /// How many items
        /// </summary>
        public double Quantity { get; set; }
        /// <summary>
        /// Discount price
        /// </summary>
        public double Price { get; set; }
    }
}
