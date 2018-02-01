using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CodeFirstExample.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace CodeFirstExample.AccountAdder
{
    public static class AccountAdder
    {
        [FunctionName("AccountAdder")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("Received new account request");
            HttpResponseMessage response;
            try
            {
                var user = await req.Content.ReadAsAsync<User>();
                if(user != null)
                {
                    log.Info("Saving to database");
                    using(var db = new BankContext())
                    {
                        db.Users.Add(user);
                        await db.SaveChangesAsync();
                    }
                    response = req.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    var errorMessage = "Failed to parse user";
                    log.Error(errorMessage);
                    response = req.CreateErrorResponse(HttpStatusCode.BadRequest, errorMessage);
                }
            }
            catch(Exception e)
            {
                log.Error(e.Message, e);
                response = req.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            return response;
        }
    }
}
