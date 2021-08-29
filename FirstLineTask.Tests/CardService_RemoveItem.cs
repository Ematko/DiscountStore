using FirstLineTask.Library.Model;
using System.Linq;
using Xunit;

namespace FirstLineTask.Tests
{
    public class CardService_RemoveItem
    {
        [Fact]
        public void RemoveItem_RemoveAddedItem_ShouldWork()
        {
            //Arrange
            var ser = DataAccess.CreateNewShopingCardService();
            ser.AddShopingCard(new ShopingCard());
            ser.AddItem(1, 1);
            ser.AddItem(1, 2);
            ser.AddItem(1, 2);

            //Act
            ser.RemoveItem(1, 1);

            //Assert
            Assert.True(ser.GetShopingCard(1).Result.Items.Count() == 2);
        }

        [Fact]
        public void RemoveItem_RemoveNotAddedItems_RemoveNothink()
        {
            //Arrange
            var ser = DataAccess.CreateNewShopingCardService();
            ser.AddShopingCard(new ShopingCard());
            ser.AddItem(1, 2);
            //Act
            ser.RemoveItem(1, 1);
            //Assert
            Assert.True(ser.GetShopingCard(1).Result.Items.Count() == 1);
        }
    }
}
