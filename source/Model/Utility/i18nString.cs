using System.Diagnostics;

namespace Model.Utility
{
    /// <summary>
    /// Localizable string container
    /// </summary>
    [DebuggerDisplay("{Default}")]
    public class i18nString : List<i18nText>
    {
        public i18nString() { }

        public i18nString(string text, string language = "en-US")
        {
            Add(new i18nText { Language = language, Text = text });
        }

        public static implicit operator i18nString(string s) => new i18nString(s);

        public void Add(string text, string language = "en-US")
        {
            Add(new i18nText { Language = language, Text = text });
        }

        /// <summary>
        /// Default text
        /// </summary>
        public string? Default => this.FirstOrDefault()?.Text ?? null;

        /// <summary>
        /// Localized text
        /// </summary>
        /// <param name="language">Language token to use</param>
        /// <returns>Localized Text</returns>
        public string? Get(string? language)
        {
            return this.FirstOrDefault(x => x.Language != null && x.Language.Equals(language))?.Text ?? Default;
        }
    }
}
