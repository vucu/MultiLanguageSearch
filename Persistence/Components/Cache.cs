namespace MultiLanguageSearch.Persistence.Components
{
    public class Cache
    {
        // (search term, (location, translated query))
        public Dictionary<string, Dictionary<string, string>> Translations { get; set; } = new();
    }
}
