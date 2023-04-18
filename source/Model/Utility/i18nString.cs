using System.Diagnostics;

namespace Model.Utility
{
    /// <summary>
    /// Localizable string container
    /// </summary>
    [DebuggerDisplay("{Default}")]
    public class i18nString : List<i18nText>
    {
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
