using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TopluEmail
{
    class Program
    {
        static void EmailGonder(string kime , string konu, string icerik)
        {
            static void EmailGonder(string Kime, string Konu, string Icerik)
            {

                Encoding encode = Encoding.GetEncoding("Windows - 1254");


                MailMessage Email = new MailMessage();

                //(1. Yöntem) Email.To.Add("Mail Adresi");
                //(2. Yöntem) MailAdress To1 = new MailAdress("Mail Adresi1", "Mail Adresi Sahibi", encode);

                MailAddress MailFrom = new MailAddress("GöndericiMailAdresi", "Display adı (Gönderici olarak görünen ad)", encode)



                //Üst satır mailin kimden gittiği
                //(2. Yöntemdeki adresin kullanılma biçimi)Email.To.Add(To1);

                // Email.Bcc.Add(""); Emaili alan kişi, liste içerisinde tanımlı olan kişi veya kişileri göremez.
                //Email.CC.Add(""); Emaili alan kişi, liste içerisinde tanımlı olan kişi veya kişileri görebilir.

                Email.From = MailFrom;
                Email.Subject = Konu;
                Email.Body = Icerik;

                Email.IsBodyHtml = true;

                Email.Attachments.Add(new Attachment(@"Eklenecek dosyanın yolu"));


                SntpClient sntpMail = new SntpClient("ClientAdı", Portnumarası); /*eğer gönderenin exchange 
                sunucusu üzerinden gönderim yapılacaksa 25 ya da 587 olarak da denenebilir. Ancak
                bu proje SNTP Server üzerinden gönderilecek şekilde hazırlandı */
                SntpClient.Credentails = new System.Net.NetworkCredential("Kullanıcı adı", "Şifre");
                sntpMail.EnableSsl = false; /* Gönderici mail adresimiz SSL kullanıyor olabilir. 
                Bu sebeple EnableSsl değerini false olarak belirledik */
                sntpMail.Send(Email);
            }
        }
    }
}
