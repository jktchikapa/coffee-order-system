using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagementSystem.Models
{
    internal class Order
    {
        private static int orderNumber = 1;
        public int OrderNumber { get; private set; }
        public List<OrderItem> Items { get; private set; }
        public DateTime OrderDate { get; private set; }
        public decimal TaxRate { get; private set; }

        public Order()
        {
            OrderNumber = orderNumber++;
            Items = new();
            OrderDate = DateTime.Now;
            TaxRate = 0.15m;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(int index)
        {
            if (index >= 0 && index < Items.Count)
                Items.RemoveAt(index);
        }
        public decimal CalculateSubtotal()
        {
            decimal subTotal = 0.0m;
            foreach(OrderItem item in Items)
            {
                subTotal += item.CalculateSubtotal();
            }
            return subTotal;
        }
        public decimal CalculateTaxes() => CalculateSubtotal() * TaxRate;
        
        public decimal CalculateTotal() => CalculateSubtotal() + CalculateTaxes();

        public void DisplayReceipt()
        {
            Console.WriteLine("------ REÇU ------");
            Console.WriteLine($"Commande #{OrderNumber:D3}");
            Console.WriteLine($"Date : {OrderDate:yyyy/MM/dd HH:mm}");
            Console.WriteLine();

            foreach (OrderItem item in Items)
            {
                Console.WriteLine(
                    $"{item.Quantity}x {item.Beverage.Name} ({item.Size}) - {item.CalculateSubtotal():0.00}$"
                );
            }
            Console.WriteLine("------------------");
            Console.WriteLine($"Sous-total : {CalculateSubtotal():0.00}$");
            Console.WriteLine($"Taxes (15%) : {CalculateTaxes():0.00}$");
            Console.WriteLine($"TOTAL : {CalculateTotal():0.00}$");
        }

    }
}
