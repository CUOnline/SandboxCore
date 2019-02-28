using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SandboxCore.Clients.Models
{
    /// <summary>
    /// A Canvas user's grade/score in a class
    /// </summary>
    public class Grade
    {
        /// <summary>
        /// The URL to the Canvas web UI page for the user's grades, if this is a student enrollment.
        /// </summary>
        [JsonProperty(PropertyName = "html_url")]
        public string HtmlUrl { get; set; }

        /// <summary>
        /// The user's current grade in the class. Only included if user has permissions to view this grade.
        /// </summary>
        [JsonProperty(PropertyName = "current_grade")]
        public decimal? CurrentGrade { get; set; }

        /// <summary>
        /// The user's final grade in the class. Only included if user has permissions to view this grade.
        /// </summary>
        [JsonProperty(PropertyName = "final_grade")]
        public decimal? FinalGrade { get; set; }

        /// <summary>
        /// The user's current score in the class. Only included if user has permissions to view this score.
        /// </summary>
        [JsonProperty(PropertyName = "current_score")]
        public decimal? CurrentScore { get; set; }

        /// <summary>
        /// The user's final score in the class. Only included if user has permissions to view this score.
        /// </summary>
        [JsonProperty(PropertyName = "final_score")]
        public decimal? FinalScore { get; set; }
    }
}