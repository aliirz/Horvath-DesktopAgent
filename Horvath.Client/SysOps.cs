using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
namespace Horvath.Client
{
    public class SysOps
    {
        public void LockComputer()
        {
            if (!LockWorkStation())


                throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        public void SendMail(string to, string subj, string msg, string fileName)
        {
            var fromAddress = new MailAddress("disturbedfat@gmail.com", "Fahad Tariq");
            var toAddress = new MailAddress("smallassasin@gmail.com", "Yawar Shah");
            const string fromPassword = "ftmfh@t!c3";
            const string subject = "From Balthazar";
            const string body = "Please find that file you required attached with that email.";
            Attachment attachment = new Attachment("C:\\Users\\ali\\Pictures\\hungry.jpg");
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            
                var message = new MailMessage(fromAddress, toAddress);
            
                message.Subject = subject;
                message.Body = body;
                message.Attachments.Add(attachment);
            
                smtp.Send(message);
            

        }

        //public static bool ExitWindowsEx(ExitWindowsFlags uFlag)
        //{
        //    return ExitWindowsEx(uFlag, 0);
        //}

        /// <summary>
        /// Extern functions here.
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool LockWorkStation();
        //public static extern bool ExitWindowsEx(ExitWindowsFlags uFlag, UInt32 dwReserved);



        //[Flags]
        //public enum ExitWindowsFlags
        //{
        //    EWX_LOGOFF = 0,
        //    EWX_SHUTDOWN = 0x1,
        //    EWX_REBOOT = 0x2,
        //    EWX_FORCE = 0x4,
        //    EWX_POWEROFF = 0x8,
        //    EWX_FORCEIFHUNG = 0x10,
        //    EWX_RESTARTAPPS = 0x40
        //}

    }




}

