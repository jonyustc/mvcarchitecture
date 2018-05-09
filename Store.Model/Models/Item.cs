using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    public class Item
    {
        public Item()
        {

        }

        public Item(int orderId,int itemId)
        {
            if (orderId <= 0) throw new ArgumentException("Order is Required");
            if (itemId <= 0) throw new ArgumentException("Item is Required");

            OrderId = orderId;
            ItemId = itemId;
        }


        public int ItemId { get; private set; }
        public string ItemName { get; set; }

        public int OrderId { get; private set; }
        public Order Order { get; private set; }
    }
}
