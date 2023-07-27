using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using MimeKit;
using PharmaCare.Models.DTO;

namespace PharmaCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailSendController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendEmail(EmailDTO emailDTO)
        {


            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("pharamacare@gmail.com"));
            email.To.Add(MailboxAddress.Parse(emailDTO.email));

            email.Subject = "Order Confirmation Email";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = emailDTO.body };
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate("pharamacare@gmail.com", "ykocyltjuhioyunl");
            
            smtp.Send(email);
            smtp.Disconnect(true);
            return Ok();
        }

    }
}
