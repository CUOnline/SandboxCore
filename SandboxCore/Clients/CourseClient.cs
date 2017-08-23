using Newtonsoft.Json;
using SandboxCore.Clients.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SandboxCore.Clients
{
    public class CourseClient : ClientBase
    {
        public CourseClient(long sandboxAccountId) : base($"accounts/{sandboxAccountId}/courses") { }

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
