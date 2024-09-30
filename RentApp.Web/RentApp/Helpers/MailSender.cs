using RentApp.Models;
using System.Net.Mail;
using System.Net;

namespace RentApp.Helpers
{
    public static class MailSender
    {
        private const string SenderMail = "denemerentapp@outlook.com";
        private const string SenderPassword = "fahmgzghfprlvsyi";


        public static void SendReservationMail(string fullName, List<string> Email, string Title, string Adress, string ownerEmail ,DateTime CheckinDate, DateTime CheckoutDate, decimal TotalPrice)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(SenderMail);
                for (int i = 0; i < Email.Count; i++)
                {
                    mailMessage.To.Add(Email[i]);
                }
                // HTML gövdesi, rezervasyon bilgilerini içerir
                string body = $"<!DOCTYPE html>\r\n<html>\r\n<head>\r\n   " +
                    "<meta charset=\"utf-8\" />\r\n<title></title>\r\n" +
                    "<style>\r\nbody{{background-color:#f3f3f3;color:black;}}\r\n</style>\r\n</head>\r\n<body>\r\n" +
                    $"<h1>Sayın {fullName},</h1>\r\n" +
                    $"<p>Rezervasyonunuz başarıyla oluşturulmuştur. İşte detaylar:</p>\r\n" +
                    $"<p><b>Ev:</b> {Title}</p>\r\n" +
                    $"<p><b>Adres:</b> {Adress}</p>\r\n" +
                    $"<p><b>Ev Sahibinin Mail Adresi:</b> {ownerEmail}</p>\r\n" +
                    $"<p><b>Giriş Tarihi:</b> {CheckinDate.ToString("dd MMMM yyyy")}</p>\r\n" +
                    $"<p><b>Çıkış Tarihi:</b> {CheckoutDate.ToString("dd MMMM yyyy")}</p>\r\n" +
                    $"<p><b>Toplam Fiyat:</b> {TotalPrice:C} TL</p>\r\n" +
                    $"<p>Teşekkür ederiz! Eğer Rezervasyonunuzu iptal etmek isterseniz (son 5 gün kala iptal edebilirsiniz) ev sahibine mail atabilirsiniz ya da bize sitemizdeki İletişim bölümünden ulaşırsanız biz size yardımcı oluruz.Sağlıklı Günler dileriz.</p>\r\n" +
                    "</body>\r\n</html>";

                mailMessage.Subject = "Rezervasyon Bilgileriniz";
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp-mail.outlook.com";
                smtpClient.Port = 587;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(SenderMail, SenderPassword);
                smtpClient.EnableSsl = true;

                smtpClient.Send(mailMessage);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("E-posta gönderimi hatası: " + ex.Message);
            }
        }
        private static void ResetPassword(string fullname, string mailAddress)
        {

        }
        private static void ConfirmEmail(string fullname, string mailAddress)
        {

        }
        private static void Welcome(string fullname, string mailAddress)
        {

        }

        private static async Task HolidayMessage(List<User> users)
        {
            for (int i = 0; i < users.Count; i++)
            {
                try
                {
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress(SenderMail);

                    mailMessage.To.Add(users[i].Email);

                    string body = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n   " +
                        " <meta charset=\"utf-8\" />\r\n    <title></title>\r\n  " +
                        "  <style>\r\n        body{\r\n       " +
                        "     background-color:red;\r\n        " +
                        "    color:white;\r\n        }\r\n " +
                        "   </style>\r\n</head>\r\n<body>\r\n " +
                        "   <h1>Merhaba, hoşgeldiniz</h1>\r\n  " +
                        "  <p>sizi görmek güzel</p>\r\n</body>\r\n</html>";

                    mailMessage.Subject = "Hoş geldiniz";
                    mailMessage.Body = body; // $"<h1> Merhaba {fullname},</h1> \n Sitemize hoşgeldin.";
                    mailMessage.IsBodyHtml = true;

                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Host = "smtp-mail.outlook.com";
                    smtpClient.Port = 587;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(SenderMail, SenderPassword);
                    smtpClient.EnableSsl = true;


                    await smtpClient.SendMailAsync(mailMessage);
                    Console.WriteLine("Email Sent Successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
