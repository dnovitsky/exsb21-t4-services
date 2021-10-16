using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mail;

namespace GmailAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            //MailAddress from = new MailAddress("danik_fin2001@mail.ru", "Daniil");
            MailAddress from = new MailAddress("danik_fin2001@mail.ru", "Daniil");
            // кому отправляем
            //MailAddress to = new MailAddress("fin.dan171@gmail.com");
            MailAddress to = new MailAddress("danik_fin2001@mail.ru");
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Тест";
            // текст письма
            m.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            //Mail.ru
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("danik_fin2001@mail.ru", "password");

            smtp.EnableSsl = true;
            smtp.Send(m);
            Console.WriteLine("Message was sent!");
            //try
            //{
            //    smtp.Send(m);
            //}
            //catch (SmtpFailedRecipientsException ex)
            //{
            //    for (int i = 0; i < ex.InnerExceptions.Length; i++)
            //    {
            //        SmtpStatusCode status = ex.InnerExceptions[i].StatusCode;
            //        if (status == SmtpStatusCode.MailboxBusy ||
            //            status == SmtpStatusCode.MailboxUnavailable)
            //        {
            //            Console.WriteLine("Delivery failed - retrying in 5 seconds.");
            //            System.Threading.Thread.Sleep(5000);
            //            smtp.Send(m);
            //        }
            //        else
            //        {
            //            Console.WriteLine("Failed to deliver message to {0}",
            //                ex.InnerExceptions[i].FailedRecipient);
            //        }
            //    }
            //    Console.WriteLine();
            //    Console.WriteLine();
            //    Console.WriteLine();
            //    Console.WriteLine();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Exception caught in RetryIfBusy(): {0}",
            //            ex.ToString());
            //}
            Console.Read();
        }
    }
}
