using System;
using System.Text;

namespace api.Services.EmailService
{
	public interface IEmailService
	{
		void SendEmail(string toEmail, string subject, StringBuilder body);
	}
}

