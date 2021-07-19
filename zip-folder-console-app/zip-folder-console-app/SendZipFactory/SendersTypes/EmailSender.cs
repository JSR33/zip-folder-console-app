using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using zip_folder_console_app.Models;

namespace zip_folder_console_app.SendZipFactory.SendersTypes
{
    public class EmailSender: ISendZip
    {
        public bool Send(string outputParameters, string zipFilePath)
        {
            var emailConfig = SetParameter();
            try
            {
                using (MailMessage mm = new MailMessage(emailConfig.Sender, outputParameters))
                {
                    mm.Subject = "Subject Example";
                    mm.Body = "Zip Folder Project";
                    mm.Attachments.Add(new Attachment(zipFilePath));
                    mm.IsBodyHtml = false;

                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = emailConfig.SmtpServer;
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential(emailConfig.Username, emailConfig.Password);
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = emailConfig.Port;
                        smtp.Send(mm);
                    }
                }

                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine("ERROR - " + e.Message);
                Console.WriteLine("Note that if you have 2nd authentication, the process could fail");
                return false;
            }
        }

        private EmailConfig SetParameter()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appSettings.json", true, true);
            var config = builder.Build();

            var emailConfig = new EmailConfig();
            emailConfig.SetSender(config["EmailConfiguration:From"]);
            emailConfig.SetSmtpServer(config["EmailConfiguration:SmtpServer"]);
            emailConfig.SetPort(Convert.ToInt32(config["EmailConfiguration:Port"]));
            emailConfig.SetUsername(config["EmailConfiguration:Username"]);
            emailConfig.SetPassword(config["EmailConfiguration:Password"]);

            return emailConfig;
        }
    }
}
