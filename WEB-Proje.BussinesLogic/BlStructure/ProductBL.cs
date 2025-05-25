
using System;
using System.IO;
using WEB_Proje.BussinesLogic.DBModel;
using WEB_Proje.Domain.Entities;
using WEB_Proje.Domain.Product;


    namespace WEB_Proje.BussinesLogic.BlStructure {
    public class ProductBL {
        // Conectare DB a produselor
        private readonly ProductContext database;

        // Initializare
        public ProductBL() {
            database = new ProductContext();
        }

        // Validarea datelor
        public bool ValidateProductDate(ProductModel product) {
            if(!int.TryParse(product.Cantitate, out int cantitate) || cantitate <= 0) {
                return false;
            }

            if(!decimal.TryParse(product.Price, out decimal price) || price <= 0) {
                return false;   
            }

            if(product.IsOnSale) {
                if(string.IsNullOrEmpty(product.NewPrice) || !decimal.TryParse(product.NewPrice, out decimal parsedNewPrice) || parsedNewPrice <= 0) {
                    return false;
                }
            }

            if(!string.IsNullOrEmpty(product.ImagePath)) {
                var serverPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, product.ImagePath.TrimStart('~', '/').Replace("/", "\\"));
                if(!File.Exists(serverPath))
                    return false;
            }

            return true;
        }

        // Validarea imaginii
        public bool ValidProductIMG(string imagePath, string serverRootPath) {
            if(string.IsNullOrEmpty(imagePath)) {
                return false;
            }

            var fullPath = Path.Combine(serverRootPath, imagePath.TrimStart('~', '/').Replace('/', Path.DirectorySeparatorChar));
            return System.IO.File.Exists(fullPath);
        }


        // Salvare product
        public void SaveProductDB(ProductModel model, ProductContext db) {
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

            db.Products.Add(product);
            db.SaveChanges();
        }

        // Stergere Produs
    }
}
