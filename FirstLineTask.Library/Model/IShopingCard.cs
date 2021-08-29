using System.Collections.Generic;

namespace FirstLineTask.Library.Model
{
    public interface IShopingCard : IBaseItem
    {
        ICollection<IShopItem> Items { get; set; }
    }
}