using MultiLanguageSearch.Persistence.Components;

namespace MultiLanguageSearch.Persistence
{
    public static class Settings
    {
        private static readonly Manager<Fields> fields = new("fields.json");
        private static readonly Manager<Cache> cache = new("cache.json");

        public static Fields Fields => fields.Value;
        public static Cache Cache => cache.Value;

        public static void Save()
        {
            fields.Save();
            cache.Save();
        }
    }
}
