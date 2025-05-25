using WEB_Proje.BussinesLogic.DBModel;
using WEB_Proje.Domain.Product;
using WEB_Proje.BussinesLogic.BlStructure;
using System;
using WEB_Proje.Domain.Entities.User;

namespace WEB_Proje.BussinesLogic.Core {
    public class AdminAPI : UserEntity {
        private readonly ProductBL productBL;
        private readonly ProductContext db;

        public AdminAPI(UserDateLogin user) : base(user) {
            productBL = new ProductBL();
            db = new ProductContext();
        }

        // Adaugare Produs
        public bool AddProduct(ProductModel model, string serverRootPath, out string errorMessage) {
            errorMessage = null;

            if(!productBL.ValidateProductDate(model)) {
                errorMessage = "Datele produsului nu sunt valide.";
                return false;
            }

            if(!productBL.ValidProductIMG(model.ImagePath, serverRootPath)) {
                errorMessage = "Imaginea nu este validă sau nu există.";
                return false;
            }

            try {
                productBL.SaveProductDB(model, db);
                return true;
            }
            catch(Exception ex) {
                errorMessage = "Eroare la salvare: " + ex.Message;
                return false;
            }
        }

        // Stergere Produss
        public bool DeleteProduct(int productId, out string errorMessage) {
            errorMessage = null;
            var product = db.Products.Find(productId);
            if(product == null) {
                errorMessage = "Produsul nu a fost gasit.";
                return false;
            }

            db.Products.Remove(product);
            db.SaveChanges();
            return true;
        }


    }
}
