using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Security.Principal;
using System.Text;
using zip_folder_console_app.Models;

namespace zip_folder_console_app.SendZipFactory.SendersTypes
{
    public class FileShareSender : ISendZip
    {
        public bool Send(string outputParameters, string zipFilePath)
        {
            var configs = SetParameter();
            try
            {
                using (PrincipalContext tempcontext = new PrincipalContext(ContextType.Domain, configs.ServerName, null, ContextOptions.Negotiate))
                {
                    if(!tempcontext.ValidateCredentials(configs.Username, configs.Password, ContextOptions.Negotiate))
                        throw new Exception("ERROR - Username or Password is incorrect...");
                }

                File.Move(zipFilePath, outputParameters);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR - " + ex.Message);
            }
        }

        private FileShareConfig SetParameter()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appSettings.json", true, true);
            var config = builder.Build();

            var configs = new FileShareConfig();
            configs.SetServerName(config["FileShareConfiguration:ServerName"]);
            configs.SetUsername(config["FileShareConfiguration:Username"]);
            configs.SetPassword(config["FileShareConfiguration:Password"]);

            return configs;
        }
    }
}
