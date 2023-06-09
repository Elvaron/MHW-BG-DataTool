﻿using Model.Utility;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Model.Model.Quests
{
    /// <summary>
    /// Represents a single rule box on a card
    /// </summary>
    /// <remarks>
    /// In the print version, these are usually back-lit in green
    /// </remarks>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class GatheringRule
    {
        /// <summary>
        /// The story-like instruction for the players
        /// </summary>
        [JsonPropertyName("prompt")]
        public i18nString? Prompt { get; set; }

        /// <summary>
        /// A potential condition such as "only if you have X in your inventory"
        /// </summary>
        [JsonPropertyName("condition")]
        public i18nString? Condition { get; set; }

        /// <summary>
        /// The outcome of this rule
        /// </summary>
        [JsonPropertyName("rules")]
        public i18nString? Rules { get; set; }

        [JsonIgnore]
        private string DebuggerDisplay
        {
            get { return Prompt?.Default ?? ""; }
        }
    }
}
