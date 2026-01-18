using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Macs;
using System.Net;
using System.Net.Mail;
using WebApplication14.Models;



namespace WebApplication14.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FunctionController : Controller
    {
        // GET: api/email/send

        [HttpPost("SendEmail")]
        public async Task<IActionResult> SendEmail([FromBody] Customer customer)
        {
            var body = $@"
                <html>
                <head>
                <meta charset='UTF-8'>
                </head>
                <body style='direction: rtl; text-align: right; font-family: Arial, sans-serif;'>
                <h2>שלום רב,</h2>
              <p>  שם: {customer.FirstName} {customer.LastName}<br/></p>
                          <p>  טלפון: {customer.Phone} <br/></p>
              <p>  אימייל: {customer.Email} <br/></p>
           
            <p>  הודעה: {customer.Message}<br/></p>
                </body>
                </html>";



            try
            {
                await Helper.SendEmailAsync(Environment.GetEnvironmentVariable("to_Email"),"פניית לקוח", body);

                return Ok("Email sent");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Email failed to send: {ex.Message}");
            }
        }

    }
}
