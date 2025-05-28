using System.Configuration;
using System.Net.Mail;
using System;
using WEB_Proje.BussinesLogic.Interface.ProductInterface;
using WEB_Proje.Domain.Models.Product;

public class OrderLogic : IOrderInterface {
    public bool OrderClient(OrderModel order) {
        string adminEmail = ConfigurationManager.AppSettings["AdminEmail"];

        string subject = "Noua Comandă de pe site";
        string body = $"Produs: {order.ProductName}\n" +
                      $"Cantitate: {order.Cantitate}\n" +
                      $"Telefon: {order.Phone}\n" +
                      $"Posta: {order.Posta}";

        try {
            MailMessage mail = new MailMessage();
            mail.To.Add(adminEmail);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = false;
            mail.From = new MailAddress(ConfigurationManager.AppSettings["AdminEmail"]);

            SmtpClient smtp = new SmtpClient();
            smtp.Send(mail);

            return true; // Если всё прошло успешно
        }
        catch(Exception) {
            // Логирование ошибки можно добавить здесь
            return false; // Если произошла ошибка
        }
    }
}
