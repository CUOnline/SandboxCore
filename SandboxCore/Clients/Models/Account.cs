using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SandboxCore.Clients.Models
{
    /// <summary>
    /// A Canvas account
    /// </summary>
    public class Account : CanvasItem
    {
        /// <summary>
        /// The ID of the parent account
        /// </summary>
        [JsonProperty(PropertyName = "parent_account_id")]
        public long? ParentAccountId { get; set; }

        /// <summary>
        /// The ID of the root account
        /// </summary>
        [JsonProperty(PropertyName = "root_account_id")]
        public long? RootAccountId { get; set; }

        /// <summary>
        /// The default time zone of the account, in IANA format
        /// </summary>
        [JsonProperty(PropertyName = "default_time_zone")]
        public string DefaultTimeZone { get; set; }

        /// <summary>
        /// The default course storage quota to be used, in MB, if not otherwise specified.
        /// </summary>
        [JsonProperty(PropertyName = "default_storage_quota_mb")]
        public int DefaultStorageQuotaMB { get; set; }

        /// <summary>
        /// The default user storage quota to be used, in MB, if not otherwise specified.
        /// </summary>
        [JsonProperty(PropertyName = "default_user_storage_quota_mb")]
        public int DefaultUserStorageQuotaMB { get; set; }

        /// <summary>
        /// The default group storage quota to be used, in MB, if not otherwise specified.
        /// </summary>
        [JsonProperty(PropertyName = "default_group_storage_quota_mb")]
        public int DefaultGroupStorageQuotaMB { get; set; }

        /// <summary>
        /// The workflow state of the account
        /// </summary>
        [JsonProperty(PropertyName = "workflow_state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AccountWorkflowState WorkflowState { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}, DefaultTimeZone: {2}, DefaultStorageQuotaMB: {3}, DefaultUserStorageQuotaMB: {4}, DefaultGroupStorageQuotaMB: {5}, ParentAccountId: {6}, RootAccountId: {7}, WorkflowState: {8}", Id, Name, DefaultTimeZone, DefaultStorageQuotaMB, DefaultUserStorageQuotaMB, DefaultGroupStorageQuotaMB, ParentAccountId, RootAccountId, WorkflowState);
        }
    }

    public enum AccountWorkflowState
    {
        Active,
        Completed,
        All
    }
}