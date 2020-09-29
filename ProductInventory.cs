using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cart.Engine.Interfaces;
namespace Cart.Engine
{
    public class ProductInventory : Product
    {
        public string ProductDesc { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        private double quantity = 0; 
        private double AvailQuantity { get; set; }  
        public double Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }

        public IList<Product> Products { get; set; }

        public override void CalculatePrice()
        {
            return ProductPrice * Quantity;
        }
        public override void ApplyPromotions()
        {
             
        }
        
    }
}
