using System;
using System.Collections.Generic;
using System.Text;

namespace zip_folder_console_app.Models
{
    public class EmailConfig
    {
        public string Sender { get; private set; }
        public string SmtpServer { get; private set; }
        public int Port { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public EmailConfig()
        {
            
        }

        public void SetSender(string sender)
        {
            Sender = sender;
        }

        public void SetSmtpServer(string smtpServer)
        {
            SmtpServer = smtpServer;
        }

        public void SetPort(int port)
        {
            Port = port;
        }

        public void SetUsername(string username)
        {
            Username = username;
        }

        public void SetPassword(string password)
        {
            Password = Encoding.UTF8.GetString(Convert.FromBase64String(password));
        }
    }
}
