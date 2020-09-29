using Cart.Engine.Abstractions;
using System.Linq;

namespace Cart.Engine.Validations
{
    /// <summary>
    /// The validation rules class.
    /// </summary>
    public sealed class ValidationRules
    {
        /// <summary>
        /// The price after promo.
        /// </summary>
        public static double PriceAfterPromo;

        /// <summary>
        /// The cart promo validations.
        /// </summary>
        private static ValidationRules cartPromoValidations;

        /// <summary>
        /// The cart promo validations.
        /// </summary>
        public static Product cartProductValidations
        {
            get;set;
        }        

        /// <summary>
        /// Gets or sets the apply promos.
        /// </summary>
        public double applyPromos {
            get
            {
                return ApplyPromotions(cartProductValidations);
            }
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static ValidationRules Instance
        {
            get
            {
                if (cartPromoValidations == null)
                    cartPromoValidations = new ValidationRules();
                return cartPromoValidations;
            }
        }

        /// <summary>
        /// The apply promotions.
        /// </summary>
        /// <param name="product">The product.</param>
        public static double ApplyPromotions(Product product)
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
                PriceAfterPromo = 130 * (product.ProductQuantity / 3) + 50 * product.ProductQuantity % 3;
            }
            else if (retProductPromo2)
            {
                PriceAfterPromo = 45 * (product.ProductQuantity / 2) + 30 * product.ProductQuantity % 2;

            }
            else if (retProductPromo3 && retProductPromo4)
            {
                PriceAfterPromo = 30 * (product.ProductQuantity);
            }
            else
            {
                PriceAfterPromo = product.ProductPrice * product.ProductQuantity;
            }

            return PriceAfterPromo;

        }
    }
}
