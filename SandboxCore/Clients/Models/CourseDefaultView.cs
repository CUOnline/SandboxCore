namespace SandboxCore.Clients.Models
{
    /// <summary>
    /// The type of page that users will see when they first visit a course. Other types may be added in the future.
    /// </summary>
    public enum CourseDefaultView
    {
        /// <summary>
        /// Recent Activity Dashboard 
        /// </summary>
        Feed,
        /// <summary>
        /// Wiki Front Page 
        /// </summary>
        Wiki,
        /// <summary>
        /// Course Modules/Sections Page 
        /// </summary>
        Modules,
        /// <summary>
        /// Course Assignments List 
        /// </summary>
        Assignments,
        /// <summary>
        /// Course Syllabus Page 
        /// </summary>
        Syllabus,
    }
}