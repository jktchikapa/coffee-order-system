using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagementSystem.Models
{
    internal class Coffee : Beverage
    {
        public string CoffeeType { get; private set; }
        public bool WithMilk { get; private set; }
        public int NumbersOfSugars { get; private set; }

        public Coffee(string name, decimal basePrice, string description, string coffeeType, bool withMilk, int numberOfSugars) : base(name, basePrice, description)
        {
            CoffeeType = coffeeType;
            WithMilk = withMilk;
            NumbersOfSugars = numberOfSugars;
        }
        public override decimal CalculatePrice(Size size)
        {
            decimal price = base.CalculatePrice(size);
            if (WithMilk)
                price += 0.50m;
            price += NumbersOfSugars * 0.25m;
            return price;
        }
    }
}
