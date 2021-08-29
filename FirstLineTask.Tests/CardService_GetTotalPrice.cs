using FirstLineTask.Library.Model;
using Xunit;

namespace FirstLineTask.Tests
{
    public class CardService_GetTotalPrice
    {
        [Theory]
        [InlineData(50, 1, 1, 2, 2, 2)]
        [InlineData(80, 1, 1, 1, 2, 2, 2, 2)]
        [InlineData(30, 1, 2)]
        [InlineData(210, 1, 1, 4, 1, 5, 2, 1, 8)]
        [InlineData(10, 1, 0)]
        public void GetTotalPrice_ValidOrNonValidItems_True(double correctPrice, params int[] itemsIds)
        {
            //Arrange
            var ser = DataAccess.CreateNewShopingCardService();
            ser.AddShopingCard(new ShopingCard());
            foreach (var itemId in itemsIds)
            {
                ser.AddItem(1, itemId);
            }


            //Act
            var price = ser.GetTotalPrice(1).Result;

            //Assert
            Assert.True(price == correctPrice);
        }
    }
}
