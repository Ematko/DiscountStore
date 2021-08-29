namespace FirstLineTask.Library.Model
{
    public interface IShopItem : IBaseItem
    {
        string Name { get; set; }
        double Price { get; set; }
        ItemDiscount Discount { get; set; }
    }
}