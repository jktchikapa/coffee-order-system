using System;

namespace CafeManagementSystem.Models
{
    internal class OrderItem
    {
        public Beverage Beverage { get; private set; }
        public Size Size { get; private set; }
        public int Quantity { get; private set; }

        public OrderItem(Beverage beverage, Size size, int quantity)
        {
            Beverage = beverage;
            Size = size;
            Quantity = quantity;
        }

        public decimal CalculateSubtotal()
        {
            return Beverage.CalculatePrice(Size) * Quantity;
        }

    }
}
