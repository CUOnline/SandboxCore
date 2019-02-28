using System;
using Newtonsoft.Json;

namespace SandboxCore.Clients.Models
{
    /// <summary>
    /// A base model containing properties common to Canvas User* objects
    /// </summary>
    public abstract class UserBase : CanvasItem
    {
        /// <summary>
        /// A short name the user has selected, for use in conversations or other less formal places through the site.
        /// </summary>
        [JsonProperty(PropertyName = "short_name")]
        public string ShortName { get; set; }

        /// <summary>
        /// The name of the user that is should be used for sorting groups of users, such as in the gradebook.
        /// </summary>
        [JsonProperty(PropertyName = "sortable_name")]
        public string SortableName { get; set; }

        /// <summary>
        /// The unique login id for the user.  This is what the user uses to log in to Canvas.
        /// </summary>
        [JsonProperty(PropertyName = "login_id")]
        public string LoginId { get; set; }

        /// <summary>
        /// The SIS ID associated with the user.  This field is only included if the user came from a SIS import and has permissions to view SIS information.
        /// </summary>
        [JsonProperty(PropertyName = "sis_user_id")]
        public string SisUserId { get; set; }

        /// <summary>
        /// The SIS login ID associated with the user. 
        /// </summary>
        [Obsolete("This field will be removed in a future version of the API. Please use the SisUserId or LoginId.")]
        [JsonProperty(PropertyName = "sis_login_id")]
        public string SisLoginId { get; set; }

        /// <summary>
        /// If avatars are enabled, this field will be included and contain a url to retrieve the user's avatar.
        /// </summary>
        [JsonProperty(PropertyName = "avatar_url")]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// Optional: This field is only returned in ceratin API calls, and will return the IANA time zone name of the user's preferred timezone.
        /// </summary>
        [JsonProperty(PropertyName = "time_zone")]
        public string TimeZone { get; set; }
    }
}