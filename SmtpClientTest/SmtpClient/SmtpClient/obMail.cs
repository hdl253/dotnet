using System;
using System.Web.Mail;

namespace Tools
{
	/// <summary>
	/// obMail 的摘要说明。
	/// </summary>
	public class obMail
	{
		public obMail()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 发送邮件
		/// <summary>
		/// 发送邮件
		/// </summary>
		/// <Author>Terminate</Author>
		/// <CreateTime>2006-10-1</CreateTime>
		/// <param name="MailFrom">寄信人[寄信人地址]</param>
		/// <param name="MailTo">收信人地址</param>
		/// <param name="MailSubject">信件标题</param>
		/// <param name="MailBody">信件内容</param>
		public static void SenddMail(string MailFrom,string MailTo,string MailSubject,string MailBody)
		{
			string SmtpServer,UserName,UserPwd;
			bool MailCheck;
			SmtpServer="mail.hbu.cn";
			UserName="haodongliang";
			UserPwd="hao@nic-hbu";
			MailCheck=true;

			MailMessage MailObj=new MailMessage();
			SmtpMail.SmtpServer=SmtpServer;
			if(MailCheck)
			{
				//认证
				MailObj.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate","1");//认证方式1认证；0不认证
				//用户名
				MailObj.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername",UserName);
				//密码
				MailObj.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword",UserPwd);
			}
			MailObj.From		=MailFrom;			//发件人
			MailObj.To			=MailTo;			//收件人
			MailObj.Subject		=MailSubject;		//邮件标题
			MailObj.Priority	=MailPriority.High;	//邮件等级
			MailObj.BodyFormat	=MailFormat.Html;	//邮件内容格式
			MailObj.Body		=MailBody;			//邮件内容			
			SmtpMail.Send(MailObj);
		}
		#endregion

		#region 发送邮件（服务器参数）
		/// <summary>
		/// 发送邮件（服务器参数）
		/// </summary>
		/// <Author>Terminate</Author>
		/// <CreateTime>2006-10-1</CreateTime>
		/// <param name="SmtpServer">Smtp服务器地址</param>
		/// <param name="UserName">用户名</param>
		/// <param name="UserPwd">密码</param>
		/// <param name="MailFrom">寄信人[寄信人地址]</param>
		/// <param name="MailTo">收信人地址</param>
		/// <param name="MailSubject">信件标题</param>
		/// <param name="MailBody">信件内容</param>
		/// <param name="MailCheck">服务器认证</param>
		public static void SendMail(string SmtpServer,string UserName,string UserPwd,string MailFrom,string MailTo,string MailSubject,string MailBody,bool MailCheck)
		{ 
			MailMessage MailObj=new MailMessage();
			SmtpMail.SmtpServer=SmtpServer;
			if(MailCheck)
			{
				//认证
				MailObj.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate","1");//认证方式1认证；0不认证
				//用户名
				MailObj.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername",UserName);
				//密码
				MailObj.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword",UserPwd);
			}
			MailObj.From		=MailFrom;			//发件人
			MailObj.To			=MailTo;			//收件人
			MailObj.Subject		=MailSubject;		//邮件标题
			MailObj.Priority	=MailPriority.High;	//邮件等级
			MailObj.BodyFormat	=MailFormat.Html;	//邮件内容格式
			MailObj.Body		=MailBody;			//邮件内容			
			SmtpMail.Send(MailObj);
		}
		#endregion
	}
}
