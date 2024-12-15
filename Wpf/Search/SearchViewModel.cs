using MultiLanguageSearch.Persistence.Components;
using MultiLanguageSearch.Wpf.Common;

namespace MultiLanguageSearch.Wpf.Search
{
    public class SearchViewModel : ViewModelBase
    {
        private readonly Fields field;

        public SearchViewModel(
            Fields field)
        {
            this.field = field;
        }

        public string SearchTerm { get; set; }
        public string GoogleSearchApiKey { get; set; }
    }
}
