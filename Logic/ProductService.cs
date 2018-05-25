using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class ProductService
    {
        #region Fields and properties

        private List<Product> products;

        public List<Product> Products
        {
            get
            {
                return products;
            }

            set
            {
                if(ReferenceEquals(value, null))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                products = value;
            }
        }

        #endregion

        #region Constructors

        public ProductService(List<Product> products)
        {
            this.products = products ?? throw new ArgumentNullException(nameof(products));
        }

        #endregion

        #region API

        public IEnumerable<Product> FindCheapest(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"{nameof(name)} is null or empty");
            }

            Product prod = new Product(name, 0);

            return FindCheapestProducts(prod);
        }

        public IEnumerable<Product> FindCheapest(Product product)
        {
            if(ReferenceEquals(product, null))
            {
                throw new ArgumentNullException(nameof(product));
            }

            return FindCheapestProducts(product);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Finds products with the same name
        /// </summary>
        /// <param name="product">
        /// Product to search
        /// </param>
        /// <returns>
        /// IEnumerable of products with the same name as parameter has
        /// </returns>
        private IEnumerable<Product> FindSameNamedProducts(Product product)
        {
            if (ReferenceEquals(product, null))
            {
                throw new ArgumentException(nameof(product));
            }
            
            return from prod in products
                   where prod.Equals(product)
                   select prod;
        }

        /// <summary>
        /// Finds cheapest products
        /// </summary>
        /// <param name="product">
        /// Product for seach
        /// </param>
        /// <returns>
        /// IEnumerable of products
        /// </returns>
        private IEnumerable<Product> FindCheapestProducts(Product product)
        {
            if (ReferenceEquals(product, null))
            {
                throw new ArgumentException(nameof(product));
            }

            IEnumerable<Product> sameNamedProducts = FindSameNamedProducts(product);
            decimal cheapestPrice = sameNamedProducts.Min(prod => prod.Coast);

            foreach (var item in sameNamedProducts)
            {
                if (item.Coast == cheapestPrice)
                {
                    yield return item;
                }
            }
        }

        #endregion
    }
}
