﻿using Model.Utility;
using System.Text.Json.Serialization;

namespace Model.Model
{
    /// <summary>
    /// Represents a single Gathering Phase card
    /// </summary>
    public class Card
    {
        /// <summary>
        /// The number written on top of the card
        /// </summary>
        [JsonPropertyName("number")]
        public int? Number { get; set; }

        /// <summary>
        ///  The quest book page this card is found on
        /// </summary>
        [JsonPropertyName("page")]
        public int? Page { get; set; }

        /// <summary>
        /// The title text of the card
        /// </summary>
        /// <remarks>
        /// Usually something like "Assigned Quest Starting Point"
        /// </remarks>
        [JsonPropertyName("title")]
        public i18nString? Title { get; set; }

        /// <summary>
        /// The consequence of using a given starting point, e.g. getting a potion
        /// </summary>
        [JsonPropertyName("title-rule")]
        public i18nString? TitleRule { get; set; }

        /// <summary>
        /// The flavor text on the card that tells the story
        /// </summary>
        [JsonPropertyName("flavor")]
        public i18nString? Flavor { get; set; }

        /// <summary>
        /// Potential consequences (rewards and/or penalties) for this card no matter which rule is chosen
        /// </summary>
        [JsonPropertyName("consequence")]
        public i18nString? Consequence { get; set; }

        /// <summary>
        /// Rules to chose from
        /// </summary>
        [JsonPropertyName("rules")]
        public List<Rule>? Rules { get; set; }
    }
}
