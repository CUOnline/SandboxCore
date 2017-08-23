using Newtonsoft.Json;

namespace SandboxCore.Clients.Models
{
    /// <summary>
    /// A base model containing properties common to many Canvas entities.
    /// </summary>
    public abstract class CanvasItem
    {
        /// <summary>
        /// The ID of the item.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public long? Id { get; set; }

        /// <summary>
        /// The name of the item.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}