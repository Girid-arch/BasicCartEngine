using Cart.Engine.Abstractions;
using System.Collections.Generic;

namespace Cart.Engine
{
    /// <summary>
    /// The cart item class.
    /// </summary>
    public class CartItem
    {
        /// <summary>
        /// Gets or sets the cart item no.
        /// </summary>
        public string CartItemNo { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public IList<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        public IList<Order> Orders { get; set; }  
    }
}
