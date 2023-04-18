using Model.Utility;
using System.Text.Json.Serialization;

namespace Model.Model.Behavior
{
    /// <summary>
    /// Represents monsters' special action behaviors, like Teostra's Supernova behavior
    /// </summary>
    public class SpecialBehaviorCard
    {
        /// <summary>
        /// The condition for the special behavior card
        /// </summary>
        [JsonPropertyName("condition")]
        public i18nString? Condition { get; set; }

        /// <summary>
        /// The behavior itself
        /// </summary>
        [JsonPropertyName("behavior")]
        public BehaviorCard? BehaviorCard { get; set; }
    }
}
