using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SAPexSMTPMailService.Models;
using SAPexSMTPMailService.Interfaces;

namespace SAPexSMTPMailService.Services
{
    public class SendMailService : ISendMailService
    {
        public static MailSettingsModel _mailSettingsModel;
        public static MailAddress from;
        public static MailAddress to;
        public static SmtpClient smtp;
        public static MailMessage m;

        public SendMailService(IOptions<MailSettingsModel> settings)
        {
            _mailSettingsModel = settings.Value;
        }

        public bool MainProcess(string head, string message, string mailTo)
        {
            try
            {
                string address = _mailSettingsModel.SMTPAddress;
                string password = _mailSettingsModel.SMTPPassword;
                string cfgHost = _mailSettingsModel.SMTPHost;
                int cfgPort = _mailSettingsModel.SMTPPort;

                CreateSMTPClient(address, password, cfgHost, cfgPort);
                SendMessage(address, head, message, mailTo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        static void CreateSMTPClient(string address, string password, string cfgHost, int cfgPort)
        {
            try
            {
                smtp = new SmtpClient(cfgHost, cfgPort);
                // логин и пароль
                smtp.Credentials = new NetworkCredential(address, password);

                smtp.EnableSsl = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
        }

        static void SendMessage(string address, string head, string message, string mailTo)
        {
            try
            {
                from = new MailAddress(address, "no-reply");
                to = new MailAddress(mailTo);
                m = new MailMessage(from, to);
                m.Subject = head;
                m.Body = $"<h2>{message}</h2>";
                m.IsBodyHtml = true;
                smtp.Send(m);
                Console.WriteLine("Message was sent!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
        }

    }
}
