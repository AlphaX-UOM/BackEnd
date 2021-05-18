using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuggestorCodeFirstAPI;
using SuggestorCodeFirstAPI.Models;

namespace SuggestorCodeFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly RepositoryContext _context;
        private IWebHostEnvironment _hostingEnvironment;

        public PaymentsController(RepositoryContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _hostingEnvironment = environment;
        }

        // GET: api/Payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
        {
            return await _context.Payments.ToListAsync();
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(Guid id)
        {
            var payment = await _context.Payments.FindAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        // PUT: api/Payments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(Guid id, Payment payment)
        {
            if (id != payment.ID)
            {
                return BadRequest();
            }

            _context.Entry(payment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Payments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment(Payment payment)
        {

            var user = await _context.Users
                               .Where(u => u.ID == payment.UserID)
                               .FirstOrDefaultAsync();

            if (user == null)
            {
                return BadRequest();
            }

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            string emailSender = "vvisitalphax@gmail.com";
            string emailSenderPassword = "qwertyuiop0112294169a";
            string emailSenderHost = "smtp.gmail.com";
            int emailSenderPort = 587;
            bool emailIsSSL = true;

            //Fetching Email Body Text from EmailTemplate File.  
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            string path = "";
            path = Path.Combine(contentRootPath, "EmailTemplates", "Payment.html");
            StreamReader str = new StreamReader(path);
            string MailText = str.ReadToEnd();
            str.Close();

            MailText = MailText.Replace("[newusername]", user.FirstName);
            MailText = MailText.Replace("[paymentid]", payment.ID.ToString());
            MailText = MailText.Replace("[paymentvalue]", payment.Amount.ToString());

            string subject = "Vvisit Platform - Payment Success";

            MailMessage _mailmsg = new MailMessage();

            _mailmsg.IsBodyHtml = true;

            _mailmsg.From = new MailAddress(emailSender);

            _mailmsg.To.Add(user.Email);

            _mailmsg.Subject = subject;

            _mailmsg.Body = MailText;

            SmtpClient _smtp = new SmtpClient();

            _smtp.Host = emailSenderHost;

            _smtp.Port = emailSenderPort;

            _smtp.EnableSsl = emailIsSSL;

            NetworkCredential _network = new NetworkCredential(emailSender, emailSenderPassword);
            _smtp.Credentials = _network;
            _smtp.Send(_mailmsg);

            return CreatedAtAction("GetPayment", new { id = payment.ID }, payment);
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Payment>> DeletePayment(Guid id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();

            return payment;
        }

        private bool PaymentExists(Guid id)
        {
            return _context.Payments.Any(e => e.ID == id);
        }
    }
}
