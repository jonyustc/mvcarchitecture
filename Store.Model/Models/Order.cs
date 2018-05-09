using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    public class Order
    {
        private List<Item> _items = new List<Item>();

        public Order(int orderId)
        {
            if (orderId <= 0) throw new ArgumentException("OrderId must be specified");
            OrderId = orderId;
        }


        public int OrderId { get; set; }
        public string OrderName { get; set; }

        public IReadOnlyList<Item> OrderItems { get { return _items; } }

        public void Add(Item item)
        {
            if (item == null) throw new ArgumentNullException("item");

            if (item.OrderId != OrderId) throw new InvalidOperationException("Item belongs to another order");

            _items.Add(item);
        }
    }
}
