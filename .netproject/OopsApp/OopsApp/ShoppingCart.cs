using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsApp
{
    class ShoppingCart
    {
        List<Items> items = new List<Items>();

        public void Add(string name,int price,int quantity)
        {
            Items item = new Items();
            item.Name = name;
            item.Price = price;
            item.Quantity = quantity;
            item.PriceTotal = price*quantity;
            items.Add(item);

        }

        //public void Remove(string name)
        //{
        //  if(  items.Name==name)
           
        //}

        public void CalcTotal(Items item)
        {
            int total = 0;
            foreach (Items i in items)
            {
                total =total+ item.PriceTotal;
            }
            Console.WriteLine(total);
        }
    }
}