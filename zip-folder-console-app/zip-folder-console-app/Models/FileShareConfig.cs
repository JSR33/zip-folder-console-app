using System;
using System.Collections.Generic;
using System.Text;

namespace zip_folder_console_app.Models
{
    public class FileShareConfig
    {
        public string ServerName { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public void SetServerName(string serverName)
        {
            ServerName = serverName;
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
