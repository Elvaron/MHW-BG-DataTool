using System.Text.Json.Serialization;

namespace Model.Utility
{
    /// <summary>
    /// Represents a four-way arc
    /// </summary>
    public class Arc4
    {
        /// <summary>
        /// Front arc active?
        /// </summary>
        [JsonPropertyName("front")]
        public bool? Front { get; set; } = false;

        /// <summary>
        /// Back arc active?
        /// </summary>
        [JsonPropertyName("back")]
        public bool? Back { get; set; } = false;

        /// <summary>
        /// Left arc active?
        /// </summary>
        [JsonPropertyName("left")]
        public bool? Left { get; set; } = false;

        /// <summary>
        /// Right arc active?
        /// </summary>
        [JsonPropertyName("right")]
        public bool? Right { get; set; } = false;
    }
}
