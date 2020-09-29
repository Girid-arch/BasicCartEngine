using System.Collections.Generic;

namespace Cart.Engine.Abstractions
{
    /// <summary>
    /// The product class.
    /// </summary>
    public abstract class Product
    {
        /// <summary>
        /// Gets or sets the product desc.
        /// </summary>
        public string ProductDesc { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the product price.
        /// </summary>
        public double ProductPrice { get; set; }

        /// <summary>
        /// Gets or sets the product quantity.
        /// </summary>
        public double ProductQuantity { get; set; }

        /// <summary>
        /// Calculate the price.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>The <see cref="double"/>.</returns>
        public abstract double CalculatePrice(Product product);

        /// <summary>
        /// The apply promotions.
        /// </summary>
        /// <param name="product">The product.</param>
        public abstract void ApplyPromotions(Product product);

        /// <summary>
        /// Calculate the total price.
        /// </summary>
        /// <param name="CartProducts">The CartProducts.</param>
        /// <returns>The <see cref="double"/>.</returns>
        public abstract double CalculateTotalPrice(IList<Product> CartProducts);
    }
}