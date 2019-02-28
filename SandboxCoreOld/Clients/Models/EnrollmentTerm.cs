using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SandboxCore.Clients.Models
{
    public class EnrollmentTermRequest
    {
        /// <summary>
        /// The name of the item.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The SIS identifier for the term. This field is only included if the user has permission to manage SIS information.
        /// </summary>
        [JsonProperty(PropertyName = "sis_term_id")]
        public string SisTermId { get; set; }

        /// <summary>
        /// The start time of the term
        /// </summary>
        [JsonProperty(PropertyName = "start_at")]
        public DateTime? StartAt { get; set; }

        /// <summary>
        /// The end time of the term
        /// </summary>
        [JsonProperty(PropertyName = "end_at")]
        public DateTime? EndAt { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, SisTermId: {1}, StartAt: {2}, EndAt: {3}", Name, SisTermId, StartAt, EndAt);
        }
    }

    public class EnrollmentTerm : EnrollmentTermRequest
    {
        /// <summary>
        /// The ID of the item.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        /// <summary>
        /// The state of the user's enrollment in the course.
        /// </summary>
        [JsonProperty(PropertyName = "workflow_state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EnrollmentTermWorkflowState WorkflowState { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, {1}, WorkflowState: {2}", Id, base.ToString(), WorkflowState);
        }
    }
}