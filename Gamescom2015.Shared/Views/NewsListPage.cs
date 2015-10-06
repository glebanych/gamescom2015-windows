using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.Rss;
using Gamescom2015;
using Gamescom2015.Sections;
using Gamescom2015.ViewModels;

namespace Gamescom2015.Views
{
    public sealed partial class NewsListPage : PageBase
    {
        public ListViewModel<RssDataConfig, RssSchema> ViewModel { get; set; }

        public NewsListPage()
        {
            this.ViewModel = new ListViewModel<RssDataConfig, RssSchema>(new NewsConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
