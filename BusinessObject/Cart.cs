using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Cart
    {
        private List<ItemObject> items;
        public Cart()
        {
            items = new List<ItemObject>();
        }

        public void AddToCart(ItemObject item)
        {
            items.Add(item);
        }

        public void UpdateItem(ItemObject item)
        {
            foreach (var itemItem in items)
            {
                if(itemItem.ProductId == item.ProductId)
                {
                    itemItem.Quantity = item.Quantity;
                }
            }
        }

        public void RemoveFormCart(ItemObject product)
        {
            if (items == null || items.Count == 0) return;
            foreach(var itemItem in items.ToList())
            {
                if(itemItem.MemberId == product.MemberId &&
                    itemItem.ProductId == product.ProductId)
                {
                    items.Remove(itemItem);
                }
            }
        }

        public List<ItemObject> GetCartItems()
        {
            return items;
        }
    }
}
