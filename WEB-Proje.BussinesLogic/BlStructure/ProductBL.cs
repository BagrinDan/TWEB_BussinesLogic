using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WEB_Proje.BussinesLogic.DBModel;
using WEB_Proje.Domain.Entities;
using WEB_Proje.Domain.Product;

namespace WEB_Proje.BussinesLogic.BlStructure {
    public class ProductBL {
        private readonly ProductContext database;

        public ProductBL() {
            database = new ProductContext();
        }
        public ProductModel GetProductModelById(int productId) {
            var product = database.Products.Find(productId);
            if(product == null) return null;

            return new ProductModel {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price.ToString("0.##"),
                ImagePath = $"/Content/Images/product-item{product.Id}.jpg",
                Description = product.Description,
                Cantitate = product.Cantitate.ToString(),
                NewPrice = product.NewPrice?.ToString("0.##"),
                IsOnSale = product.IsOnSale,
                ImageFileName = product.ImageFileName
            };
        }
        public bool ValidateProductDate(ProductModel product) {
            if(!int.TryParse(product.Cantitate, out int cantitate) || cantitate <= 0)
                return false;

            if(!decimal.TryParse(product.Price, out decimal price) || price <= 0)
                return false;

            if(product.IsOnSale) {
                if(string.IsNullOrEmpty(product.NewPrice) || !decimal.TryParse(product.NewPrice, out decimal parsedNewPrice) || parsedNewPrice <= 0)
                    return false;
            }

            if(!string.IsNullOrEmpty(product.ImagePath)) {
                var serverPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, product.ImagePath.TrimStart('~', '/').Replace("/", "\\"));
                if(!File.Exists(serverPath))
                    return false;
            }

            return true;
        }

        public bool ValidProductIMG(string imagePath, string serverRootPath) {
            if(string.IsNullOrEmpty(imagePath))
                return false;

            var fullPath = Path.Combine(serverRootPath, imagePath.TrimStart('~', '/').Replace('/', Path.DirectorySeparatorChar));
            return File.Exists(fullPath);
        }

        public void SaveProductDB(ProductModel model) {
            int cantitate = int.Parse(model.Cantitate);
            decimal price = decimal.Parse(model.Price);
            decimal? newPrice = string.IsNullOrEmpty(model.NewPrice) ? (decimal?)null : decimal.Parse(model.NewPrice);

            string imageFileName = Path.GetFileName(model.ImagePath);

            var product = new UDdProducts {
                Name = model.Name,
                Description = model.Description,
                Cantitate = cantitate,
                Price = price,
                NewPrice = newPrice,
                IsOnSale = model.IsOnSale,
                ImagePath = model.ImagePath,
                ImageFileName = imageFileName
            };

            database.Products.Add(product);
            database.SaveChanges();
        }

        public List<ProductModel> GetAllProducts() {
            var products = database.Products.ToList();

            var viewModels = products.Select(p => new ProductModel {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Cantitate = p.Cantitate.ToString(),
                Price = p.Price.ToString("0.##"),
                NewPrice = p.NewPrice?.ToString("0.##"),
                IsOnSale = p.IsOnSale,
                ImagePath = p.ImagePath,
                ImageFileName = p.ImageFileName
            }).ToList();

            return viewModels;
        }

        public bool DeleteProduct(int id) {
            var product = database.Products.Find(id);
            if(product == null)
                return false;

            database.Products.Remove(product);
            database.SaveChanges();
            return true;
        }
    }
}
