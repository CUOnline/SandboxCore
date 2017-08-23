using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SandboxCore.Models;
using SandboxCore.Clients;
using SandboxCore.Clients.Models;
using Microsoft.AspNetCore.Http;
using System.Xml;
using Microsoft.AspNetCore.Hosting;
using System.Xml.Linq;
using System.Text;

namespace SandboxCore.Controllers
{
    public class SandboxController : Controller
    {
        private Dictionary<string, string> LtiParams = new Dictionary<string, string>();

        private readonly IHostingEnvironment hostingEnvironment;

        public SandboxController(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var configDoc = XDocument.Load(hostingEnvironment.WebRootPath + "/content/lti_config.xml");
            
            StringBuilder sb = new StringBuilder(configDoc.ToString());
            sb.Replace("{LaunchUrl}", Environment.GetEnvironmentVariable("LaunchUrl"));
            sb.Replace("{MountPoint}", Environment.GetEnvironmentVariable("MountPoint"));

            return new ContentResult() { Content = sb.ToString(), ContentType = "text/xml" };
        }

        [HttpPost]
        public async Task<IActionResult> CreateSandbox()
        {
            var model = new SandboxViewModel()
            {
                StatusCode = 200
            };
            
            var ltiParams = ParseLtiParams(HttpContext.Request.Form);
            
            if (IsValidLtiRequest(Request, ltiParams) 
                && ltiParams["ext_roles"].Contains("Administrator") 
                || ltiParams["ext_roles"].Contains("Instructor"))
            {
                // Api request to create new course
                CourseClient courseClient = new CourseClient(long.Parse(Environment.GetEnvironmentVariable("SandboxAccountId")));
                var courseName = $"sandbox_{ltiParams["lis_person_name_full"]}".Replace("_", " ");
                Course createdCourse = await courseClient.CreateCourse(courseName);
                
                EnrollmentsClient enrollmentclient = new EnrollmentsClient(createdCourse.Id);
                var userId = long.Parse(ltiParams["custom_canvas_user_id"]);
                await enrollmentclient.EnrollUser(userId, EnrollmentType.TeacherEnrollment);
            }
            else
            {
                model.StatusCode = 403;
            }

            Response.Headers.Add("X-Frame-Options", $"ALLOW-FROM {Environment.GetEnvironmentVariable("BaseUrl")}");
            return View(model);
        }

        private bool IsValidLtiRequest(HttpRequest request, Dictionary<string, string> ltiParams)
        {
            // Write later
            return true;
        }

        private Dictionary<string, string> ParseLtiParams(IFormCollection form)
        {
            Dictionary<string, string> LtiParams = new Dictionary<string, string>();

            if (form != null && form.Count > 0)
            {
                foreach (var pair in form)
                {
                    LtiParams.Add(pair.Key, pair.Value);
                }
            }

            return LtiParams;
        }
    }
}