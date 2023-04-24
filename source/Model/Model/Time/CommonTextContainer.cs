using Model.Utility;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Model.Model.Time
{
    /// <summary>
    /// A lot of cards share the same text on the top, so this avoids duplication
    /// </summary>
    [DebuggerDisplay("{Id,nq}")]
    public class CommonTextContainer
    {
        /// <summary>
        /// Reference id
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Rule texts
        /// </summary>
        [JsonPropertyName("rules")]
        public i18nString? Rules { get; set; }
    }
}
