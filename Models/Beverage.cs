using System;

namespace CafeManagementSystem.Models
{
    internal class Beverage
    {
        public string Name { get; private set; }
        public decimal BasePrice { get; private set; }
        public string Description { get; private set; }
        public bool IsAvailable { get; private set; }

        public Beverage(string name, decimal basePrice, string description)
        {
            Name = name;
            BasePrice = basePrice;
            Description = description;
            IsAvailable = true;
        }

        public virtual void DisplayInfos()
        {
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Base Price : {BasePrice}");
            Console.WriteLine($"Description : {Description}");
            Console.WriteLine($"Availability : {(IsAvailable ? "available" : "not available")}");
        }
        public virtual decimal CalculatePrice(Size size)
        {
            decimal price = BasePrice;
            switch (size)
            {
                case Size.Small:
                    break;
                case Size.Medium:
                    price += 1.00m;
                    break;
                case Size.Large:
                    price += 2.00m;
                    break;
            }
            return price;
        }
    }
}
