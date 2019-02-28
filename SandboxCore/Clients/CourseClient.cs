using Newtonsoft.Json;
using SandboxCore.Clients.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SandboxCore.Clients
{
    public class CourseClient : ClientBase
    {
        public CourseClient(long sandboxAccountId, IConfiguration configuration) : base($"accounts/{sandboxAccountId}/courses", configuration) { }

        public async Task<Course> CreateCourse(string courseName)
        {
            Course newCourse = new Course()
            {
                Name = courseName
            };

            string json = JsonConvert.SerializeObject(new CourseWrapper { Course = newCourse },
                Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            ApiPath = ApiController;
            return await ExecutePost<Course>(ApiPath, json);
        }
    }
}