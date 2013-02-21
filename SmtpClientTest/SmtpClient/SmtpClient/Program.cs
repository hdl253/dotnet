using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmtpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1:gmail,2:163,3:hbu");
            try
            {
                Dimac.JMail.Message jM;
                Dimac.JMail.Smtp smtp;
                switch (Console.ReadLine())
                {
                    case "1":
                        Tools.SendMail.SendMailGmail("hdl253@gmail.com", "admin@xiaoxiaotong.org", "admin@xiaoxiaotong.org", "haodongliang@xiaoxiaotong.org", "hdl253@gmail.com", "test", Body());
                        
                        break;
                    case "2":
                        Tools.SendMail.SendMail163("csrpioneers@163.com", "admin@xiaoxiaotong.org", "admin@xiaoxiaotong.org", "haodongliang@xiaoxiaotong.org", "hdl253@163.com", "163"+DateTime.Now, Body());
                        break;
                    case "3":
                        Tools.SendMail.SendMailhbu("haodongliang@hbu.cn", "admin@xiaoxiaotong.org", "admin@xiaoxiaotong.org", "haodongliang@xiaoxiaotong.org", "hdl253@163.com", "hbu"+DateTime.Now, Body());
                        break;
                    case "4":
                        Tools.obMail.SenddMail("haodongliang@hbu.cn", "haodongliang@xiaoxiaotong.org", "hbu"+DateTime.Now, Body());
                        break;
                    case "5":
                        jM = new Dimac.JMail.Message();
                        jM.From.Email = "hdl253@163.com";
                        jM.To.Add(new Dimac.JMail.Address("hdl253@163.com")); 
                        
                        jM.Subject = "163Jmail"+DateTime.Now;
                        jM.BodyHtml = Body();
                        jM.Charset = System.Text.UTF8Encoding.UTF8;
                        
                        smtp = new Dimac.JMail.Smtp();
                        smtp.HostName = "smtp.163.com";
                        smtp.Authentication = Dimac.JMail.SmtpAuthentication.Login;
                        smtp.Domain = "smtp.163.com";
                        smtp.UserName = "hdl253";
                        smtp.Password = "hao@nic-163";
                        smtp.Send(jM);
                        
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.HelpLink);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.TargetSite);
                Console.WriteLine(ex.StackTrace);
            }
            Console.WriteLine("success");
            Console.ReadLine();
        }

        private static string  Body (){
            return @"<div style=""width: 100%; margin: auto; text-align: center;; background-color:#E3E4EB"">
        <div style=""height: 65px;"">
        </div>
        <div>
            <img src=""http://survey.csrpioneers.org/images/index-page_r2_c2.jpg"" /></div>
        <table  style=""background: none repeat scroll 0 0 #DBDBDB; border-color: #C8C9CB;border-style: solid;border-width: 1px 1px 0; width: 482px;"" align=""center"" cellpadding=""0"" cellspacing=""0"" border=""1px""
            >
            <tr>
                <td align=""center"" style=""border-width: 0px; background-image: url('http://survey.csrpioneers.org/images/index-page_r6_c3.jpg');
                    background-repeat: repeat-x;"">
                    <br />
                    <label style=""color: #FF3300;"">
                        与自己认识的人，如朋友或同学发生性关系是安全的。
                    </label>
                    <br /><br />
                    不同意
                    <br /><br />
                </td>
            </tr>
            <tr>
                <td align=""center"" style=""border-style: solid; border-width: 1px 0px 0px 0px; border-color: #C8C9CB;
                    background-image: url('http://survey.csrpioneers.org/images/index-page_r6_c3.jpg'); background-repeat: repeat-x;"">
                    <label style=""color: #FF3300;"">
                        <br />
                    一般而言，艾滋病是可以治愈的。
                    </label>
                    <br /><br />
                    不同意
                    <br /><br />
                </td>
            </tr>
            <tr>
                <td align=""center"" style=""border-style: solid; border-width: 1px 0px 0px 0px; border-color: #C8C9CB;
                    background-image: url('http://survey.csrpioneers.org/images/index-page_r8_c3.jpg'); background-repeat: repeat-x;
                    padding-left: 10px; padding-right: 10px;"">
                    <label style=""color: #FF3300;"">
                        <br />
                    在日常生活中，我们的手等身体一些部位通常是暴露在衣物之外的，由于我们无法完全避免这些部位不与他人发生直接接触，因而与艾滋病病毒感染者一起生活、工作有被感染的危险。
                    </label>
                    <br /><br />
                    不同意
                    <br /><br />
                </td>
            </tr>
            <tr>
                <td align=""center"" style=""border-style: solid; border-width: 1px 0px 0px 0px; border-color: #C8C9CB;
                    background-image: url('http://survey.csrpioneers.org/images/index-page_r6_c3.jpg'); background-repeat: repeat-x;"">
                    <br />
                    <label style=""color: #FF3300;"">
                    身体强壮、免疫力强的不会得艾滋病。
                    </label>
                    <br /><br />
                    不同意
                    <br /><br />
                </td>
            </tr>
            <tr>
                <td align=""center"" style=""border-style: solid; border-width: 1px 0px 0px 0px; border-color: #C8C9CB;
                    background-image: url('http://survey.csrpioneers.org/images/index-page_r6_c3.jpg'); background-repeat: repeat-x;"">
                    <br />
                    <label style=""color: #FF3300;"">
                    只有品德不好/素质差的人才会感染艾滋病病毒
                    </label>
                    <br /><br />
                    不同意
                    <br /><br />
                </td>
            </tr>
            <tr>
                <td align=""center"" style=""border-style: solid; border-width: 1px 0px 0px 0px; border-color: #C8C9CB;
                    background-image: url('http://survey.csrpioneers.org/images/index-page_r6_c3.jpg'); background-repeat: repeat-x;"">
                    <br />
                    <label style=""color: #FF3300;"">
                    感染艾滋病病毒不同于患有艾滋病
                    </label>
                    <br /><br />
                    同意
                    <br /><br />
                </td>
            </tr>
            <tr>
                <td align=""center"" style=""border-style: solid; border-width: 1px 0px 0px 0px; border-color: #C8C9CB;
                    background-image: url('http://survey.csrpioneers.org/images/index-page_r6_c3.jpg'); background-repeat: repeat-x;
                    padding-left: 10px; padding-right: 10px;"">
                    <br />
                    <label style=""color: #FF3300;"">
                    安全套是用来避免怀孕的，所以如果我们服用避孕药物，那么就不需要使用安全套。
                    </label>
                    <br /><br />
                    不同意
                    <br /><br />
                </td>
            </tr>
            <tr>
                <td align=""center"" style=""border-style: solid; border-width: 1px 0px 0px 0px; border-color: #C8C9CB;
                    background-image: url('http://survey.csrpioneers.org/images/index-page_r6_c3.jpg'); background-repeat: repeat-x;"">
                    <br />
                    <label style=""color: #FF3300;"">
                    16.使用热水清洗医疗器械可以保证重复使用和共用的安全性。
                    </label>
                    <br /><br />
                    不同意
                    <br /><br />
                </td>
            </tr>
        </table>
        <div>
            <img src=""http://survey.csrpioneers.org/images/index-page_r21_c2.jpg"" /></div>
        <img src=""http://survey.csrpioneers.org/images/index_r8_c4.jpg"" />
        <br />
        <br />
        <br />
        <br />
    </div>";
        }
    }
}
