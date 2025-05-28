using System;
using WEB_Proje.BussinesLogic.BlStructure;
using WEB_Proje.Domain.Product;
using WEB_Proje.Domain.Entities.User;

namespace WEB_Proje.BussinesLogic.Core {
    public class AdminAPI : UserEntity {
        private readonly ProductBL productBL;

        public AdminAPI(UserDateLogin user) : base(user) {
            productBL = new ProductBL();
        }

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
                productBL.SaveProductDB(model);
                return true;
            }
            catch(Exception ex) {
                errorMessage = "Eroare la salvare: " + ex.Message;
                return false;
            }
        }

        public bool DeleteProduct(int productId, out string errorMessage) {
            errorMessage = null;

            if(!productBL.DeleteProduct(productId)) {
                errorMessage = "Produsul nu a fost găsit sau nu a putut fi șters.";
                return false;
            }

            return true;
        }
    }
}
