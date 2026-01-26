using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagementSystem.Models
{
    internal class Tea : Beverage
    {
        public string TeaType { get; private set; }
        public bool WithLemon { get; private set; }
        public int SugarsNumber { get; private set; }

        public Tea(string name,decimal price,string description,string teaType,bool withLemon,int sugarsNumber) : base(name,price,description)
        {
            TeaType = teaType;
            WithLemon = withLemon;
            SugarsNumber = sugarsNumber;
        }

        public override decimal CalculatePrice(Size size)
        {
            decimal price = base.CalculatePrice(size);
            if (WithLemon)
                price += 0.75m;
            price += SugarsNumber * 0.25m;
            return price;
        }
    }
}
