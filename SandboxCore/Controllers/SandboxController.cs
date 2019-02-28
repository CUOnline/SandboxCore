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
using Microsoft.Extensions.Configuration;

namespace SandboxCore.Controllers
{
    public class SandboxController : Controller
    {
        private Dictionary<string, string> LtiParams = new Dictionary<string, string>();

        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;

        public SandboxController(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.configuration= configuration;
        }

        public IActionResult Index()
        {
            var configDoc = XDocument.Load(hostingEnvironment.WebRootPath + "/content/lti_config.xml");

            StringBuilder sb = new StringBuilder(configDoc.ToString());
            sb.Replace("{LaunchUrl}", configuration["CanvasSettings:LaunchUrl"]);
            sb.Replace("{MountPoint}", configuration["CanvasSettings:MountPoint"]);

            return new ContentResult() { Content = sb.ToString(), ContentType = "text/xml" };
        }

        [HttpPost]
        public async Task<IActionResult> CreateSandbox()
        {
            var model = new SandboxViewModel()
            {
                StatusCode = 200,
                BaseUrl = configuration["CanvasSettings:BaseUrl"]
            };

            var ltiParams = ParseLtiParams(HttpContext.Request.Form);

            if (IsValidLtiRequest(Request, ltiParams)
                && ltiParams["ext_roles"].Contains("Administrator")
                || ltiParams["ext_roles"].Contains("Instructor"))
            {
                // Api request to create new course
                CourseClient courseClient = new CourseClient(long.Parse(configuration["CanvasSettings:SandboxAccountId"]), configuration);
                var courseName = $"sandbox_{ltiParams["lis_person_name_full"]}".Replace(" ", "_");
                Course createdCourse = await courseClient.CreateCourse(courseName);

                EnrollmentsClient enrollmentclient = new EnrollmentsClient(createdCourse.Id, configuration);
                var userId = long.Parse(ltiParams["custom_canvas_user_id"]);
                await enrollmentclient.EnrollUser(userId, EnrollmentType.TeacherEnrollment);
            }
            else
            {
                model.StatusCode = 403;
            }

            Response.Headers.Add("X-Frame-Options", $"ALLOW-FROM {configuration["CanvasSettings:BaseUrl"]}");
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