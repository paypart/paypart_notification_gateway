using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using paypart_notification_gateway.Models;
using paypart_notification_gateway.Services;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.AspNetCore.Authorization;

namespace paypart_notification_gateway.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/email")]
    public class EmailController : Controller
    {
        IOptions<Settings> settings;
        IDistributedCache cache;

        public EmailController(IOptions<Settings> _settings, IDistributedCache _cache)
        {
            settings = _settings;
            cache = _cache;
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(NotificationError), 400)]
        [ProducesResponseType(typeof(NotificationError), 500)]
        public async Task<IActionResult> send([FromBody]EmailMetaData emd)
        {
            NotificationError e = new NotificationError();
            Utility utility = new Utility();
            bool isSent = false;

            //validate request
            if (!ModelState.IsValid)
            {
                var modelErrors = new List<NotificationError>();
                var eD = new List<string>();
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var modelError in modelState.Errors)
                    {
                        eD.Add(modelError.ErrorMessage);
                    }
                }
                e.error = ((int)HttpStatusCode.BadRequest).ToString();
                e.errorDetails = eD;

                return BadRequest(e);
            }

            try
            {
                emd.fromaddress = settings.Value.emailFromAddress;
                Smtp smtp = new Smtp()
                {
                    enablessl = settings.Value.emailEnableSSL,
                    host = settings.Value.emailHost,
                    port = settings.Value.emailPort
                };

                emd.protocol = smtp;
                
                isSent = await utility.SendMail(emd);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return CreatedAtAction("send", isSent);
        }
    }
}