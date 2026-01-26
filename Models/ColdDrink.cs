using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagementSystem.Models
{
    internal class ColdDrink : Beverage
    {
        public string DrinkType { get; private set; }
        public bool WithIce { get; private set; }

        public ColdDrink(string name, decimal price, string description, string drinkType, bool withIce) : base(name, price, description)
        {
            DrinkType = drinkType;
            WithIce = withIce;
        }
        public override decimal CalculatePrice(Size size)
        {
            decimal price = base.CalculatePrice(size);
            if (!WithIce)
                price -= 0.25m;
            return price;
        }
    }
}
