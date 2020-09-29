using Cart.Engine.Abstractions;
using System;
using System.Collections.Generic;

namespace Cart.Engine
{
    public class Program
    {
        /// <summary>
        /// The products details.
        /// </summary>
        public static Dictionary<string, string> ProductsDetails = new Dictionary<string, string>();

        /// <summary>
        /// The promotion predicate.
        /// </summary>
        public static Dictionary<string, string> PromotionPredicate = new Dictionary<string, string>();

        /// <summary>
        /// The main entry point.
        /// </summary>
        /// <param name="args">The args.</param>
        static void Main(string[] args)
        { 
            Console.WriteLine("Unit price for SKU IDs");
            Console.WriteLine("Enter product & price details for SKU IDs");
            Console.WriteLine("Enter Product Count:");
            int nItems = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter {0} Products", nItems);
            for (int iProd = 0; iProd < nItems; iProd++)
            {
                string pItems = Console.ReadLine();
                /************************
                 * *
                 A 50
                 B 30
                 C 20
                 D 15
                 * *
                **************************/
                ProductsDetails.Add(pItems.Split(' ')[0], pItems.Split(' ')[1]);
            }
            Console.WriteLine("Active Promotions");
            Console.WriteLine("Enter Promotion Count:");
            int nItemsPromotion = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter {0} Promotions", nItemsPromotion);
            for (int iPromo = 0; iPromo < nItemsPromotion; iPromo++)
            {
                string promoItems = Console.ReadLine();
                /************************
                 3 of A's for 130  3*A 130
                 2 of B's for 45   2*B 45 
                 C & D for 30      C+D 30
                 * *
                **************************/
                PromotionPredicate.Add(promoItems.Split(' ')[0], promoItems.Split(' ')[1]);
            }

            Console.WriteLine("Scenario A");
            Console.WriteLine("Enter Product Cart Items #");
            Order getorder = new Order();
            Product product = new Order(); 
            int nProdItems = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter {0} ProductCartItems", nProdItems);
            for (int items = 0; items < nProdItems; items++)
            {
                string prdItems = Console.ReadLine();
                /************************
                 **Scenario A**
                 1*A 50
                 1*B 30 
                 1*C 20
                 * *
                **************************/
                product = new Order();
                product.ProductQuantity = Convert.ToDouble(prdItems.Split(' ')[0].Split('*')[0]);
                product.ProductName = prdItems.Split(' ')[0].Split('*')[1];
                product.ProductPrice = Convert.ToDouble(prdItems.Split(' ')[1]);
                if (getorder.Products == null)
                    getorder.Products = new List<Product>();
                getorder.Products.Add(product);                
            }
            Console.WriteLine(" Output | Scenario A");
            Console.WriteLine("Total {0}", product.CalculateTotalPrice(getorder.Products));
            
            Console.WriteLine("Scenario B");
            Console.WriteLine("Enter Product Cart Items #");
            getorder = new Order();
            nProdItems = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter {0} ProductCartItems", nProdItems);
            for (int items = 0; items < nProdItems; items++)
            {
                string prdItems = Console.ReadLine();
                /************************
                 **Scenario B**
                 5*A 50
                 2*B 30 
                 1*C 20
                 * *
                **************************/
                product = new Order();
                product.ProductQuantity = Convert.ToDouble(prdItems.Split(' ')[0].Split('*')[0]);
                product.ProductName = prdItems.Split(' ')[0].Split('*')[1];
                product.ProductPrice = Convert.ToDouble(prdItems.Split(' ')[1]);
                if (getorder.Products == null)
                    getorder.Products = new List<Product>();
                getorder.Products.Add(product);
            }
            Console.WriteLine(" Output | Scenario B");
            Console.WriteLine("Total {0}", product.CalculateTotalPrice(getorder.Products));
           
            Console.WriteLine("Scenario C");
            Console.WriteLine("Enter Product Cart Items #");
            getorder = new Order();
            nProdItems = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter {0} ProductCartItems", nProdItems);
            for (int items = 0; items < nProdItems; items++)
            {
                string prdItems = Console.ReadLine();
                /************************
                 **Scenario B**
                 3*A 50
                 5*B 30 
                 1*C 0
                 1*D 30
                 * *
                **************************/
                product = new Order();
                product.ProductQuantity = Convert.ToDouble(prdItems.Split(' ')[0].Split('*')[0]);
                product.ProductName = prdItems.Split(' ')[0].Split('*')[1];
                product.ProductPrice = Convert.ToDouble(prdItems.Split(' ')[1]);
                if (getorder.Products == null)
                    getorder.Products = new List<Product>();
                getorder.Products.Add(product);
            }
            Console.WriteLine(" Output | Scenario C");
            Console.WriteLine("Total {0}", product.CalculateTotalPrice(getorder.Products));
            Console.Read();

        }
    }
}
