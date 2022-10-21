using WEB_053504_Mazurenko.Entites;

namespace WEB_053504_Mazurenko.Misc
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }
        /// <summary>
        /// Количество объектов в корзине
        /// </summary>
        public int Count
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity);
            }
        }
        /// <summary>
        /// Количество калорий
        /// </summary>
        public int Price
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity *
                item.Value.Cake.Price);
            }
        }
        /// <summary>
        /// Добавление в корзину
        /// </summary>
        /// <param name="dish">добавляемый объект</param>
        public virtual void AddToCart(Cake cake)
        {
            // реализация метода
            var cakeItem = Items.Where(x => x.Value.Cake.Id == cake.Id).FirstOrDefault();
            if (cakeItem.Value != null)
            {
                cakeItem.Value.Quantity++;
                return;
            }
            int pos = Items.Any() ? Items.Last().Key + 1 : 0;
            Items.Add(pos, new CartItem { Quantity = 1, Cake = cake } );
        }
        /// <summary>
        /// Удалить объект из корзины
        /// </summary>
        /// <param name="id">id удаляемого объекта</param>
        public virtual void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }
        /// <summary>
        /// Очистить корзину
        /// </summary>
        public virtual void ClearAll()
        {
            Items.Clear();
        }
    }
}
