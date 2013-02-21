using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;


namespace Tools
{
    /// <summary>
    ///SendMail 的摘要说明
    /// </summary>
    public class SendMail
    {
        public SendMail()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //sss
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="strFrom">From</param>
        /// <param name="strSender">Sender</param>
        /// <param name="strReplyTo">回复地址</param>
        /// <param name="listTo">收件人</param>
        /// <param name="listCC">抄送人</param>
        /// <param name="strSubject">主题</param>
        /// <param name="strBody">内容</param>
        public static void SendMailGmail(string strFrom, string strSender, string strReplyTo, string strTo, string strCC, string strSubject, string strBody)
        {
            MailAddress from = new MailAddress(strFrom);
            MailAddress to = new MailAddress(strTo);
            if (strCC != string.Empty)
            {
                MailAddress cc = new MailAddress(strCC);
            }
            MailMessage message = new MailMessage(from, to);
            message.CC.Add(new MailAddress(strCC));
            message.Subject = strSubject;
            message.Body = strBody;
            message.IsBodyHtml = true;
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Port = 25;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("cysccemail@gmail.com", "cyscc@email");
            client.Send(message);
        }

        public static void SendMail163(string strFrom, string strSender, string strReplyTo, string strTo, string strCC, string strSubject, string strBody)
        {
            MailAddress from = new MailAddress(strFrom);
            MailAddress to = new MailAddress(strTo);
            if (strCC != string.Empty)
            {
                MailAddress cc = new MailAddress(strCC);
            }
            MailMessage message = new MailMessage(from, to);
            message.CC.Add(new MailAddress(strCC));
            message.Subject = strSubject;
            message.Body = strBody;
            message.IsBodyHtml = true;
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Port = 25;
            client.Host = "smtp.163.com";
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("csrpioneers", "horizoni");
            client.Send(message);
        }
        public static void SendMailhbu(string strFrom, string strSender, string strReplyTo, string strTo, string strCC, string strSubject, string strBody)
        {
            MailAddress from = new MailAddress(strFrom);
            MailAddress to = new MailAddress(strTo);
            if (strCC != string.Empty)
            {
                MailAddress cc = new MailAddress(strCC);
            }
            MailMessage message = new MailMessage(from, to);
            message.CC.Add(new MailAddress(strCC));
            message.Subject = strSubject;
            message.Body = strBody;
            message.IsBodyHtml = true;
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Port = 25;
            client.Host = "mail.hbu.cn";
            //client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("haodongliang", "hao@nic-hbu");
            client.Send(message);
        }
    }
}