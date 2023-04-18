﻿using System.Text.Json.Serialization;

namespace Model.Model.Quests
{
    public class Terrain
    {
        /// <summary>
        /// Terrain type
        /// </summary>
        /// <value>bush|rock|pond</value>
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        /// <summary>
        /// X Position on the grid, 1 = leftmost column
        /// </summary>
        [JsonPropertyName("x")]
        public int? X { get; set; }

        /// <summary>
        /// Y Position on the grid, 1 = topmost row 
        /// </summary>
        [JsonPropertyName("y")]
        public int? Y { get; set; }
    }
}