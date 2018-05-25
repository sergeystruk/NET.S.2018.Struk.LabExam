using System.Collections.Generic;

//SortedDictionary организован на дереве => добавление в конец за логарифм
//и поиск за логарифм. Добавляем все элементы в коллекцию. Ключ - имя продукта
//Значение - Структура из минимальной стоимости элемента и количества элементов такой стоимости
//Прошу прощения, проверки сделать не успел.

namespace Logic._2
{
    public class Service
    {
        public SortedDictionary<string, ProductData> dictionary = new SortedDictionary<string, ProductData>();

        public void Add(Product product)
        {
            if(!dictionary.ContainsKey(product.Name))
            {
                dictionary.Add(product.Name, new ProductData(product.Coast));
            }

            if(dictionary.ContainsKey(product.Name))
            {
                ProductData prod = new ProductData();
                if (dictionary.TryGetValue(product.Name, out prod))
                {
                    if(prod.minCoast == product.Coast)
                    {
                        prod.number++;
                    }

                    if(prod.minCoast > product.Coast)
                    {
                        prod.minCoast = product.Coast;
                        prod.number = 1;
                    }
                }
            }
        }

        public ProductData Find(string name)
        {
            if(dictionary.ContainsKey(name))
            {
                ProductData data = new ProductData();
                if(dictionary.TryGetValue(name, out data))
                {
                    return data;
                }
            }

            return new ProductData();
        }
    }
}
