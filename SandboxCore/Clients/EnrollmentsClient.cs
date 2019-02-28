using Newtonsoft.Json;
using SandboxCore.Clients.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SandboxCore.Clients
{
    public class EnrollmentsClient : ClientBase
    {
        public EnrollmentsClient(long? courseId, IConfiguration configuration) : base($"courses/{courseId}/enrollments", configuration) { }

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