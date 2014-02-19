namespace JulianPerrottName.Areas.Home.Controllers
{
    using System;
    using System.Net;
    using System.Net.Mail;
    using System.Text;
    using System.Web.Mail;
    using System.Web.Mvc;

    public class ContactController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Send(string email, string name, string message)
        {
            string toemail = "julian.perrott@gmail.com";
            string smtpServer = "mail.julianperrott.name";
            string smtpUserName = "postmaster@julianperrott.name";
            string smtpPassword = "qwerty69";

            var mail = new System.Net.Mail.MailMessage
            {
                From = new MailAddress(toemail, smtpUserName),
                Subject = string.Format("Codesin.net: Mail from {0}", name),
                IsBodyHtml = true
            };

            mail.To.Add(mail.From);
            var body = new StringBuilder();
            body.Append("<div style=\"font: 11px verdana, arial\">");
            body.Append(message);
            body.Append("<br /><br />");
            body.Append("from " + email + " " + name);

            if (System.Web.HttpContext.Current != null)
            {
                body.Append(
                    "<br /><br />_______________________________________________________________________________<br /><br />");
                body.AppendFormat("<strong>IP address:</strong> {0}<br />", GetClientIP());
                body.AppendFormat("<strong>User-agent:</strong> {0}", System.Web.HttpContext.Current.Request.UserAgent);
            }

            body.Append("</div>");
            mail.Body = body.ToString();

            SendMailMessage(mail, smtpServer, smtpUserName, smtpPassword);

            return this.View();
        }

        public static string GetClientIP()
        {
            var context = System.Web.HttpContext.Current;
            if (context != null)
            {
                var request = context.Request;
                if (request != null)
                {
                    string xff = request.Headers["X-Forwarded-For"];
                    string clientIP = string.Empty;
                    if (!string.IsNullOrWhiteSpace(xff))
                    {
                        int idx = xff.IndexOf(',');
                        if (idx > 0)
                        {
                            // multiple IP addresses, pick the first one
                            clientIP = xff.Substring(0, idx);
                        }
                        else
                        {
                            clientIP = xff;
                        }
                    }

                    return string.IsNullOrWhiteSpace(clientIP) ? request.UserHostAddress : clientIP;
                }
            }

            return string.Empty;
        }

        public string SendMailMessage(System.Net.Mail.MailMessage message, string smtpServer, string smtpUserName, string smtpPassword)
        {
            StringBuilder errorMsg = new StringBuilder();
            bool boolSssl = false;
            int intPort = 25;

            try
            {
                message.IsBodyHtml = true;
                message.BodyEncoding = Encoding.UTF8;
                var smtp = new SmtpClient(smtpServer);

                // don't send credentials if a server doesn't require it,
                if (!string.IsNullOrEmpty(smtpUserName))
                {
                    smtp.Credentials = new NetworkCredential(smtpUserName, smtpPassword);
                }

                smtp.Port = intPort;
                smtp.EnableSsl = boolSssl;
                smtp.Send(message);
            }
            finally
            {
                // Remove the pointer to the message object so the GC can close the thread.
                message.Dispose();
            }

            return errorMsg.ToString();
        }

    }
}