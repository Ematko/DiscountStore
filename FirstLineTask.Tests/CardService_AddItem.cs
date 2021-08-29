using FirstLineTask.Library.Model;
using System.Linq;
using Xunit;

namespace FirstLineTask.Tests
{
    public class CardService_AddItem
    {
        [Fact]
        public void AddItem_ValidItems_ShouldWork()
        {
            //Arrange
            var ser = DataAccess.CreateNewShopingCardService();
            ser.AddShopingCard(new ShopingCard());

            //Act
            ser.AddItem(1, 1);
            ser.AddItem(1, 2);
            ser.AddItem(1, 2);

            //Assert
            Assert.True(ser.GetShopingCard(1).Result.Items.Count() == 3);
        }

        [Fact]
        public void AddItem_NotExistingItems_AddNothink()
        {
            //Arrange
            var ser = DataAccess.CreateNewShopingCardService();
            ser.AddShopingCard(new ShopingCard());
            //Act
            ser.AddItem(1, 20);
            //Assert
            Assert.True(ser.GetShopingCard(1).Result.Items.Count() == 0);
        }

        [Fact]
        public void AddItem_NotExistingCard_AddNothink()
        {
            //Arrange
            var ser = DataAccess.CreateNewShopingCardService();
            ser.AddShopingCard(new ShopingCard());
            //Act
            ser.AddItem(5, 2);
            //Assert
            Assert.True(ser.GetShopingCard(1).Result.Items.Count() == 0);
        }
    }
}


