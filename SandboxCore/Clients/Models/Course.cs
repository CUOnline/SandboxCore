using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SandboxCore.Clients.Models
{
    /// <summary>
    /// Wrapper for sending the course in an API request
    /// </summary>
    public class CourseWrapper
    {
        [JsonProperty(PropertyName = "course")]
        public Course Course { get; set; }
    }

    /// <summary>
    /// A Canvas course.
    /// </summary>
    public class Course : CanvasItem
    {
        /// <summary>
        /// The account associated with the course
        /// </summary>
        [JsonProperty(PropertyName = "account_id")]
        public long? AccountId { get; set; }

        /// <summary>
        /// The root account associated with the course
        /// </summary>
        [JsonProperty(PropertyName = "root_account_id")]
        public long? RootAccountId { get; set; }

        /// <summary>
        /// The SIS identifier for the course, if defined. This field is only included if the user has permission to view SIS information.
        /// </summary>
        [JsonProperty(PropertyName = "sis_course_id")]
        public string SisCourseId { get; set; }

        /// <summary>
        /// The integration identifier for the course, if defined. This field is only included if the user has permission to view SIS information.
        /// </summary>
        [JsonProperty(PropertyName = "integration_id")]
        public string IntegrationId { get; set; }

        /// <summary>
        /// The course code
        /// </summary>
        [JsonProperty(PropertyName = "course_code")]
        public string CourseCode { get; set; }

        /// <summary>
        /// The course calendar
        /// </summary>
        [JsonProperty(PropertyName = "calendar")]
        public Calendar Calendar { get; set; }

        /// <summary>
        /// The current state of the course
        /// </summary>
        [JsonProperty(PropertyName = "workflow_state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CourseWorkflowState? WorkflowState { get; set; }

        /// <summary>
        /// The start date for the course, if applicable
        /// </summary>
        [JsonProperty(PropertyName = "start_at")]
        public DateTime? StartAt { get; set; }

        /// <summary>
        /// The end date for the course, if applicable
        /// </summary>
        [JsonProperty(PropertyName = "end_at")]
        public DateTime? EndAt { get; set; }

        /// <summary>
        /// Whether to weight final grade based on assignment group percentages
        /// </summary>
        [JsonProperty(PropertyName = "apply_assignment_group_weights")]
        public bool? ApplyAssignmentGroupWeights { get; set; }

        /// <summary>
        /// Whether to hide final grades
        /// </summary>
        [JsonProperty(PropertyName = "hide_final_grades")]
        public bool? HideFinalGrades { get; set; }

        /// <summary>
        /// Whether the course syllabus is public
        /// </summary>
        [JsonProperty(PropertyName = "public_syllabus")]
        public bool? PublicSyllabus { get; set; }

        /// <summary>
        /// The type of page that users will see when they first visit the course. 
        /// </summary>
        [JsonProperty(PropertyName = "default_view")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CourseDefaultView? DefaultView { get; set; }

        /// <summary>
        /// The storage quota for the course, in MB
        /// </summary>
        [JsonProperty(PropertyName = "storage_quota_mb")]
        public int? StorageQuotaMB { get; set; }

        /// <summary>
        /// The ID of the enrollment term associated with the course
        /// </summary>
        [JsonProperty(PropertyName = "enrollment_term_id")]
        public int? EnrollmentTermId { get; set; }

        /// <summary>
        /// The enrollment term associated with the course
        /// </summary>
        [JsonProperty(PropertyName = "term")]
        public EnrollmentTerm EnrollmentTerm { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}, CourseCode: {2}, WorkflowState: {3}, StartAt: {4}, EndAt: {5}", Id, Name, CourseCode, WorkflowState, StartAt, EndAt);
        }
    }

    [Flags]
    public enum CourseInclude
    {
        Unknown = 0x00,
        Needs_Grading_Count = 0x01,
        Syllabus_Body = 0x02,
        Total_Scores = 0x04,
        Term = 0x08,
        Course_Progress = 0x10,
        Sections = 0x20,
        Storage_Quota_Used_Mb = 0x40,
    }
}