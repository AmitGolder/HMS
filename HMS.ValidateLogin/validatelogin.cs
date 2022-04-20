using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace HMS.ValidateLogin
{
    public static class validatelogin
    {
        [FunctionName("validatelogin")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req,
            ILogger log)
        {
            var AdminRedirectUri = Environment.GetEnvironmentVariable("Admin_Redirect_URI");
            var PatientRedirectURI = Environment.GetEnvironmentVariable("Patient_Redirect_URI");
            string Users = req.Query["Users"];
            try
            {
                if (Users.ToUpper() == "ADMIN")
                {
                    return new RedirectResult(AdminRedirectUri);
                }
                else
                {
                    return new RedirectResult(PatientRedirectURI);
                }
            }
            catch (Exception ex)
            {
                return new OkObjectResult(ex.Message);
            }
        }
    }
}
