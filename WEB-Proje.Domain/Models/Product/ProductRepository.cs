using System;
using System.Collections.Generic;
using WEB_Proje.Domain.Product;

namespace WEB_Proje.Domain.ProductRepository {
    public static class ProductRepository {
        readonly private static List<ProductModel> products = new List<ProductModel>();

        public static List<ProductModel> GetAll() => products;

        public static void Add(ProductModel product) {
            product.Id = products.Count + 1;
            products.Add(product);
        }
    }
}