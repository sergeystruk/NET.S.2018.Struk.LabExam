using System;
using System.Collections.Generic;
using System.Linq;

// Очевидный способ, из списка элементов выбираем элементы с нужным нам наименованием,
// далее находим минимальную стоимость для данного наименования, и достаем все, 
// для которых стоимость совпадает с минимальной. 

namespace Logic
{
    public static class ProductService
    {
        #region API

        /// <summary>
        /// API for finding cheapest elements
        /// </summary>
        /// <param name="name">
        /// name of element
        /// </param>
        /// <returns>
        /// IEnumerable of elements
        /// </returns>
        public static IEnumerable<Product> FindCheapest(List<Product> products, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"{nameof(name)} is null or empty");
            }

            Product prod = new Product(name, 1m);

            return FindCheapestProducts(products, prod);
        }

        /// <summary>
        /// API for finding cheapest elements
        /// </summary>
        /// <param name="name">
        /// name of element
        /// </param>
        /// <returns>
        /// IEnumerable of elements
        /// </returns>
        public static IEnumerable<Product> FindCheapest(List<Product> products, Product product)
        {
            if(ReferenceEquals(product, null))
            {
                throw new ArgumentNullException(nameof(product));
            }

            return FindCheapestProducts(products, product);
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
        private static IEnumerable<Product> FindSameNamedProducts(List<Product> products, Product product)
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
        private static IEnumerable<Product> FindCheapestProducts(List<Product> products, Product product)
        {
            if (ReferenceEquals(product, null))
            {
                throw new ArgumentException(nameof(product));
            }

            IEnumerable<Product> sameNamedProducts = FindSameNamedProducts(products, product);
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
