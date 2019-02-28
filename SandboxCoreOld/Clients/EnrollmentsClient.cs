using Newtonsoft.Json;
using SandboxCore.Clients.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SandboxCore.Clients
{
    public class EnrollmentsClient : ClientBase
    {
        public EnrollmentsClient(long? courseId) : base($"courses/{courseId}/enrollments") { }

        public async Task<Enrollment> EnrollUser(long? userId, EnrollmentType type)
        {
            Enrollment enrollment = new Enrollment()
            {
                UserId = userId,
                Type = type
            };

            string json = JsonConvert.SerializeObject(new EnrollmentWrapper { Enrollment = enrollment }, 
                Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            ApiPath = ApiController;
            return await ExecutePost<Enrollment>(ApiPath, json);
        }
    }
}
