using Cart.Engine.Abstractions;
using Cart.Engine.Validations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cart.Engine
{
    /// <summary>
    /// The order class.
    /// </summary>
    public class Order : Product
    {
        /// <summary>
        /// Gets or sets the order ID.
        /// </summary>
        public string OrderID { get; set; }

        /// <summary>
        /// The quantity.
        /// </summary>
        private double quantity = 0;

        /// <summary>
        /// Gets or sets the desc.
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public double Quantity
        {
            get =>  quantity;
            set => quantity = value; 
            
        }

        /// <summary>
        /// The product2orders.
        /// </summary>
        public IDictionary<string, IList<Product>> Product2Orders = new Dictionary<string, IList<Product>>();

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public IList<Product> Products { get; set; }

        /// <summary>
        /// The place order.
        /// </summary>
        /// <param name="prt">The prt.</param>
        public void PlaceOrder(Product prt)
        {
            try
            {
                if (Products == null)
                    Products = new List<Product>(); 
                Products.Add(prt);
            }
            catch (Exception ex)
            {
                File.WriteAllText(@"C:\UnhandledExceptions.txt", DateTime.Now + "-" + ex.ToString());
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        public Order()
        {
            //Default constructor 
        } 

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        /// <param name="PrdItems">The PrdItems.</param>
        public Order(Product PrdItems)
        {
            Name = PrdItems.ProductName;
            Price = PrdItems.ProductPrice;
            Quantity = PrdItems.ProductQuantity;
        }


        /// <summary>
        /// The apply promotions.
        /// </summary>
        /// <param name="product">The product.</param>
        public override void ApplyPromotions(Product product)
        {
            var retProductPromo1 = product.ProductName.Any(x => 
                       x.Equals("A") || x.Equals('A') && product.ProductQuantity >= 3);

            var retProductPromo2 = product.ProductName.Any(x =>
                       x.Equals("B") || x.Equals('B') && product.ProductQuantity >= 2);

            var retProductPromo3 = product.ProductName.Any(x =>
                       x.Equals("C") || x.Equals('C'));

            var retProductPromo4 = product.ProductName.Any(x => x.Equals("D") || x.Equals('D'));


            if (retProductPromo1)
            {
                Price = 130 * (product.ProductQuantity / 3) + 50 * product.ProductQuantity % 3;
            }
            else if (retProductPromo2)
            {
                Price = 45 * (product.ProductQuantity / 2) + 30 * product.ProductQuantity % 2;

            }
            else if (retProductPromo3 && retProductPromo4)
            {
                Price = 30 * (product.ProductQuantity);
            }
            else
            {
                Price = product.ProductPrice * product.ProductQuantity;
            }

        }

        /// <summary>
        /// Calculate the total price.
        /// </summary>
        /// <param name="CartProducts">The CartProducts.</param>
        /// <returns>The <see cref="double"/>.</returns>
        public override double CalculateTotalPrice(IList<Product> CartProducts)
        {
            double price = 0;
            if (CartProducts != null)
            {
                foreach (Product order in CartProducts)
                {
                    price += CalculatePrice(order);
                }

            }
            return price;

        }

        /// <summary>
        /// Calculate the price.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>The <see cref="double"/>.</returns>
        public override double CalculatePrice(Product product)
        {
            //ApplyPromotions(product);
            ValidationRules.cartProductValidations = product;
            return ValidationRules.Instance.applyPromos;
            //return Price;
        }
    }
}