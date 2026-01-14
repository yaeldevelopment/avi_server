using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Macs;
using System.Net;
using System.Net.Mail;



namespace WebApplication14.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FunctionController : Controller
    {
        // GET: api/email/send
        [HttpGet("send")]
        public void SendEmail()
        {
            try
            {
                var message = new MailMessage(
                    "tripyaeleden@gmail.com",
                    "y0556722091@gmail.com",
                    "Subject",
                    "Message body"
                );

                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(
                        "tripyaeleden@gmail.com",
                        "urof ehie vwrt bxmp"   // App Password, לא סיסמה רגילה
                    ),
                    EnableSsl = true
                };

                client.Send(message);
                Console.WriteLine("Email sent!");
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.Message);
            }
        } }

        }
