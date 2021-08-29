using FirstLineTask.Library.Repository;
using FirstLineTask.Library.Services;

namespace FirstLineTask.Tests
{
    public static class DataAccess
    {
        public static ShopingCardService CreateNewShopingCardService()
        {
            return new ShopingCardService(new ShopItemRepository(), new ShopingCardRepository());
        }


    }
}
