using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.Instagram;
using Gamescom2015;
using Gamescom2015.Sections;
using Gamescom2015.ViewModels;

namespace Gamescom2015.Views
{
    public sealed partial class InstagramFeedListPage : PageBase
    {
        public ListViewModel<InstagramDataConfig, InstagramSchema> ViewModel { get; set; }

        public InstagramFeedListPage()
        {
            this.ViewModel = new ListViewModel<InstagramDataConfig, InstagramSchema>(new InstagramFeedConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
