using FirstLineTask.Library.Model;
using System.Linq;
using Xunit;

namespace FirstLineTask.Tests
{
    public class CardSevice_AddShopingCard
    {
        [Fact]
        public void AddShopingCard_EmptyValidCard_ShouldWork()
        {
            //Arrange
            var ser = DataAccess.CreateNewShopingCardService();
            //Act
            ser.AddShopingCard(new ShopingCard());
            //Assert
            Assert.True(ser.GetShopingCards().Result.Count() == 1);
        }


        [Fact]
        public void AddShopingCard_Null_ReturnNull()
        {
            //Arrange
            var ser = DataAccess.CreateNewShopingCardService();

            //act
            var res = ser.AddShopingCard(null).Result;
            //Assert
            Assert.True(res is null);
        }

        [Fact]
        public void AddShopingCard_ValidCardWithNullItems_ShouldWork()
        {
            //Arrange
            var ser = DataAccess.CreateNewShopingCardService();
            //Act
            ser.AddShopingCard(new ShopingCard() { Items = null });
            //Assert
            Assert.True(ser.GetShopingCards().Result.Count() == 1);
        }

    }
}
