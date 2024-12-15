namespace MultiLanguageSearch
{
    public class Locale
    {
        public static readonly IReadOnlyList<Locale> All =
        [
            new Locale
            {
                Location = "USA"
            }
        ];

        public string Location { get; init; } = string.Empty;

    }
}
