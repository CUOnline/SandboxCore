using Newtonsoft.Json;

namespace SandboxCore.Clients.Models
{
    /// <summary>
    /// A Canvas user profile
    /// </summary>
    public class UserProfile : UserBase
    {
        /// <summary>
        /// Optional: This field can be requested with certain API calls, and will return the users primary email address.
        /// </summary>
        [JsonProperty(PropertyName = "primary_email")]
        public string PrimaryEmail { get; set; }

        /// <summary>
        /// The professional/academic title for the user.
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Free-form biographical information entered by the user.
        /// </summary>
        [JsonProperty(PropertyName = "bio")]
        public string Bio { get; set; }
    }
}