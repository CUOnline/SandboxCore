using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SandboxCore.Clients.Models
{
    public class EnrollmentWrapper
    {
        [JsonProperty(PropertyName = "enrollment")]
        public Enrollment Enrollment { get; set; }
    }

    /// <summary>
    /// A Canvas users's enrollment in (i.e. relationship to) a class
    /// </summary>
    public class Enrollment
    {
        /// <summary>
        /// The ID of the item.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public long? Id { get; set; }

        /// <summary>
        /// The unique id of the course.
        /// </summary>
        [JsonProperty(PropertyName = "course_id")]
        public long? CourseId { get; set; }

        /// <summary>
        /// The SIS Course ID in which the enrollment is associated. Only displayed if present. This field is only included if the user has permission to view SIS information.
        /// </summary>
        [JsonProperty(PropertyName = "sis_course_id")]
        public string SisCourseId { get; set; }

        /// <summary>
        /// The Course Integration ID in which the enrollment is associated. This field is only included if the user has permission to view SIS information.
        /// </summary>
        [JsonProperty(PropertyName = "course_integration_id")]
        public string CourseIntegrationId { get; set; }

        /// <summary>
        /// The unique id of the user's section.
        /// </summary>
        [JsonProperty(PropertyName = "course_section_id")]
        public long? CourseSectionId { get; set; }

        /// <summary>
        /// The Section Integration ID in which the enrollment is associated. This field is only included if the user has permission to view SIS information.
        /// </summary>
        [JsonProperty(PropertyName = "section_integration_id")]
        public string SectionIntegrationId { get; set; }

        /// <summary>
        /// The SIS Section ID in which the enrollment is associated. Only displayed if present. This field is only included if the user has permission to view SIS information.
        /// </summary>
        [JsonProperty(PropertyName = "sis_section_id")]
        public string SisSectionId { get; set; }

        /// <summary>
        /// The state of the user's enrollment in the course.
        /// </summary>
        [JsonProperty(PropertyName = "enrollment_state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EnrollmentState? EnrollmentState { get; set; }

        /// <summary>
        /// User can only access his or her own course section.
        /// </summary>
        [JsonProperty(PropertyName = "limit_privileges_to_course_section")]
        public bool? LimitPriviligesToCourseSection { get; set; }

        /// <summary>
        /// The unique identifier for the SIS import. This field is only included if the user has permission to manage SIS information.
        /// </summary>
        [JsonProperty(PropertyName = "sis_import_id")]
        public string SisImportId { get; set; }

        /// <summary>
        /// The unique id of the user's account.
        /// </summary>
        [JsonProperty(PropertyName = "root_account_id")]
        public long? RootAccountId { get; set; }

        /// <summary>
        /// The enrollment type.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EnrollmentType? Type { get; set; }

        /// <summary>
        /// The unique id of the user.
        /// </summary>
        [JsonProperty(PropertyName = "user_id")]
        public long? UserId { get; set; }

        /// <summary>
        /// The unique id of the associated user. Will be null unless Type is 'ObserverEnrollment'
        /// </summary>
        [JsonProperty(PropertyName = "associated_user_id")]
        public long? AssociatedUserId { get; set; }

        /// <summary>
        /// The enrollment role, for course-level permissions. This field will match Type if the enrollment role has not been customized.
        /// </summary>
        [JsonProperty(PropertyName = "role")]
        public string Role { get; set; }

        /// <summary>
        /// The unique id of the enrollment role.
        /// </summary>
        [JsonProperty(PropertyName = "role_id")]
        public long? RoleId { get; set; }

        /// <summary>
        /// The created time of the enrollment
        /// </summary>
        [JsonProperty(PropertyName = "created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// The updated time of the enrollment
        /// </summary>
        [JsonProperty(PropertyName = "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// The start time of the enrollment
        /// </summary>
        [JsonProperty(PropertyName = "start_at")]
        public DateTime? StartAt { get; set; }

        /// <summary>
        /// The end time of the enrollment
        /// </summary>
        [JsonProperty(PropertyName = "end_at")]
        public DateTime? EndAt { get; set; }

        /// <summary>
        /// The last activity time of the user for the enrollment
        /// </summary>
        [JsonProperty(PropertyName = "last_activity_at")]
        public DateTime? LastActivityAt { get; set; }

        /// <summary>
        /// The total activity time of the user for the enrollment, in seconds.
        /// </summary>
        [JsonProperty(PropertyName = "total_activity_time")]
        public int? TotalActivityTime { get; set; }

        /// <summary>
        /// The URL to the Canvas web UI page for this course enrollment.
        /// </summary>
        [JsonProperty(PropertyName = "html_url")]
        public string HtmlUrl { get; set; }

        /// <summary>
        /// The user's grades/scores for this enrollment, if applicable
        /// </summary>
        [JsonProperty(PropertyName = "grades")]
        public Grade Grades { get; set; }

        /// <summary>
        /// The user for which this enrollment applies
        /// </summary>
        [JsonProperty(PropertyName = "user")]
        public User User { get; set; }
    }
}